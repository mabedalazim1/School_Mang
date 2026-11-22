using School_Mang.BL.Common.Helper;
using School_Mang.BL.ExcelUtils;
using System;
using Excel = Microsoft.Office.Interop.Excel;
using System.Data;

namespace School_Mang.BL.Services.Nateg
{
    public class ExcelImportService
    {
        private void ReadExcelRows( string filePath,
                                    Action<Excel.Range, int> readRow,
                                    int startRow = 5)
        {
            if (readRow == null)
                throw new ArgumentNullException(nameof(readRow));

            using (ExcelWorkbookSession session =
                   new ExcelWorkbookSession(filePath))
            {
                Excel.Range usedRange = null;

                try
                {
                    usedRange = session.Worksheet.UsedRange;

                    int rowCount = usedRange.Rows.Count;

                    for (int i = startRow; i <= rowCount; i++)
                    {
                        readRow(usedRange, i);
                    }
                }
                finally
                {
                    ExcelHelper.ReleaseComReference(usedRange);
                }
            }
        }

        private decimal ReadDecimalValue(Excel.Range range,
                                         int row,
                                         int column)
        {
            object value = ExcelHelper.GetCellValue(range, row, column);

            decimal result;

            if (value == null ||
                !decimal.TryParse(value.ToString(), out result))
            {
                throw new InvalidOperationException(
                    "توجد درجة غير رقمية في الصف رقم " + row +
                    " والعمود رقم " + column +
                    ". يرجى مراجعة ملف Excel.");
            }

            return result;
        }
        private DataTable CreateDataTable(
                              params (string columnName, Type dataType)[] columns)
        {
            DataTable dt = new DataTable();

            foreach (var column in columns)
            {
                dt.Columns.Add(column.columnName, column.dataType);
            }

            return dt;
        }

        private T ReadValue<T>( Excel.Range range,
                                int row,
                                int column)
        {
            return (T)Convert.ChangeType(
                ExcelHelper.GetCellValue(range, row, column),
                typeof(T));
        }

        public DataTable GetInformationData(string staticExcelFile)
        {
            DataTable dt = CreateDataTable(
                ("test_kind", typeof(string)),
                ("term_kind", typeof(string)),
                ("grade_data", typeof(string)),
                ("year_data", typeof(string)),
                ("test_kind_id", typeof(string)),
                ("test_grade_id", typeof(string)),
                ("term_id", typeof(string)),
                ("degree_data", typeof(string))
            );

            ReadExcelRows(staticExcelFile, (range, row) =>
            {
                DataRow newRow = dt.NewRow();

                newRow["test_kind"] = ReadValue<string>(range, 1, 30);
                newRow["term_kind"] = ReadValue<string>(range, 2, 30);
                newRow["grade_data"] = ReadValue<string>(range, 3, 30);
                newRow["year_data"] = ReadValue<string>(range, 4, 30);
                newRow["test_kind_id"] = ReadValue<string>(range, 5, 30);
                newRow["test_grade_id"] = ReadValue<string>(range, 6, 30);
                newRow["term_id"] = ReadValue<string>(range, 7, 30);
                newRow["degree_data"] = ReadValue<string>(range, 8, 30);

                dt.Rows.Add(newRow);
            }, 1);

            return dt;
        }

        public DataTable Read_Amal_1_2(string staticExcelFile)
        {
            DataTable dt = CreateDataTable(
                ("Golos", typeof(string)),
                ("arabic", typeof(decimal)),
                ("dain", typeof(decimal)),
                ("math", typeof(decimal)),
                ("scince", typeof(decimal)),
                ("english", typeof(decimal)),
                ("maharat", typeof(decimal)),
                ("mabday", typeof(decimal)),
                ("nehay", typeof(decimal))
            );

            ReadExcelRows(staticExcelFile, (range, i) =>
            {
                DataRow row = dt.NewRow();
                row["Golos"] = Convert.ToString(
                        ExcelHelper.GetCellValue(range, i, 4));

                row["arabic"] = ReadDecimalValue(range, i, 5);
                row["dain"] = ReadDecimalValue(range, i, 6);
                row["math"] = ReadDecimalValue(range, i, 7);
                row["scince"] = ReadDecimalValue(range, i, 8);
                row["english"] = ReadDecimalValue(range, i, 9);
                row["maharat"] = ReadDecimalValue(range, i, 10);
                row["mabday"] = ReadDecimalValue(range, i, 11);
                row["nehay"] = ReadDecimalValue(range, i, 12);

                dt.Rows.Add(row);
            });

            return dt;
        }

        public DataTable Read_Amal_3(string staticExcelFile)
        {
            DataTable dt = CreateDataTable(
                ("Golos", typeof(string)),
                ("arabic", typeof(decimal)),
                ("dain", typeof(decimal)),
                ("math", typeof(decimal)),
                ("scince", typeof(decimal)),
                ("english", typeof(decimal)),
                ("maharat", typeof(decimal))
            );

            ReadExcelRows(staticExcelFile, (range, i) =>
            {
                DataRow row = dt.NewRow();

                row["Golos"] = Convert.ToString(
                    ExcelHelper.GetCellValue(range, i, 4));

                row["arabic"] = ReadDecimalValue(range, i, 5);
                row["dain"] = ReadDecimalValue(range, i, 6);
                row["math"] = ReadDecimalValue(range, i, 7);
                row["scince"] = ReadDecimalValue(range, i, 8);
                row["english"] = ReadDecimalValue(range, i, 9);
                row["maharat"] = ReadDecimalValue(range, i, 10);

                dt.Rows.Add(row);
            });

            return dt;
        }

        public DataTable Read_Amal_4_5_6(string staticExcelFile)
        {
            DataTable dt = CreateDataTable(
                ("Golos", typeof(string)),
                ("arabic", typeof(decimal)),
                ("dain", typeof(decimal)),
                ("math", typeof(decimal)),
                ("scince", typeof(decimal)),
                ("social", typeof(decimal)),
                ("english", typeof(decimal)),
                ("maharat", typeof(decimal)),
                ("tocnolegy", typeof(decimal))
            );

            ReadExcelRows(staticExcelFile, (range, i) =>
            {
                DataRow row = dt.NewRow();

                row["Golos"] = Convert.ToString(
                    ExcelHelper.GetCellValue(range, i, 4));

                row["arabic"] = ReadDecimalValue(range, i, 5);
                row["dain"] = ReadDecimalValue(range, i, 6);
                row["math"] = ReadDecimalValue(range, i, 7);
                row["scince"] = ReadDecimalValue(range, i, 8);
                row["social"] = ReadDecimalValue(range, i, 9);
                row["english"] = ReadDecimalValue(range, i, 10);
                row["maharat"] = ReadDecimalValue(range, i, 11);
                row["tocnolegy"] = ReadDecimalValue(range, i, 12);

                dt.Rows.Add(row);
            });

            return dt;
        }

        public DataTable Read_Test(string staticExcelFile, byte stage = 1)
        {
            DataTable dt = CreateDataTable(
                ("Golos", typeof(string)),
                ("arabic", typeof(decimal)),
                ("dain", typeof(decimal)),
                ("math", typeof(decimal)),
                ("scince", typeof(decimal)),
                ("social", typeof(decimal)),
                ("english", typeof(decimal)),
                ("maharat", typeof(decimal)),
                ("tocnolegy", typeof(decimal))
            );

            ReadExcelRows(staticExcelFile, (range, i) =>
            {
                DataRow row = dt.NewRow();

                string golos = Convert.ToString(
                    ExcelHelper.GetCellValue(range, i, 1));

                row["Golos"] = golos;

                row["arabic"] = ReadDecimalValue(range, i, 3);
                row["dain"] = ReadDecimalValue(range, i, 4);

                switch (stage)
                {
                    case 0:
                        row["math"] = ReadDecimalValue(range, i, 5);
                        row["scince"] = ReadDecimalValue(range, i, 6);
                        row["english"] = ReadDecimalValue(range, i, 7);
                        row["social"] = 0;
                        row["maharat"] = 0;
                        row["tocnolegy"] = 0;
                        break;

                    case 1:
                        row["math"] = ReadDecimalValue(range, i, 5);
                        row["scince"] = ReadDecimalValue(range, i, 6);
                        row["social"] = ReadDecimalValue(range, i, 7);
                        row["english"] = ReadDecimalValue(range, i, 8);
                        row["maharat"] = ReadDecimalValue(range, i, 9);
                        row["tocnolegy"] = ReadDecimalValue(range, i, 10);
                        break;

                    case 2:
                        row["math"] = ReadDecimalValue(range, i, 29);
                        row["scince"] = ReadDecimalValue(range, i, 7);
                        row["social"] = ReadDecimalValue(range, i, 8);
                        row["english"] = ReadDecimalValue(range, i, 9);
                        row["maharat"] = ReadDecimalValue(range, i, 10);
                        row["tocnolegy"] = ReadDecimalValue(range, i, 11);
                        break;
                }

                // الحفاظ على شرط التوقف 
                int seatNumber;

                if (string.IsNullOrWhiteSpace(golos) ||
                    (int.TryParse(golos, out seatNumber) && seatNumber == 0))
                {
                    return;
                }

                dt.Rows.Add(row);
            });

            return dt;
        }

        public DataTable Read_Amal_7_8_9(string staticExcelFile)
        {
            DataTable dt = CreateDataTable(
                ("Golos", typeof(string)),
                ("arabic", typeof(decimal)),
                ("dain", typeof(decimal)),
                ("math", typeof(decimal)),
                ("scince", typeof(decimal)),
                ("scince_practical", typeof(decimal)),
                ("social", typeof(decimal)),
                ("english", typeof(decimal)),
                ("maharat", typeof(decimal)),
                ("tocnolegy", typeof(decimal)),
                ("tocnolegy_practical", typeof(decimal)),
                ("nashat_1", typeof(decimal)),
                ("nashat_2", typeof(decimal))
            );

            ReadExcelRows(staticExcelFile, (range, i) =>
            {
                DataRow row = dt.NewRow();

                row["Golos"] = Convert.ToString(
                    ExcelHelper.GetCellValue(range, i, 4));

                row["arabic"] = ReadDecimalValue(range, i, 5);
                row["dain"] = ReadDecimalValue(range, i, 6);
                row["math"] = ReadDecimalValue(range, i, 7);
                row["scince"] = ReadDecimalValue(range, i, 8);
                row["scince_practical"] = ReadDecimalValue(range, i, 9);
                row["social"] = ReadDecimalValue(range, i, 10);
                row["english"] = ReadDecimalValue(range, i, 11);
                row["maharat"] = ReadDecimalValue(range, i, 12);
                row["tocnolegy"] = ReadDecimalValue(range, i, 13);
                row["tocnolegy_practical"] = ReadDecimalValue(range, i, 14);
                row["nashat_1"] = ReadDecimalValue(range, i, 15);
                row["nashat_2"] = ReadDecimalValue(range, i, 16);

                dt.Rows.Add(row);
            });

            return dt;
        }

    }
}
