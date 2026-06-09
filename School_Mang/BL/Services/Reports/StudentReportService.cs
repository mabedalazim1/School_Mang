using School_Mang.BL.Services.STD;
using School_Mang.BL.STD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Mang.BL.Services.Reports
{
    public class StudentReportService
    {
        private readonly RPT.REPORT_CONNECTION _rpt;
        private readonly CLS_STD _std;
        private readonly GetDataService _getData = new GetDataService();

        public StudentReportService()
        {
            _rpt = new RPT.REPORT_CONNECTION();
            _std = new CLS_STD();
        }

        public class Result
        {
            public bool Success { get; set; }
            public string Message { get; set; }

            public static Result Ok() => new Result { Success = true };
            public static Result Fail(string msg) => new Result { Success = false, Message = msg };
        }

        public void OpenDegreeStatement(int year, int gradeId, string stdCode)
        {
            _rpt.OpenDegree_Statement(year, gradeId, stdCode);
        }

        public void OpenCountStd(int year)
        {
            _rpt.OpenCount_Std(year);
        }

        public Result PrintKaema(int yearId, int gradeId)
        {
            try
            {
                string gradeDesc;

                if (gradeId == 0)
                {
                    gradeDesc = "كل الصفوف";
                }
                else
                {
                    var dt = _getData.Get_Grade_Desc(gradeId);

                    if (dt.Rows.Count == 0)
                        return Result.Fail("لا يوجد وصف للصف الدراسي");

                    gradeDesc = dt.Rows[0]["GradeDesc"].ToString();
                }

                var data = _std.Get_Kaema_Data(yearId, 0);

                if (data.Rows.Count == 0)
                    return Result.Fail("لا توجد بيانات مسجلة .. يرجى التأكد من العام الدراسى !");

                _rpt.Open_Kaema_Report(yearId, gradeId, gradeDesc);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                return Result.Fail(ex.Message);
            }
        }
        public Result PrintSegel(int yearId, int gradeId =0)
        {
            if (_std.Get_Segel_Data(yearId, gradeId).Rows.Count == 0)
                return Result.Fail("لا توجد بيانات مسجلة لهذا العام .. !");

            _rpt.OpenSegel(yearId, gradeId);

            return Result.Ok();
        }
        public Result PrintTadargSen(int yearId, int gradeId, bool sort)
        {
            if (_std.Get_Tadrg_Sen(yearId, gradeId).Rows.Count == 0)
                return Result.Fail("لا توجد بيانات مسجلة للصف المحدد .. !");

            _rpt.OpenTadargSen(yearId, gradeId, sort);

            return Result.Ok();
        }
        public Result Print41New(int yearId, int gradeId =0)
        {
            if (_std.Get_Segel_Data(yearId, gradeId).Rows.Count == 0)
                return Result.Fail("لا توجد بيانات مسجلة .. !");

            _rpt.OpenMostgdin_41(yearId, gradeId);

            return Result.Ok();
        }
        public Result PrintTransfer(int yearId, int gradeId = 0, params int[] statuses)
        {
            if (statuses.Length == 0)
                return Result.Fail("يجب تحديد حالة واحدة على الأقل.");

            if (_std.GET_Trans_Data_By_Year(yearId, gradeId, statuses).Rows.Count == 0)
                return Result.Fail("لا توجد بيانات مسجلة .. !");

            _rpt.OpenTahewl_Data(yearId ,gradeId, statuses);

            return Result.Ok();
        }
    }
}