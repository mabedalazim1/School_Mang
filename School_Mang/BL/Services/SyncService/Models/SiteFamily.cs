using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Mang.BL.Services.FamilySyncService.Models
{
    public class SiteFamily
    {
        public int OsraId { get; set; }
        public string UserName { get; set; }
        public bool IsActive { get; set; }

        public string FirstName { get; set; }
        public string FullName { get; set; }
        public string WhatsAppNumber { get; set; }
    }
}
