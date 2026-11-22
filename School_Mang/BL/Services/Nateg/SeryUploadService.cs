
using School_Mang.BL.Common.Helper;
using School_Mang.BL.ExcelUtils;
using School_Mang.BL.NATEG;
using System;
using System.Data;
using Excel = Microsoft.Office.Interop.Excel;

namespace School_Mang.BL.Services.Nateg
{
    public class SeryUploadService
    {
        private readonly CLS_NATEG _nateg = new CLS_NATEG();

        public int UploadSeryData(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
                throw new ArgumentException("مسار الملف غير صالح.");

            DataTable dt = ReadSeryData(filePath);

            foreach (DataRow row in dt.Rows)
            {
                int golos = Convert.ToInt32(row["Golos"]);
                int sery = Convert.ToInt32(row["Sery"]);

                _nateg.Update_Sery_Data(golos, sery);
            }

            return dt.Rows.Count;
        }

        private DataTable ReadSeryData(string filePath)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("Golos", typeof(int));
            dt.Columns.Add("Sery", typeof(int));
            dt.Columns.Add("Year_Id", typeof(int));

            using (ExcelWorkbookSession session =
                   new ExcelWorkbookSession(filePath))
            {
                Excel.Worksheet worksheet = session.Worksheet;

                Excel.Range usedRange = null;

                try
                {
                    usedRange = worksheet.UsedRange;

                    int rowCount = usedRange.Rows.Count;

                    for (int i = 4; i <= rowCount; i++)
                    {
                        DataRow row = dt.NewRow();

                        row["Golos"] = Convert.ToInt32(
                            ExcelHelper.GetCellValue(usedRange, i, 3));

                        row["Sery"] = Convert.ToInt32(
                            ExcelHelper.GetCellValue(usedRange, i, 4));

                        row["Year_Id"] =
                            Properties.Settings.Default.year_cod;

                        dt.Rows.Add(row);
                    }
                }
                finally
                {
                    ExcelHelper.ReleaseComReference(usedRange);
                }
            }

            return dt;
        }
    }
}
