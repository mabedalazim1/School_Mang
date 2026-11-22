using Microsoft.Office.Interop.Excel;
using System;
using System.Data;
using System.Runtime.InteropServices;
using System.Linq;

namespace School_Mang.BL.Common.Helper
{
    public static class ExcelHelper
    {
        public static void SetCellValue(
            Worksheet worksheet,
            int row,
            int column,
            object value)
        {
            Range cell = null;

            try
            {
                cell = (Range)worksheet.Cells[row, column];
                cell.Value2 = value;
            }
            finally
            {
                ReleaseComObject(cell);
            }
        }

        public static object GetCellValue(
                                    Worksheet worksheet,
                                    int row,
                                    int column)
        {
            Range cell = null;

            try
            {
                cell = (Range)worksheet.Cells[row, column];
                return cell.Value2;
            }
            finally
            {
                ReleaseComObject(cell);
            }
        }
        public static object GetCellValue(
                                Range range,
                                int row,
                                int column)
        {
            Range cell = null;

            try
            {
                cell = (Range)range.Cells[row, column];
                return cell.Value2;
            }
            finally
            {
                ReleaseComObject(cell);
            }
        }

        public static void SetRowValues(
            Worksheet worksheet,
            int row,
            int startColumn,
            params object[] values)
        {
            if (values == null || values.Length == 0)
                return;

            Range firstCell = null;
            Range lastCell = null;
            Range range = null;

            try
            {
                firstCell = (Range)worksheet.Cells[row, startColumn];

                lastCell = (Range)worksheet.Cells[
                    row,
                    startColumn + values.Length - 1];

                range = worksheet.Range[firstCell, lastCell];

                object[,] rowValues = new object[1, values.Length];

                for (int i = 0; i < values.Length; i++)
                    rowValues[0, i] = values[i];

                range.Value2 = rowValues;
            }
            finally
            {
                ReleaseComObject(range);
                ReleaseComObject(lastCell);
                ReleaseComObject(firstCell);
            }
        }

        public static void RenameWorksheet(
            Worksheet worksheet,
            string worksheetName)
        {
            worksheet.Name = worksheetName;
        }

        public static void ProtectWorksheet(
            Worksheet worksheet,
            string password)
        {
            worksheet.Protect(Password: password);
        }

        private static void ReleaseComObject(object obj)
        {
            if (obj != null && Marshal.IsComObject(obj))
                Marshal.FinalReleaseComObject(obj);
        }

        public static void DeleteRange(
                        Worksheet worksheet,
                        int startRow,
                        int startColumn,
                        int endRow,
                        int endColumn,
                        XlDeleteShiftDirection direction = XlDeleteShiftDirection.xlShiftUp)
        {
            if (startRow > endRow || startColumn > endColumn)
                return;

            Range firstCell = null;
            Range lastCell = null;
            Range range = null;

            try
            {
                firstCell = (Range)worksheet.Cells[startRow, startColumn];
                lastCell = (Range)worksheet.Cells[endRow, endColumn];

                range = worksheet.Range[firstCell, lastCell];
                range.Delete(direction);
            }
            finally
            {
                ReleaseComObject(range);
                ReleaseComObject(lastCell);
                ReleaseComObject(firstCell);
            }
        }

        public static void DeleteEntireRows(
            Worksheet worksheet,
            int startRow,
            int endRow)
        {
            if (startRow > endRow)
                return;

            Range firstRow = null;
            Range lastRow = null;
            Range range = null;
            Range entireRows = null;

            try
            {
                firstRow = (Range)worksheet.Rows[startRow];
                lastRow = (Range)worksheet.Rows[endRow];

                range = worksheet.Range[firstRow, lastRow];
                entireRows = range.EntireRow;

                entireRows.Delete();
            }
            finally
            {
                ReleaseComObject(entireRows);
                ReleaseComObject(range);
                ReleaseComObject(lastRow);
                ReleaseComObject(firstRow);
            }
        }

        public static void WriteStudentRows(
                                 Worksheet worksheet,
                                 System.Data.DataTable dataTable,
                                 Action<Worksheet, DataRow, int> writeAdditionalValues,
                                 int startRow = 5)
        {
            short id = 0;
            short c_id = 0;
            short class_id = 0;

            int row = startRow;

            foreach (DataRow dataRow in dataTable.Rows)
            {
                if (class_id != Convert.ToInt16(dataRow[2]))
                    c_id = 0;

                class_id = Convert.ToInt16(dataRow[2]);

                id++;
                c_id++;

                SetRowValues(
                    worksheet,
                    row,
                    1,
                    id.ToString(),
                    c_id.ToString(),
                    dataRow[1].ToString(),
                    dataRow[0].ToString());

                writeAdditionalValues?.Invoke(
                    worksheet, dataRow, row);

                row++;
            }
        }
        public static void SetColumnValues(
    Worksheet worksheet,
    int column,
    int startRow,
    params object[] values)
        {
            if (values == null || values.Length == 0)
                return;

            Range firstCell = null;
            Range lastCell = null;
            Range range = null;

            try
            {
                firstCell = (Range)worksheet.Cells[startRow, column];

                lastCell = (Range)worksheet.Cells[
                    startRow + values.Length - 1,
                    column];

                range = worksheet.Range[firstCell, lastCell];

                object[,] columnValues = new object[values.Length, 1];

                for (int i = 0; i < values.Length; i++)
                    columnValues[i, 0] = values[i];

                range.Value2 = columnValues;
            }
            finally
            {
                ReleaseComObject(range);
                ReleaseComObject(lastCell);
                ReleaseComObject(firstCell);
            }
        }

        public static void WriteFileInformation(
                            Worksheet worksheet,
                            string testKind,
                            string termKind,
                            string gradeData,
                            string yearData,
                            int fileType,
                            short grade,
                            byte termId)
        {
            SetColumnValues(
                            worksheet,
                            30,
                            1,
                            testKind,
                            termKind,
                            gradeData,
                            yearData,
                            fileType,
                            grade,
                            termId);
        }
        public static void WriteSimpleRows(
                                Worksheet worksheet,
                                System.Data.DataTable dataTable,
                                int startRow,
                                params int[] sourceColumns)
            {
            int row = startRow;

            foreach (DataRow dataRow in dataTable.Rows)
            {
                SetRowValues(
                    worksheet,
                    row,
                    1,
                    sourceColumns.Select(column => dataRow[column].ToString()).ToArray());

                row++;
            }
        }

        public static void ReleaseComReference(object obj)
        {
            if (obj != null && Marshal.IsComObject(obj))
            {
                Marshal.ReleaseComObject(obj);
            }
        }
    }
}