using System.Data;
using School_Mang.BL.STD;
using School_Mang.DAL;

namespace School_Mang.BL.Services
{
    public class LookupService
    {
        private readonly DataAcceseLayer _dal;
        public LookupService()
        {
            _dal = new DataAcceseLayer();
        }

        public DataTable Get_years(int year = 0)
        {
            return _dal.ExecQuery("SP_GETYEARS",
                SqlParam.Int("@year", year == 0 ? Properties.Settings.Default.MyYear : year));
        }
        public DataTable Get_genders()
           => _dal.ExecQuery("SP_GETGENDERS", null);

        public DataTable Get_grades(string frist_classes = "no")
            => _dal.ExecQuery("SP_GETGRADES",
                SqlParam.NVar("@frist_classes", frist_classes, 3));

        public DataTable Get_nationalities()
           => _dal.ExecQuery("SP_NATIONLITIES", null);

        public DataTable Get_stdStat()
           => _dal.ExecQuery("SP_STDSTAT", null);

        public DataTable Get_religion()
           => _dal.ExecQuery("SP_RELIGIONS", null);
        public DataTable Get_Grad_Data(int Grade_Id)
            => _dal.ExecQuery("SP_Get_Class_Id",
                SqlParam.Int("@Grade_Id", Grade_Id));


    }
}
