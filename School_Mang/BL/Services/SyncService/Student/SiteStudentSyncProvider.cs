using School_Mang.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace School_Mang.BL.Services.SyncService.Student
{
    public class SiteStudentSyncProvider
    {
        private readonly DataAcceseLayer _dal;

        public SiteStudentSyncProvider()
        {
            _dal = new DataAcceseLayer();
        }


        public void AddStudents(DataTable students)
        {
            _dal.ExecuteTableParameter(
                "SP_Add_Students_Sync",
                "@Students",
                students,
                "dbo.StudentSyncType"
            );
        }


        public void UpdateStudents(DataTable students)
        {
            _dal.ExecuteTableParameter(
                "SP_Update_Students_Sync",
                "@Students",
                students,
                "dbo.StudentSyncType"
            );
        }


        public void DeleteStudents(DataTable students)
        {
            _dal.ExecuteTableParameter(
                "SP_Delete_Students_Sync",
                "@Students",
                students,
                "dbo.StudentSyncType"
            );
        }
    }
}
