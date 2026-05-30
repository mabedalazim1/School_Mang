using School_Mang.BL.Enums;


namespace School_Mang.BL.Extensions
{
    public static class StudentCaseExtensions
    {
        public static bool IsElthak(this GetStudentCase c)
        => c.Has(GetStudentCase.ElthakStd)
        || c.Has(GetStudentCase.ElthakStdNextYear);

        public static bool IsDetails(this GetStudentCase c)
            => c.Has(GetStudentCase.StudentDetails);

        public static bool IsNextYearElthak(this GetStudentCase c)
            => c.Has(GetStudentCase.ElthakStdNextYear);
        public static bool IsDegreeStatement(this GetStudentCase c)
            => c.Has(GetStudentCase.DegreeStatement);
    }
}
