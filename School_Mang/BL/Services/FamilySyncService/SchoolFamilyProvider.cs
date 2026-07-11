using School_Mang.BL.DTO;
using School_Mang.DAL;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Mang.BL.Services.FamilySyncService
{
    public class SchoolFamilyProvider
    {
        private readonly DataAcceseLayer _dal;

        public SchoolFamilyProvider()
        {
            _dal = new DataAcceseLayer();
        }
        public DataTable GetCurrentFamilies(int yearId)
        {
            return _dal.ExecQuery(
                "SP_Get_Current_Families",
                SqlParam.Int("@YearId", yearId));
        }
    }
}