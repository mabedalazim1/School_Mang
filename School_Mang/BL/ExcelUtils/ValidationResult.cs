using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace School_Mang.BL.ExcelUtils
{
    public class ValidationResult
    {
        public bool Success => Errors == null || Errors.Count == 0;

        public List<string> Errors { get; set; } = new List<string>();

        public DataTable Data { get; set; }
    }
}
