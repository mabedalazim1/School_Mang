using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Mang.BL.Services.FamilySyncService.Models
{
    public class FamilySyncTemp
    {
        public int OsraId { get; set; }

        public string FirstName { get; set; }
        public string FatherName { get; set; }
        public string FatherNat { get; set; }
        public string WhatsAppNumber { get; set; }
        public string SiteUserName { get; set; }
        public string SitePassword { get; set; }
        public bool SiteIsActive { get; set; }
        public int ActionId { get; set; }
    }
}
