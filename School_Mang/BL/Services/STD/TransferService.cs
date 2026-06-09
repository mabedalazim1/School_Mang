using School_Mang.BL.DTO;
using School_Mang.BL.Models;
using System;
using System.Data;
using School_Mang.BL.Common;

namespace School_Mang.BL.Services.STD
{
    public class TransferService
    {
        private readonly BL.STD.CLS_STD _std;
        private readonly StudentService _studentService;
        private readonly GetDataService _getData;
        public TransferService()
        {
            _std = new BL.STD.CLS_STD();
            _studentService = new StudentService();
            _getData = new GetDataService();
        }
        public DataTable SearchTransferData(int gradeId, int statusId, string searchText)
        {
            return _std.Search_Trans_Data(gradeId, statusId, searchText);
        }
        public bool HasTransfers()
        {
            var current = _std.GET_Trans_Data(0, 3, 7);
            var next = _std.GET_Trans_Data(0, 4);

            return current.Rows.Count > 0 || next.Rows.Count > 0;
        }

        public TransferData GetTransferData(string stdCode)
        {
            byte transferSavedStatus = 0;
            DataTable dt;
            DataTable dtTransData;
            dt = _std.GET_Trans_By_Code(stdCode);
            if (dt.Rows.Count != 0)
            {
                var row = dt.Rows[0];
                var TransCode = row["Transfer_code"].ToString();
                dtTransData = _std.Get_Tahewl_Data(TransCode);
                if (dtTransData.Rows.Count > 0)
                {
                    transferSavedStatus =
                        Convert.ToByte(dtTransData.Rows[0]["Transfer_status"]);
                }
                return new TransferData
                {
                    TransferCode = TransCode,
                    GradeId = Convert.ToInt32(row["Grade_Id"]),
                    YearId = Convert.ToInt32(row["Year_Id"]),
                    TransferSavedStatus = transferSavedStatus,
                };
            }
            else
            {
                return null;
            }
        }
        public string GetTransCod(bool currentYearData)
        {
            // Trans Code
            string current_year;
            string year = Properties.Settings.Default.MyYear.ToString().Substring(2, 2);
            if (currentYearData)
            {
                current_year = year;
            }
            else
            {
                current_year = (Convert.ToInt32(year) + 1).ToString();
            }

            DataTable dt = _std.Get_Trans_Code(current_year);
            if (dt.Rows.Count == 0 || dt.Rows[0]["Max_Trans_Code"] == DBNull.Value)
            {

                return current_year + "001";
            }
            else
            {
                int next = Convert.ToInt32(dt.Rows[0]["Max_Trans_Code"]) + 1;
                return next.ToString();
            }

        }
        public bool IsStudentRegistered(string std_code, int year)
        {
           var  dt = _studentService.Verify_Std_School_Code(std_code, year);
            if (dt.Rows.Count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private int CalculateGrade(int grade)
        {
            if (grade == 10)
                return 11;
            else if (grade == 11)
                return 1;
            else if (grade >= 1 && grade <= 8)
                return grade + 1;
            else
                return grade;
        }

        private void ValidateTransferRequest(TransferRequest request)
        {
            if (!request.IsValidStudent)
                throw new Exception("Invalid data");

            if (!request.IsSchoolTransfer)
            {
                if (!IsStudentRegistered(request.StdCode, request.Year + 1))
                {
                    if (request.IsAfterChecked)
                        throw new Exception("غير مقيد بالعام الجديد");
                }
            }
        }

        private TransferContext BuildTransferContext(TransferRequest request)
        {
            var context = new TransferContext
            {
                RequestYear = request.Year,
                NewGrade = request.Grade
            };

            if (request.IsBeforeChecked)
            {
                context.TransAfterYear = true;
                context.RequestYear = request.Year - 1;

                context.NewStudentInThisYear =
                    !IsStudentRegistered(request.StdCode, context.RequestYear);
            }
            else
            {
                context.NewGrade = CalculateGrade(request.Grade);
                context.TransAfterYear = false;
            }
            if (request.IsSchoolTransfer)
            {
                context.NewGrade = request.Grade;
                context.RequestYear = request.Year +1;
            }

            return context;
        }
        private void DeleteFutureYearDataIfNeeded(TransferRequest request,
                                                  TransferContext context)
        {
            if (!IsStudentRegistered(
                request.StdCode,
                context.RequestYear + 2))
            {
                return;
            }

            _studentService.Delete_School_Std_Data(
                request.StdCode,
                context.RequestYear + 2);
        }
        private void SaveTransfer( TransferRequest request,
                                   TransferContext context)
        {
            var transCode = GetTransCod(request.CurrentYearData);

            _std.Add_Transfers_Data(
                transCode,
                request.StdCode,
                request.ToSchool,
                request.TransferStatus,
                context.RequestYear,
                request.GuardianName,
                request.Reason,
                request.Rosom,
                request.Kotob,
                request.Address,
                context.NewGrade,
                context.TransAfterYear,
                context.NewStudentInThisYear
            );

            var data = GetTransferData(request.StdCode);

            if (data == null && !context.NewStudentInThisYear)
                throw new Exception("لم يتم الحفظ");
        }

        public void CreateTransfer(TransferRequest request)
        {
            ValidateTransferRequest(request);

            if (request.IsUpdate)
                return;

            var context = BuildTransferContext(request);

            SaveTransfer(request, context);

            DeleteFutureYearDataIfNeeded(request, context);
        }
       
        public void UpdateTransfer(TransferRequest request)
        {
            _std.Update_Trans_Data(
                request.TransCode,
                request.ToSchool,
                request.GuardianName,
                request.Reason,
                request.Rosom,
                request.Kotob,
                request.Address
            );
        }
        public void DeleteTransfer(DeleteTransferRequest request)
        {
            int classId = request.ClassId;

            if (request.GradeId > 6)
                classId += 2;
            else
                classId += 3;

            int newYear = request.Year;

            if (request.StatusId == 4)
            {
                newYear = 0;
            }

            int stdFound = Convert.ToInt32(
                _std.Get_Count_Trans_Std(newYear, request.StdCode)
                .Rows[0][0]);

            _std.Delete_Transfers_Data(
                request.TransferCode,
                request.StdCode,
                request.CurrentYear,
                request.GradeId,
                classId,
                newYear,
                stdFound,
                request.StatusId == 4 ? 1 : 0,
                request.TransAfterYear
            );
        }
        public TransferReportData GetTransferReportData(
                                                        string stdCode,
                                                        bool transAfterYear)
        {

            var data = GetTransferData(stdCode);
            if (data == null)
                return null;
        
            int sana = data.YearId + 2021;

            // To School
            string yearDataToSchool =
                _getData.Get_Year_Desc(sana)
                .Rows[0]["YearDesc"]
                .ToString();

            string[] yearToSchool =
                yearDataToSchool.Split('-');

            string yearDescToSchool =
                yearToSchool[1] + "-" + yearToSchool[0];

            // From School
            string yearData =
                _getData.Get_Year_Desc(sana + 1)
                .Rows[0]["YearDesc"]
                .ToString();

            string[] year =
                yearData.Split('-');

            string yearDesc =
                year[1] + "-" + year[0];

            // Grade
            string gradeDesc;
                gradeDesc =
                    _getData.Get_Grade_Desc(data.GradeId)
                    .Rows[0]["GradeDesc"]
                    .ToString();
           
            return new TransferReportData
            {
                StudentName = "",
                TransferCode = data.TransferCode,
                ToSchoolYearDesc = yearDescToSchool,
                FromSchoolYearDesc = yearDesc,
                GradeDesc = gradeDesc,
                TransferSavedStatus = data.TransferSavedStatus
            };
        }


        public void SahbMalf(string stdCode, int year, bool CurrentYearData, int status)
        {
            if (!CurrentYearData) 
            {
                if (VerifayStudent(stdCode, year))
                {
                   throw new Exception("لا يمكن سحب ملف للطالب المسجل فى العام السابق .. !");
                }
            }
            if (status == 3 || status == 4 || status == 7) 
            {
                throw new Exception("لا يمكن سحب ملف للطالب المحول .. !");
            }
            int newYear = year + 1;
            _studentService.Delete_School_Std_Data(
                stdCode,
                newYear);
        }

        private bool VerifayStudent(string stdCode, int year)
        {
            DataTable dt = _studentService.Verify_Std_School_Code(stdCode, year);
            return dt != null && dt.Rows.Count > 0;
        }

        public void RestoreSahbMalf(int year,
                                            string stdCode,
                                            int currentGrade,
                                            int currentClassId)
        {
            if (currentGrade == 9)
                return;

            int newGrade = 0;
            int newClassId = 0;

            switch (currentGrade)
            {
                case 10:
                    newGrade = 11;
                    newClassId = currentClassId + 2;
                    break;

                case 11:
                    newGrade = 1;
                    newClassId = currentClassId + 2;
                    break;

                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                    newGrade = currentGrade + 1;
                    newClassId = currentClassId + 3;
                    break;

                case 6:
                case 7:
                case 8:
                    newGrade = currentGrade + 1;
                    newClassId = currentClassId + 2;
                    break;
            }

            DataTable dtSchoolData =
                _studentService.Get_School_year_Data(year, 0, 0);

            if (dtSchoolData.Rows.Count == 0)
                return;

            _studentService.Add_School_Std_Data(
                stdCode,
                year,
                newGrade,
                2,
                newClassId);
        }

    }
}



internal class TransferContext
{
    public int RequestYear { get; set; }
    public int NewGrade { get; set; }
    public bool TransAfterYear { get; set; }
    public bool NewStudentInThisYear { get; set; }
}