using School_Mang.BL.Enums;
using System.Windows.Forms;

namespace School_Mang.BL.Common.Helper
{
    public static class GridHelper
    {
        public static void SetColumnsVisibility(
    DataGridView grid,
    ColumnVisibility mode,
    params string[] columns)
        {
            if (grid == null)
                return;

            bool visible = mode == ColumnVisibility.Show;

            void Handler(object sender, DataGridViewBindingCompleteEventArgs e)
            {
                foreach (var col in columns)
                {
                    if (grid.Columns.Contains(col))
                        grid.Columns[col].Visible = visible;
                }
            }

            grid.DataBindingComplete -= Handler;
            grid.DataBindingComplete += Handler;
        }
    }
}
