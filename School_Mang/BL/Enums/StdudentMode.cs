using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Mang.BL.Enums
{
    [Flags]
    public enum GetStudentCase
    {
        None = 0,
        StudentDetails = 1,
        DegreeStatement = 2,
        ElthakStdNextYear = 4,
        TaheewlToSchool = 8,
        UpdateTaheewl = 16,
        ElthakStd = 32,
    }
}