using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Mang.BL.Enums
{
    [Flags]
    public enum GetOsraMode
    {
        Normal = 0,
        AddOsraDataToStudent = 1,
        OpenFromAddstudent = 2,
        OpenFormGetOsra = 4,
        AddFromGetStd = 8,   
        AddNewOsra = 16,
        OpenFromGetStd = 32,
        EditOsra = 64,
        EditStudent= 128,
    }

    [Flags]
    public enum GetStudentMode
    {
        Normal = 0,
        UpdateStdData = 1,
        AddNewStudent =2,
        AddStudentOsra =4,
    }


    [Flags]
    public enum GetStudentCase
    {
        Normal = 0,
        StudentDetails = 1,
        DegreeStatement = 2,
        ElthakStdNextYear = 4,
        TaheewlToSchool = 8,
        UpdateTaheewl = 16,
        ElthakStd = 32,
    }
}