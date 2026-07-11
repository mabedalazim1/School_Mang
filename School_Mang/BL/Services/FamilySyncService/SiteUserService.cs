using School_Mang.DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Mang.BL.Services.FamilySyncService
{
    public class SiteUserService
    {
        private readonly SiteAccessLayer _site;

        public SiteUserService()
        {
            _site = new SiteAccessLayer();
        }

        public void UpdateActiveStatus(string userName, bool isActive)
        {
            string sql = @"
        UPDATE users
        SET IsActive = @IsActive
        WHERE username = @username";

            _site.ExecuteNonQuery(
                sql,
                new SqlParameter("@IsActive", isActive),
                new SqlParameter("@username", userName));
        }
    }
}
