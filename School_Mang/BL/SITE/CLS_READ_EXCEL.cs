using Microsoft.Office.Interop.Excel;
using System;
using System.Data;
using System.Runtime.InteropServices;

namespace School_Mang.BL.SITE
{
    public class CLS_READ_EXCEL
    {
        public System.Data.DataTable ReadExcelData(
            string excel_file_name,
            ExcelColumn[] columns,
            string fileType,
            CLS_MANGE_SITE mangeSite,
            Action<string> showError,
            System.Action waitStart,
            System.Action waitEnd)
        {
            var dt = new System.Data.DataTable();

            Application excel = null;
            Workbook workbook = null;
            Worksheet sheet = null;
            Range usedRange = null;

            try
            {
                waitStart?.Invoke();

                excel = new Application
                {
                    Visible = false,
                    DisplayAlerts = false
                };

                workbook = excel.Workbooks.Open(excel_file_name);
                sheet = (Worksheet)workbook.Sheets[1];
                usedRange = sheet.UsedRange;

                // =========================
                // Metadata
                // =========================
                int row_no;
                string file_name;

                if (fileType == "mlutiquestion")
                {
                    row_no = Convert.ToInt32(sheet.Cells[1, 15].Value2 ?? 0);
                    file_name = Convert.ToString(sheet.Cells[1, 17].Value2 ?? "");
                }
                else
                {
                    row_no = Convert.ToInt32(sheet.Cells[1, 11].Value2 ?? 0);
                    file_name = Convert.ToString(sheet.Cells[1, 13].Value2 ?? "");
                }

                if (file_name != fileType)
                {
                    showError?.Invoke("❌ نوع ملف غير صحيح");
                    return null;
                }

                // =========================
                // Columns
                // =========================
                foreach (var col in columns)
                    dt.Columns.Add(col.Name);

                int rowCount = row_no + 3;

                // 🔥 تحسين الأداء: cache array
                var excelRange = usedRange.Value2;

                for (int i = 4; i <= rowCount; i++)
                {
                    var row = dt.NewRow();

                    foreach (var col in columns)
                    {
                        object val = (excelRange as object[,])?[i, col.Index];

                        if (val != null)
                        {
                            if (col.DataType == typeof(int))
                            {
                                int temp;
                                if (int.TryParse(val.ToString(), out temp))
                                    val = temp;
                                else
                                    val = DBNull.Value;
                            }
                            else if (col.DataType == typeof(byte))
                            {
                                byte temp;
                                if (byte.TryParse(val.ToString(), out temp))
                                    val = temp;
                                else
                                    val = DBNull.Value;
                            }
                            else if (col.DataType == typeof(string))
                            {
                                val = val.ToString().Trim();
                            }
                        }

                        row[col.Name] = val ?? DBNull.Value;
                    }

                    dt.Rows.Add(row);
                }

                return dt;
            }
            catch (Exception ex)
            {
                showError?.Invoke("❌ Excel Error: " + ex.Message);
                return null;
            }
            finally
            {
                try { workbook?.Close(false); } catch { }

                if (workbook != null) Marshal.ReleaseComObject(workbook);
                if (sheet != null) Marshal.ReleaseComObject(sheet);
                if (usedRange != null) Marshal.ReleaseComObject(usedRange);

                if (excel != null)
                {
                    try { excel.Quit(); } catch { }
                    Marshal.ReleaseComObject(excel);
                }

                GC.Collect();
                GC.WaitForPendingFinalizers();

                waitEnd?.Invoke();
            }
        }
    }
}