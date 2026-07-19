using School_Mang.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace School_Mang.BL.Services.SyncService.Student
{
   public class StudentArchiveService
   {
        private readonly DataAcceseLayer _dal;

        public StudentArchiveService()
        {
            _dal = new DataAcceseLayer();
        }
          public int Archive(int yearId)
        {
            DataTable table = _dal.ExecQuery(
                "SP_Archive_Students",
                new SqlParameter("@Year_Id", yearId)
            );


            if (table.Rows.Count == 0)
                return 0;


            return Convert.ToInt32(
                table.Rows[0]["ArchivedCount"]
            );
        }

        public bool Exists(string stdCode, int yearId)
        {
            DataTable table = _dal.ExecQuery(
                "SP_Student_Exists_In_Archive",
                new SqlParameter("@StdCode", stdCode),
                new SqlParameter("@Year_Id", yearId)
            );

            return table.Rows.Count > 0;
        }
    }
}
