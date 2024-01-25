using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace School_Mang.PL.SITE
{
    public partial class FRM_SITE_USER_DATA : Form
    {
        BL.SITE.CLS_MANGE_SITE Site = new BL.SITE.CLS_MANGE_SITE();
        BL.STD.CLS_STD std = new BL.STD.CLS_STD();
        BL.Waiting Waiting = new BL.Waiting();
        BL.MSG msg = new BL.MSG();

        // Form Closed
        private static FRM_SITE_USER_DATA Frm_Site_User_Data;
        static void frm_Form_Closed(object sender, FormClosedEventArgs e)
        {
            Frm_Site_User_Data = null;
        }
        public static FRM_SITE_USER_DATA Get_Frm_Site_User_Data
        {
            get
            {
                if (Frm_Site_User_Data == null)
                {
                    Frm_Site_User_Data = new FRM_SITE_USER_DATA();
                    Frm_Site_User_Data.FormClosed += new FormClosedEventHandler(frm_Form_Closed);
                }
                return Frm_Site_User_Data;
            }
        }


        public FRM_SITE_USER_DATA()
        {
            InitializeComponent();

            if (Frm_Site_User_Data == null)
            {
                Frm_Site_User_Data = this;
            }
            dt_std_data.MouseDown += new MouseEventHandler(this.dt_std_data_MouseClick);

            Waiting.Wait();
            DataTable grade_dt = std.Get_grades();
            cmb_grade.DataSource = grade_dt;
            cmb_grade.DisplayMember = "GradeDesc";
            cmb_grade.ValueMember = "Grade_Id";

            byte grade = Convert.ToByte(BL.Globals.test_grade_id);
            Load_Data(grade);

            Waiting.End_WAit();
        }

        private async Task Test_Intrent()
        {
            Waiting.Wait();
            //Test Intrent Connection
            BL.CLS_TEST_INTRNET_CON test_intrent = new BL.CLS_TEST_INTRNET_CON();
            await test_intrent.ChecK_Internt_Con();
            Waiting.End_WAit();
        }
        private async void Load_Data(byte grade)
        {
            await Test_Intrent();

            if (!BL.Globals.Test_Internet_Con)
            {
                msg.ErrorMesg("تأكد من الإتصال بالإنترنت..!");
                this.Close();
                return;
            }
            else
            {
                try
                {
                    Waiting.Wait();
                    DataTable users;
                    users = Site.Get_Users_Data(grade);
                    dt_std_data.DataSource = null;
                    dt_std_data.DataSource = users;
                    if (users != null)
                    {
                        dt_std_data.Columns["clas_id"].Visible = false;
                        dt_std_data.Columns["grade_Id"].Visible = false;
                        dt_std_data.Columns["gender_Id"].Visible = false;
                        dt_std_data.Columns["religion_Id"].Visible = false;

                        dt_std_data.Columns[0].Width = 120;
                        dt_std_data.Columns[1].Width = 250;
                    }
                    else
                    {
                        msg.ErrorMesg("حدث خطأ فى الإتصال..!");
                        this.Close();
                    }

                    Waiting.End_WAit();

                }
                catch (Exception e)
                {
                    msg.ErrorMesg(e.Message);
                    Waiting.End_WAit();
                }
                finally
                {
                    Waiting.End_WAit();
                }
            }
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

        private void btn_close_Click(object sender, EventArgs e)
        {
            btn_close_b_Click(sender, e);
        }

        private void btn_close_b_Click(object sender, EventArgs e)
        {
            Close();

        }

        private void btn_show_data_Click(object sender, EventArgs e)
        {

        }

        private void pic_help_MouseHover(object sender, EventArgs e)
        {
            lbl_help.Text = " البحث بالاسم";
            lbl_help.Visible = true;
        }

        private void pic_help_MouseLeave(object sender, EventArgs e)
        {
            lbl_help.Visible = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            txt_std_data.Focus();
        }

        private void label1_MouseHover(object sender, EventArgs e)
        {
            pic_help_MouseHover(sender, e);
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            pic_help_MouseLeave(sender, e);
        }

        private void txt_std_data_Enter(object sender, EventArgs e)
        {
            pic_help_MouseHover(sender, e);
        }

        private void txt_std_data_KeyPress(object sender, KeyPressEventArgs e)
        {
            pic_help_MouseHover(sender, e);
        }

        private void txt_std_data_MouseLeave(object sender, EventArgs e)
        {
            pic_help_MouseLeave(sender, e);
        }

        private void FRM_SITE_USER_DATA_Load(object sender, EventArgs e)
        {
            if (!BL.Globals.Test_Internet_Con) this.Close();

            cmb_grade.SelectedValue = BL.Globals.test_grade_id;

        }

        private async void cmb_grade_SelectedIndexChanged(object sender, EventArgs e)
        {

            await Test_Intrent();
            if (!BL.Globals.Test_Internet_Con)
            {
                msg.ErrorMesg("تأكد من الإتصال بالإنترنت..!");
                return;
            }
            Waiting.Wait();
            if (cmb_grade.Focused == true)
            {
                byte new_grade = Convert.ToByte(cmb_grade.SelectedValue);
                DataTable users;

                users = Site.Get_Users_Data(new_grade);
                dt_std_data.DataSource = users;

            }
            Waiting.End_WAit();
        }

        private void copy_Click(Object sender, EventArgs e)
        {
            if (this.dt_std_data.GetCellCount(DataGridViewElementStates.Selected) > 0)
            {
                try
                {
                    string pass = this.dt_std_data.CurrentRow.Cells["اسم المستخدم"].Value.ToString();
                    Clipboard.SetDataObject(pass);
                }
                catch (System.Runtime.InteropServices.ExternalException)
                {
                    MessageBox.Show("Clipboard could not be accessed. Please try again.");
                }
            }

        }
        private void dt_std_data_MouseClick(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Right)
            {

                ContextMenu cm = new ContextMenu();
                this.ContextMenu = cm;

                cm.MenuItems.Add(new MenuItem("&Copy", new EventHandler(this.copy_Click)));

                cm.Show(this, new Point(e.X, e.Y + 100));
            }
        }

        private void btn_absent_std_Click(object sender, EventArgs e)
        {
            msg.ErrorMesg("هذا الإجراء غير متاح ..!");
        }
       
    }
}
