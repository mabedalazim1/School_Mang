using System.Windows.Forms;

namespace School_Mang.BL
{
    public static class Waiting
    {
        public static void Start()
        {
            Application.UseWaitCursor = true;
            Cursor.Current = Cursors.WaitCursor;
        }

        public static void Stop()
        {
            Application.UseWaitCursor = false;
            Cursor.Current = Cursors.Default;
        }
    }
}