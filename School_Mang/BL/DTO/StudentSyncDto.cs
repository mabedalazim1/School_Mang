using School_Mang.BL.Enums;

namespace School_Mang.BL.DTO
{
    public class StudentSyncDto
    {
        public int SeatNo { get; set; }
        public string StdCode { get; set; }
        public int OsraId { get; set; }
        public string FirstName { get; set; }
        public string FullName { get; set; }
        public int Grade_Id { get; set; }
        public int Class_Id { get; set; }
        public int Gender_Id { get; set; }
        public int Religion_Id { get; set; }

        public StudentSyncAction Action_Id { get; set; }
    }
}
