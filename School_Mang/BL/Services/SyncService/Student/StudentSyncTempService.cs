using School_Mang.BL.Enums;
using School_Mang.DAL;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using School_Mang.BL.Services.SyncService.Models;

namespace School_Mang.BL.Services.SyncService.Student
{
    public class StudentSyncTempService
    {
        private readonly DataAcceseLayer _dal;

        public StudentSyncTempService()
        {
            _dal = new DataAcceseLayer();
        }


        public void Clear()
        {
            _dal.ExecuteQuery(
                "TRUNCATE TABLE StudentSync_Temp"
            );
        }


        public void Save(List<StudentSyncTemp> students)
        {
            DataTable table = new DataTable();

            table.Columns.Add("SeatNo", typeof(int));
            table.Columns.Add("StdCode", typeof(string));
            table.Columns.Add("OsraId", typeof(int));
            table.Columns.Add("FirstName", typeof(string));
            table.Columns.Add("FullName", typeof(string));
            table.Columns.Add("Grade_Id", typeof(int));
            table.Columns.Add("Class_Id", typeof(int));
            table.Columns.Add("Gender_Id", typeof(int));
            table.Columns.Add("Religion_Id", typeof(int));
            table.Columns.Add("Action_Id", typeof(byte));


            foreach (var item in students)
            {
                table.Rows.Add(
                    item.SeatNo,
                    item.StdCode ?? "",
                    item.OsraId,
                    item.FirstName ?? "",
                    item.FullName ?? "",
                    item.Grade_Id,
                    item.Class_Id,
                    item.Gender_Id,
                    item.Religion_Id,
                    (byte)item.Action_Id
                );
            }


            _dal.BulkInsert(
                table,
                "StudentSync_Temp"
            );
        }


        public DataTable GetByAction(StudentSyncAction action)
        {
            return _dal.ExecQuery(
                "SP_Get_StudentSync_Temp",
                new SqlParameter(
                    "@Action_Id",
                    (byte)action
                )
            );
        }

        

        public DataTable GetAll()
        {
            return _dal.ExecQuery(
                "SP_Get_All_StudentSync_Temp"
            );
        }
    }
}
