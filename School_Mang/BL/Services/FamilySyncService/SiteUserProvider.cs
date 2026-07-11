using School_Mang.BL.Enums;
using School_Mang.DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace School_Mang.BL.Services.FamilySyncService
{
    public class SiteUserProvider
    {
        private readonly SiteAccessLayer _site;

        public SiteUserProvider()
        {
            _site = new SiteAccessLayer();
        }

        public bool Exists(UserSearchField field, string value)
        {
            string columnName;

            switch (field)
            {
                case UserSearchField.UserName:
                    columnName = "username";
                    break;

                case UserSearchField.OsraId:
                    columnName = "osraId";
                    break;

                default:
                    throw new ArgumentException("حقل البحث غير صحيح.");
            }

            string sql = $"SELECT COUNT(*) FROM users WHERE {columnName} = @value";

            int count = _site.ExecuteScalarQuery<int>(
                sql,
                new SqlParameter("@value", value)
            );

            return count > 0;
        }

        public DataTable GetAllFamilies()
        {
            return _site.ExecQuery("SP_Get_Site_Student_Families");
        }

        public HashSet<string> GetAllUserNames()
        {
            DataTable dt = _site.Query(
                "SELECT username FROM users");

            HashSet<string> result =
                new HashSet<string>(
                    StringComparer.OrdinalIgnoreCase);

            foreach (DataRow row in dt.Rows)
            {
                string userName = row["username"].ToString();

                if (!string.IsNullOrWhiteSpace(userName))
                    result.Add(userName);
            }

            return result;
        }
    }
}
