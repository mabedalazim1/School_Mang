using School_Mang.BL;
using School_Mang.BL.STD;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace School_Mang.PL.STD
{
    public partial class FRM_TOEXCEL : Form
    {

        //Import Classes
        CLS_STD std = new BL.STD.CLS_STD();
        Waiting waiting = new BL.Waiting();
        // MSG
        MSG msg = new BL.MSG();
        CLS_STD_FUNCATIONS Std_Func = new CLS_STD_FUNCATIONS();

        // Form Closed
        private static FRM_TOEXCEL frm_To_Excel;
        static void frm_Form_Closed(object sender, FormClosedEventArgs e)
        {
            frm_To_Excel = null;
        }
        public static FRM_TOEXCEL get_frm_To_Excel
        {
            get
            {
                if (frm_To_Excel == null)
                {
                    frm_To_Excel = new FRM_TOEXCEL();
                    frm_To_Excel.FormClosed += new FormClosedEventHandler(frm_Form_Closed);
                }
                return frm_To_Excel;
            }
        }
        public FRM_TOEXCEL()
        {
            InitializeComponent();
            if (frm_To_Excel == null)
            {
                frm_To_Excel = this;
            }
            try
            {
                waiting.Wait();
                // Fill Combos

                cmb_sana.DataSource = std.Get_years();
                cmb_sana.DisplayMember = "YearDesc";
                cmb_sana.ValueMember = "Year_Id";

                waiting.End_WAit();

            }
            catch(Exception e)
            {
                msg.ErrorMesg(e.Message);
            }
        }

            int move;
            int move_x;
            int move_y;


        private void pn_top_MouseDown(object sender, MouseEventArgs e)
        {
            move = 1;
            move_x = e.X;
            move_y = e.Y;
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            btn_close_b_Click(sender, e);
        }

        private void pn_top_MouseUp(object sender, MouseEventArgs e)
        {
            move = 0;
        }

        private void pn_top_MouseMove(object sender, MouseEventArgs e)
        {
            if (move == 1)
            {
                this.SetDesktopLocation(MousePosition.X - move_x, MousePosition.Y - move_y);
            }
        }

        private void btn_close_b_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FRM_TOEXCEL_Load(object sender, EventArgs e)
        {
            cmb_sana.SelectedValue = Properties.Settings.Default.year_cod;
            cmb_data.SelectedIndex = 0;
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            int sana = Convert.ToInt32(cmb_sana.SelectedValue);
            int data = Convert.ToInt32(cmb_data.SelectedIndex);

           
        }
    }
}
