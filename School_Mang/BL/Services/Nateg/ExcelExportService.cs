
using School_Mang.BL.Common.Helper;
using School_Mang.BL.ExcelUtils;
using System;
using System.Data;

namespace School_Mang.BL.Services.Nateg
{
    public class ExcelExportService
    {
        private bool ExportWorkbook(
                     string staticExcelFile,
                     string worksheetName,
                     string saveAsLocation,
                     string title,
                     Action<Microsoft.Office.Interop.Excel.Worksheet> writeData)
        {
            using (ExcelWorkbookSession session =
                   new ExcelWorkbookSession(staticExcelFile))
            {
                ExcelHelper.RenameWorksheet(
                    session.Worksheet,
                    worksheetName);

                ExcelHelper.SetCellValue(
                    session.Worksheet,
                    2,
                    2,
                    title);

                writeData(session.Worksheet);

                ExcelHelper.ProtectWorksheet(
                    session.Worksheet,
                    "kps2023");

                session.SaveAs(saveAsLocation);
            }

            return true;
        }

        public bool WriteRasdDataToExcel(
                                        DataTable dataTable,
                                        string worksheetName,
                                        string saveAsLocation,
                                        string RasdDataName,
                                        string staticExcelFile,
                                        short test_kind)
        {
            int year = Properties.Settings.Default.year_cod;

            return ExportWorkbook(
                staticExcelFile,
                worksheetName,
                saveAsLocation,
                RasdDataName,
                worksheet =>
                {
                    ExcelHelper.WriteStudentRows(
                        worksheet,
                        dataTable,
                        (sheet, dataRow, rowNumber) =>
                        {
                            ExcelHelper.SetRowValues(
                                sheet,
                                rowNumber,
                                16,
                                test_kind.ToString(),
                                dataRow[3].ToString());

                            ExcelHelper.SetCellValue(
                                sheet,
                                rowNumber,
                                19,
                                dataRow[2].ToString());

                            ExcelHelper.SetCellValue(
                                sheet,
                                rowNumber,
                                20,
                                year.ToString());
                        });

                    ExcelHelper.DeleteEntireRows(
                        worksheet,
                        Convert.ToInt16(dataTable.Rows.Count) + 5,
                        152);
                });
        }

        public bool WriteAmalDataToExcel(
                                    DataTable dataTable,
                                    string worksheetName,
                                    string saveAsLocation,
                                    string RasdDataName,
                                    string staticExcelFile,
                                    string test_kind,
                                    string grade_data,
                                    string year_data,
                                    string term_kind,
                                    short grade,
                                    byte term_id,
                                    byte prim = 0)
        {
            int gradeColumn;

            switch (prim)
            {
                case 0:
                    gradeColumn = 17;
                    break;

                case 1:
                case 3:
                    gradeColumn = 13;
                    break;

                case 2:
                    gradeColumn = 11;
                    break;

                default:
                    gradeColumn = 0;
                    break;
            }

            return ExportWorkbook(
                staticExcelFile,
                worksheetName,
                saveAsLocation,
                RasdDataName,
                worksheet =>
                {
                    ExcelHelper.WriteFileInformation(
                        worksheet,
                        test_kind,
                        term_kind,
                        grade_data,
                        year_data,
                        1,
                        grade,
                        term_id);

                    ExcelHelper.WriteStudentRows(
                        worksheet,
                        dataTable,
                        (sheet, dataRow, rowNumber) =>
                        {
                            if (gradeColumn > 0)
                            {
                                ExcelHelper.SetCellValue(
                                    sheet,
                                    rowNumber,
                                    gradeColumn,
                                    dataRow[2].ToString());
                            }
                        });

                    ExcelHelper.DeleteRange(
                        worksheet,
                        Convert.ToInt16(dataTable.Rows.Count) + 5,
                        1,
                        152,
                        19);
                });
        }

        public bool WriteTestDataToExcel(
                                    DataTable dataTable,
                                    string worksheetName,
                                    string saveAsLocation,
                                    string RasdDataName,
                                    string staticExcelFile,
                                    string test_kind,
                                    string grade_data,
                                    string year_data,
                                    string term_kind,
                                    short grade,
                                    byte term_id)
        {
            return ExportWorkbook(
                staticExcelFile,
                worksheetName,
                saveAsLocation,
                RasdDataName,
                worksheet =>
                {
                    ExcelHelper.WriteFileInformation(
                        worksheet,
                        test_kind,
                        term_kind,
                        grade_data,
                        year_data,
                        2,
                        grade,
                        term_id);

                    ExcelHelper.WriteSimpleRows(
                        worksheet,
                        dataTable,
                        5,
                        0,
                        1);

                    ExcelHelper.DeleteRange(
                        worksheet,
                        Convert.ToInt16(dataTable.Rows.Count) + 5,
                        1,
                        152,
                        29);
                });
        }

        public bool WriteSeryDataToExcel(
                                    DataTable dataTable,
                                    string worksheetName,
                                    string saveAsLocation,
                                    string RasdDataName,
                                    string staticExcelFile)
        {
            return ExportWorkbook(
                staticExcelFile,
                worksheetName,
                saveAsLocation,
                RasdDataName,
                worksheet =>
                {
                    int id = 0;

                    foreach (DataRow dataRow in dataTable.Rows)
                    {
                        id++;

                        ExcelHelper.SetRowValues(
                            worksheet,
                            id + 4,
                            1,
                            id.ToString(),
                            dataRow[2].ToString(),
                            dataRow[0].ToString());
                    }

                    ExcelHelper.DeleteRange(
                        worksheet,
                        Convert.ToInt16(dataTable.Rows.Count) + 5,
                        1,
                        152,
                        19);
                });
        }
    }
}
