using School_Mang.BL.DTO;
using School_Mang.BL.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace School_Mang.BL.Services.STD
{
    public class TransferService
    {
        private readonly BL.STD.CLS_STD _std;
        private NavigationContext _context;
        public TransferService()
        {
            _std = new BL.STD.CLS_STD();
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
        public string TransCod(bool currentYearData)
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
        public Boolean VerifyStdSchoolCode(string std_code, int year)
        {
            DataTable Dt;
            Dt = _std.Verify_Std_School_Code(std_code, year);
            if (Dt.Rows.Count == 0)
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
        public void CreateTransfer(TransferRequest request)
        {
            int year = request.Year;
            bool transAfterYear = false;

            // Verify
            if (!request.IsValidStudent)
                throw new Exception("Invalid data");

            if (!request.IsUpdate)
            {
                if (!request.IsSchoolTransfer)
                {
                    if (!VerifyStdSchoolCode(request.StdCode, year + 1))
                    {
                        if (request.IsAfterChecked)
                            throw new Exception("غير مقيد بالعام الجديد");
                    }
                }

                // Year logic
                if (request.IsBeforeChecked)
                {
                    transAfterYear = true;
                    year -= 1;
                }
                else
                {
                    year = CalculateGrade(request.Grade);
                }

                var transCode = TransCod(request.CurrentYearData);

                _std.Add_Transfers_Data(
                    transCode,
                    request.StdCode,
                    request.ToSchool,
                    request.TransferStatus,
                    year,
                    request.GuardianName,
                    request.Reason,
                    request.Rosom,
                    request.Kotob,
                    request.Address,
                    request.Grade,
                    transAfterYear
                );
                var data = GetTransferData(request.StdCode);
                if (data == null)
                    throw new Exception("لم يتم الحفظ");

                _std.Delete_School_Std_Data(request.StdCode, year + 2);
            }
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
    }
}