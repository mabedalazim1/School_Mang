using System;
using System.Data;
using School_Mang.DAL;

namespace School_Mang.BL.Services.STD
{
    public class GetDataService
    {
        private readonly DataAcceseLayer _dal;
        public GetDataService() 
        { 
            _dal = new DataAcceseLayer();
        }

        public DataTable Get_Grade_Desc(int grade_id)
            => _dal.ExecQuery("SP_Get_Grade_Desc",
                SqlParam.Int("@grade_id", grade_id));

        public DataTable Get_Year_Desc(int year)
           => _dal.ExecQuery("SP_Get_Year_Desc",
               SqlParam.Int("@year", year));

        public DataTable Get_Year_By_Id(int yearId)
            => _dal.ExecQuery("SP_Get_Year_By_Id",
                SqlParam.Int("@Year_Id", yearId));

        

        public DataTable Search_School_year_Data(int Year_Id, int Grade_Id, int Class_Id, string std_name)
            => _dal.ExecQuery("SP_Search_School_year_Data",
                SqlParam.Int("@Year_Id", Year_Id),
                SqlParam.Int("@Grade_Id", Grade_Id),
                SqlParam.Int("@Class_Id", Class_Id),
                SqlParam.NVar("@std_name", std_name, 200));

        
        public DataTable Get_OSRA_STAT_FEMALE()
            => _dal.ExecQuery("SP_OSRA_STAT_FEMALE", null);

        public DataTable Get_OSRA_STAT_MALE()
            => _dal.ExecQuery("SP_OSRA_STAT_MALE", null);

        public DataTable GET_Code_Std_Grade(int Grade_Id, int Year_Id, string Is_Valied)
        {
            return _dal.ExecQuery("SP_GET_Code_Std_Grade",
                SqlParam.Int("@Grade_Id", Grade_Id),
                SqlParam.Int("@Year_Id", Year_Id),
                SqlParam.NVar("@Is_Valied", Is_Valied, 5)
            );
        }
    }
}
