using System.Data;
using System.Collections.Generic;

namespace School_Mang.BL.SITE
{
    public class ImportResult
    {
        public bool Success { get; set; }
        public List<string> Errors { get; set; } = new List<string>();
        public int ProcessedRows { get; set; }
        public DataTable Data { get; set; }
    }
}
