using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace School_Mang.BL
{
    class Waiting
    {
        public void Wait()
        {
            Application.UseWaitCursor = true;
            System.Windows.Forms.Cursor.Current = Cursors.WaitCursor;
        }
        public void End_WAit()
        {
            Application.UseWaitCursor = false;
            Cursor.Current = Cursors.Default;
        }
    }
}
