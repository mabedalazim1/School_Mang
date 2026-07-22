using School_Mang.BL.Common.Helper;
using School_Mang.BL.DTO;
using School_Mang.BL.Models;
using School_Mang.DAL;
using System;
using System.Data;
using System.Linq;

namespace School_Mang.BL.Services.STD
{
    public class TransferService
    {
        private readonly DataAcceseLayer _dal;
        private readonly StudentService _studentService;
        private readonly GetDataService _getData;
        public TransferService()
        {
            _dal = new DataAcceseLayer();
            _studentService = new StudentService();
            _getData = new GetDataService();
        }
        public DataTable SearchTransferData(int gradeId, int statusId, string searchText)
        {
            return Search_Trans_Data(gradeId, statusId, searchText);
        }
        public bool HasTransfers()
        {
            var current = GET_Trans_Data(0, 3, 7);
            var next = GET_Trans_Data(0, 4);

            return current.Rows.Count > 0 || next.Rows.Count > 0;
        }

        public TransferData GetTransferData(string stdCode)
        {
            byte transferSavedStatus = 0;
            DataTable dt;
            DataTable dtTransData;
            dt = GET_Trans_By_Code(stdCode);
            if (dt.Rows.Count != 0)
            {
                var row = dt.Rows[0];
                var TransCode = row["Transfer_code"].ToString();
                dtTransData = Get_Tahewl_Data(TransCode);
                if (dtTransData.Rows.Count > 0)
                {
                    transferSavedStatus =
                        Convert.ToByte(dtTransData.Rows[0]["Transfer_status"]);
                }
                return new TransferData
                {
                    StudentName = "",
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

            DataTable dt = Get_Trans_Code(current_year);
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

            Add_Transfers_Data(
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
           Update_Trans_Data(
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

            int newYear;

            if (request.StatusId == 4)
            {
                newYear = 0;
            }
            else if (request.StatusId == 3 || request.StatusId == 7)
            {
                newYear = request.Year + 1;
            }
            else
            {
                newYear = request.Year;
            }


            int stdFound = Convert.ToInt32(
               Get_Count_Trans_Std(newYear, request.StdCode)
                .Rows[0][0]);

            Delete_Transfers_Data(
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
        public DataTable GET_Trans_Data(int Grade_Id, params int[] statusIds)
        {
            bool hasTransferStatus = statusIds.Contains(3) || statusIds.Contains(7);

            int year = hasTransferStatus
               ? Convert.ToInt32(Globals.My_Year - 1)
                : Convert.ToInt32(Globals.My_Year);
            string statusList = string.Join(",", statusIds);

            return _dal.ExecQuery("SP_GET_Trans_Data",
                SqlParam.Int("@Year_Id", year),
                SqlParam.Int("@Grade_Id", Grade_Id),
                SqlParam.NVar("@Status_Ids", statusList)
            );
        }
        private DataTable Search_Trans_Data(int Grade_Id, int Status_Id, string std_name)
        {
            int year = (Status_Id == 3)
                ? Convert.ToInt32(Globals.My_Year - 1)
                : Convert.ToInt32(Globals.My_Year);

            return _dal.ExecQuery("SP_Search_Trans_Data",
                SqlParam.Int("@Year_Id", year),
                SqlParam.Int("@Grade_Id", Grade_Id),
                SqlParam.Int("@Status_Id", Status_Id),
                SqlParam.NVar("@std_name", std_name, 200));
        }
        private DataTable GET_Trans_By_Code(string std_code)
           => _dal.ExecQuery("SP_GET_Trans_By_Code",
               SqlParam.NVar("@std_code", std_code, 20));

        private DataTable Get_Tahewl_Data(string Transfer_code)
          => _dal.ExecQuery("SP_Get_Tahewl",
              SqlParam.NVar("@Transfer_code", Transfer_code, 20));

        private DataTable Get_Trans_Code(string year)
            => _dal.ExecQuery("SP_Get_Trans_Code",
                SqlParam.NVar("@year", year, 2));

        private void Add_Transfers_Data(string Transfer_code,
                               string std_code,
                               string Transfer_School,
                               int Transfer_status,
                               int Year_Id,
                               string Guardian_name,
                               string Transfer_reason,
                               byte Resom, byte Kotob,
                               string adrs, int New_Grade,
                               bool Trans_After_Year,
                               bool NewStudentInThisYear)
        {
            _dal.ExecNonQuery("SP_Add_Transfers_Data",
                SqlParam.NVar("@Transfer_code", Transfer_code, 20),
                SqlParam.NVar("@std_code", std_code, 20),
                SqlParam.NVar("@Transfer_School", Transfer_School, 100),
                SqlParam.Int("@Transfer_status", Transfer_status),
                SqlParam.Int("@Year_Id", Year_Id),
                SqlParam.NVar("@Guardian_name", Guardian_name, 50),
                SqlParam.NVar("@Transfer_reason", Transfer_reason, 50),
                SqlParam.Byte("@Resom", Resom),
                SqlParam.Byte("@Kotob", Kotob),
                SqlParam.NVar("@adrs", adrs, 1000),
                SqlParam.NVar("@Created_by", Properties.Settings.Default.user_name, 15),
                SqlParam.NVar("@Updated_by", Properties.Settings.Default.user_name, 15),
                SqlParam.Int("@New_Grade", New_Grade),
                SqlParam.Bit("@Trans_After_Year", Trans_After_Year),
                SqlParam.Bit("@NewStudentInThisYear", NewStudentInThisYear)
            );
        }

        private void Update_Trans_Data(int Transfer_code,
                                      string Transfer_School,
                                      string Guardian_name,
                                      string Transfer_reason,
                                      byte Resom, byte Kotob,
                                      string adrs)
        {
            _dal.ExecNonQuery("SP_Update_Trans_Data",
                SqlParam.Int("@Transfer_code", Transfer_code),
                SqlParam.NVar("@Transfer_School", Transfer_School, 100),
                SqlParam.NVar("@Guardian_name", Guardian_name, 50),
                SqlParam.NVar("@Transfer_reason", Transfer_reason, 50),
                SqlParam.Byte("@Resom", Resom),
                SqlParam.Byte("@Kotob", Kotob),
                SqlParam.NVar("@adrs", adrs, 1000),
                SqlParam.NVar("@Updated_by", Properties.Settings.Default.user_name, 15)
            );
        }

        private DataTable Get_Count_Trans_Std(int new_year, string std_code)
        {
            string query = @"SELECT COUNT(std_code) AS std_code
                     FROM School_Std_Data
                     WHERE Year_Id = @Year_Id
                     AND std_code = @std_code";

            return _dal.Query(query,
                SqlParam.Int("@Year_Id", new_year),
                SqlParam.NVar("@std_code", std_code, 20)
            );
        }
        private void Delete_Transfers_Data(int Transfer_code,
                                  string std_code,
                                  int Year_Id,
                                  int Grade_Id,
                                  int Class_Id,
                                  int new_year,
                                  int std_found,
                                  int To_School,
                                  bool Trans_After_Year)
        {
            _dal.ExecNonQuery("SP_Delete_Transfers_Data",
                SqlParam.Int("@Transfer_code", Transfer_code),
                SqlParam.NVar("@std_code", std_code, 20),
                SqlParam.Int("@Year_Id", Year_Id),
                SqlParam.Int("@Grade_Id", Grade_Id),
                SqlParam.Int("@Class_Id", Class_Id),
                SqlParam.NVar("@Updated_by", Properties.Settings.Default.user_name, 15),
                SqlParam.Int("@new_year", new_year),
                SqlParam.Int("@std_found", std_found),
                SqlParam.Int("@To_School", To_School),
                SqlParam.Bit("@Trans_After_Year", Trans_After_Year)
            );
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