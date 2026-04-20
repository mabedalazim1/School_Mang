using DevExpress.XtraReports.Wizards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Mang.BL.Services
{
    public class NavigationContext
    {
        public enum ReportDataType
        {
            None,
            OpenKaema,
            OpenSegel,
            OpenTadargSen,
            Open41New,
            OpenTransferFrom,
            OpenTransferTo
        }

        public  ReportDataType CurrentReport { get; set; }

        public Action PostAction { get; set; }

        public bool OpenOsraFromStudent { get; set; }
        public bool ShowDetailsStd { get; set; }
        public bool OpenFormGetOsra { get; set; }
        public bool DetailsStd { get; set; }
        public bool DegreeStatement { get; set; }
        public bool ElthakStd { get; set; }
        public bool ElthakStdNextYear { get; set; }
        public bool AddOsraDataToStudent { get; set; }
        public bool AddFromGetStd { get; set; }
        public bool OpenFromGetStd { get; set; }
        public bool UpdateStdData { get; set; }
        public bool TaheewlToSchool { get; set; }
        public bool UpdateTaheewl { get; set; }


        public int Year { get; set; }
        public int GradeId { get; set; }

        // 👇 نضيف دول من FRM_MAIN
        public bool FromMain { get; set; }
        public bool ShowHome { get; set; }

        public bool ShowStdDetails { get; set; }

        public bool CurrentYearData { get; set; }

    }
}
