namespace School_Mang.BL.Services.FamilySyncService.Models
{
    public class FamilySyncResult
    {
        public int NoChange { get; set; }
        public int Added { get; set; }
        public int Reactivated { get; set; }
        public int Disabled { get; set; }


        public int Total =>
            Added + Reactivated + Disabled + NoChange;
    }
}
