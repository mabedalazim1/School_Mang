using System;
using School_Mang.BL.DTO;

namespace School_Mang.BL.SITE
{
    public class ExcelExportService
    {
        public ExportInfo GetExportInfo(string worksheetName, byte type)
        {
            ExportInfo info = new ExportInfo();

            info.Title = worksheetName;
            info.FileName = worksheetName + ".xlsx";

            switch (type)
            {
                case 10:
                case 11:
                    info.TemplateFile = AppDomain.CurrentDomain.BaseDirectory +
                                        @"Excel\Users\" + worksheetName + ".xlsx";

                    info.DefaultFolder = Properties.Settings.Default.save_Users_path;
                    break;

                default:
                    info.TemplateFile = AppDomain.CurrentDomain.BaseDirectory +
                                        @"Excel\Lessons\" + worksheetName + ".xlsx";

                    info.DefaultFolder = Properties.Settings.Default.save_Lessons_path;
                    break;
            }

            return info;
        }
        public bool Export(string worksheetName,
                            string saveAsLocation,
                            ExportInfo info)
        {

            SiteExcelUtlity excel = new SiteExcelUtlity();

            return excel.WriteLessonsDataToExcel(
                worksheetName,
                saveAsLocation,
                info.Title,
                info.TemplateFile);
        }
    }
}
