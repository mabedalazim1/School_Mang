using System.Data;
using School_Mang.DAL;

namespace School_Mang.BL.Services.STD
{
    public class VerifyService
    {
        private readonly DataAcceseLayer _dal;
        public VerifyService() 
        {
            _dal = new DataAcceseLayer();
        }

        public DataTable Verify_Std_Code(string std_code)
           => _dal.ExecQuery("SP_Verify_Std_Code",
               SqlParam.NVar("@std_code", std_code, 20));

        public DataTable Verify_Std_Nat(string std_nat, string std_code = "0")
           => _dal.ExecQuery("SP_Verify_Std_Nat",
               SqlParam.NVar("@std_nat", std_nat, 14),
               SqlParam.NVar("@std_code", std_code, 20));

        public DataTable Verify_Osra_Nat(string nat, int id)
            => _dal.ExecQuery("SP_Verify_Osra_Nat",
                SqlParam.NVar("@nat", nat, 14),
                SqlParam.Int("@osra_Id", id));



        public DataTable Verify_Osra_Code(string Year)
            => _dal.ExecQuery("SP_Verify_Osra_Code",
                SqlParam.NVar("@Year", Year, 2));
    }
}
