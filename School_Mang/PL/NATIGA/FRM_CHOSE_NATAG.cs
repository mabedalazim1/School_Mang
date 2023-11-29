using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace School_Mang.PL.NATIGA
{
    public partial class FRM_CHOSE_NATAG : Form
    {
        BL.MSG msg = new BL.MSG();
        BL.NATEG.CLS_NATEG NATEG = new BL.NATEG.CLS_NATEG();
        BL.Waiting Waiting = new BL.Waiting();

        // Form Closed
        private static FRM_CHOSE_NATAG frm_Chose_Natag;
        static void frm_Form_Closed(object sender, FormClosedEventArgs e)
        {
            frm_Chose_Natag = null;
        }
        public static FRM_CHOSE_NATAG Get_Frm_Chose_Natag
        {
            get
            {
                if (frm_Chose_Natag == null)
                {
                    frm_Chose_Natag = new FRM_CHOSE_NATAG();
                    frm_Chose_Natag.FormClosed += new FormClosedEventHandler(frm_Form_Closed);
                }
                return frm_Chose_Natag;
            }
        }
        public FRM_CHOSE_NATAG()
        {
            InitializeComponent();

            if (frm_Chose_Natag == null)
            {
                frm_Chose_Natag = this;
            }
            Waiting.Wait();
            cmb_month.DataSource = NATEG.GET_TEST_KIND();
            cmb_month.DisplayMember = "testkind_desc";
            cmb_month.ValueMember = "id";

            Add_To_Comb_Test();
            Waiting.End_WAit();
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


        private void pn_top_MouseMove(object sender, MouseEventArgs e)
        {
            if (move == 1)
            {
                this.SetDesktopLocation(MousePosition.X - move_x, MousePosition.Y - move_y);
            }
        }

        private void pn_top_MouseUp(object sender, MouseEventArgs e)
        {
            move = 0;
        }

        private void Add_To_Comb_Test()
        {
            Dictionary<int, string> comboSource = new Dictionary<int, string>();
            comboSource.Add(1, "التقييمات");
            comboSource.Add(2, "الإختبارات");

            cmb_test.DataSource = new BindingSource(comboSource, null);
            cmb_test.DisplayMember = "Value";
            cmb_test.ValueMember = "Key";
        }

        private void btn_close_b_Click(object sender, EventArgs e)
        {
            btn_close_Click(sender, e);
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_show_data_Click(object sender, EventArgs e)
        {
            BL.Globals.test_kind = Convert.ToInt32(cmb_test.SelectedValue);
            BL.Globals.test_month = Convert.ToInt32(cmb_month.SelectedValue);


            DataTable Dt ;

            switch (BL.Globals.test_kind)
            {
                case 1:
                    Dt = NATEG.Get_Count_Degree(BL.Globals.test_month);
                    if (Dt.Rows.Count == 0)
                    {
                        msg.ErrorMesg("لا توجد بيانات مسجلة ..!");
                        return;
                    }
                    break;
                case 2:
                    Dt = NATEG.Get_Count_Mark(BL.Globals.test_month);
                    if (Dt.Rows.Count == 0)
                    {
                        msg.ErrorMesg("لا توجد بيانات مسجلة ..!");
                        return;
                    }
                    break;
            }

            this.Hide();
            FRM_NATAG_DATA frm = new FRM_NATAG_DATA();
            frm.ShowDialog(MAIN.FRM_MAIN.Get_Frm_Main);
           
        }
    }
}
