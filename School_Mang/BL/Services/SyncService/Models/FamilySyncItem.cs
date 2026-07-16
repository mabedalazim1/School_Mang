using School_Mang.BL.DTO;
using School_Mang.BL.Enums;

namespace School_Mang.BL.Services.FamilySyncService.Models
{
    public class FamilySyncItem
    {
        public SchoolFamily SchoolFamily { get; set; }

        public SiteFamily SiteFamily { get; set; }

        public FamilySyncAction Action { get; set; }

        public string Message { get; set; }

    }
}
