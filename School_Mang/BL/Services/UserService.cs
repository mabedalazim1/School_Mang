using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace School_Mang.BL.Services
{
    public class UserService
    {
        private readonly BL.USERS _users;

        public UserService()
        {
            _users = new BL.USERS();
        }

        public DataTable GetUserPermission(int userId)
        {
            return _users.Get_User_Permission(userId);
        }

        public bool IsAdmin(int userId)
        {
            var dt = _users.Get_User_Permission(userId);

            if (dt.Rows.Count == 0)
                return false;

            var row = dt.Rows[0];

            return row["role_id"].ToString() == "1" &&
                   row["permission_id"].ToString() == "1";
        }
    }
}