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
    public partial class FRM_GET_OSRAA : Form
    {
        public string status = "osra_data";

        // GET Classes
        BL.STD.CLS_STD std = new BL.STD.CLS_STD();
        BL.Waiting waiting = new BL.Waiting();
        BL.MSG msg = new BL.MSG();
        DAL.TestConcation testConcation = new DAL.TestConcation();

        // Form Closed
        private static FRM_GET_OSRAA frm_Get_Osrs;

        static void frm_Form_Closed(object sender, FormClosedEventArgs e)
        {
            frm_Get_Osrs = null;
        }
        public static FRM_GET_OSRAA Get_Osra_data
        {
            get
            {
                if (frm_Get_Osrs == null)
                {
                    frm_Get_Osrs = new FRM_GET_OSRAA();
                    frm_Get_Osrs.FormClosed += new FormClosedEventHandler(frm_Form_Closed);
                }
                return frm_Get_Osrs;
            }
        }


        public FRM_GET_OSRAA()
        {
            InitializeComponent();

            if (frm_Get_Osrs == null)
            {
                frm_Get_Osrs = this;
            }


            waiting.Wait();
            if (testConcation.IsServerConnected())
            {
                this.dt_osra_data.DataSource = std.Get_All_Osra_Data();
                dt_osra_data.Columns["id"].Visible = false;
                dt_osra_data.Columns["الوظيفة"].Visible = false;
                dt_osra_data.Columns["رقم الأب القومى"].Visible = false;
                dt_osra_data.Columns["رقم الأم القومى"].Visible = false;

            }
            waiting.End_WAit();
        }


        private void btn_close_Click(object sender, EventArgs e)
        {
            btn_close_b_Click(sender, e);
        }

        int move;
        int move_x;
        int move_y;

        private void pn_top_MouseMove(object sender, MouseEventArgs e)
        {
            if (move == 1)
            {
                this.SetDesktopLocation(MousePosition.X - move_x, MousePosition.Y - move_y);
            }
        }

        private void pn_top_MouseDown(object sender, MouseEventArgs e)
        {
            move = 1;
            move_x = e.X;
            move_y = e.Y;
        }

        private void pn_top_MouseUp(object sender, MouseEventArgs e)
        {
            move = 0;
        }

        private void txt_osra_data_OnValueChanged(object sender, EventArgs e)
        {
            waiting.Wait();
            if (!testConcation.IsServerConnected())
            {
                msg.ErrorMesg("تأكد من الاتصال بالسيرفر.. !");
                return;
            }
            try
            {
                DataTable Dt = new DataTable();
                Dt = std.Search_Osra_Data(txt_osra_data.Text);
                if(Dt != null)
                {
                    dt_osra_data.DataSource = Dt;
                }

            }
            catch(Exception ex)
            {
                msg.ErrorMesg(ex.Message);
            }
            finally
            {
                waiting.End_WAit();
            }
            waiting.End_WAit();
        }

        private void btn_close_b_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            
            BL.Globals.Add_Osra_Data_To_Student = false;
            try
            {
                

                 FRM_ADD_STD.getAdd_Std_Frm.txt_osra_id.Text =
                    dt_osra_data.CurrentRow.Cells["id"].Value.ToString();

                 FRM_ADD_STD.getAdd_Std_Frm.txt_father_name.Text = 
                    dt_osra_data.CurrentRow.Cells["اسم الأب"].Value.ToString();

                FRM_ADD_STD.getAdd_Std_Frm.txt_adrs.Text =
                    dt_osra_data.CurrentRow.Cells["العنوان"].Value.ToString();

                FRM_ADD_STD.getAdd_Std_Frm.txt_wazifa.Text =
                    dt_osra_data.CurrentRow.Cells["الوظيفة"].Value.ToString();

                FRM_ADD_STD.getAdd_Std_Frm.txt_mother_name.Text =
                    dt_osra_data.CurrentRow.Cells["اسم الأم"].Value.ToString();

                FRM_ADD_STD.getAdd_Std_Frm.txt_father_tel.Text =
                    dt_osra_data.CurrentRow.Cells["هاتف الأب"].Value.ToString();

                FRM_ADD_STD.getAdd_Std_Frm.txt_mother_tel.Text =
                    dt_osra_data.CurrentRow.Cells["هاتف الأم"].Value.ToString();

                // if(FRM_ADD_STD.getAdd_Std_Frm.txt_mother_tel.Text == "")
                //{
                // msg.ErrorMesg("False");
                //return;
                //}

                if(status == "from_std") 
                {
                    this.Close();

                    FRM_ADD_STD.getAdd_Std_Frm.Show();
                    FRM_ADD_STD.getAdd_Std_Frm.txt_nat.Focus();

                    //FRM_ADD_STD.getAdd_Std_Frm.Open_Form_Get_osra = true;
                }
                else if(status == "std_add_new_osra")
                {
                    this.Close();
                    FRM_ADD_STD.getAdd_Std_Frm.ShowDialog(MAIN.FRM_MAIN.Get_Frm_Main);
                     
                }
                else
                {
                    this.Dispose();
                    //FRM_ADD_STD.getAdd_Std_Frm.Visible = false;
                    FRM_ADD_STD.getAdd_Std_Frm.Show(MAIN.FRM_MAIN.Get_Frm_Main);
                }
            }
           
            catch (Exception ex)
            {
                msg.ErrorMesg(ex.Message);
            }
        }

        private void btn_new_osra_Click(object sender, EventArgs e)
        {
            if(status == "from_std")
            {
                FRM_ADD_STD.getAdd_Std_Frm.Hide();
            }
            this.Dispose();
            
            FRM_OSRAA_DATA.Get_Osra_data.ShowDialog(MAIN.FRM_MAIN.Get_Frm_Main);
        }

        private void FRM_GET_OSRAA_Load(object sender, EventArgs e)
        {
            
        }

        private void pic_help_MouseHover(object sender, EventArgs e)
        {
            lbl_help.Text = " البحث بالاسم أو الهاتف أو الرقم القومى";
            lbl_help.Visible = true;
        }

        private void pic_help_MouseLeave(object sender, EventArgs e)
        {
            lbl_help.Visible = false;
        }

        private void label1_MouseHover(object sender, EventArgs e)
        {
            pic_help_MouseHover(sender, e);
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            pic_help_MouseLeave(sender, e);
        }

        private void txt_osra_data_Leave(object sender, EventArgs e)
        {
            pic_help_MouseLeave(sender, e);
        }

        private void txt_osra_data_Enter(object sender, EventArgs e)
        {
            pic_help_MouseHover(sender, e);
        }

        private void txt_osra_data_KeyPress(object sender, KeyPressEventArgs e)
        {
            pic_help_MouseHover(sender, e);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            txt_osra_data.Focus();
        }

        private void btn_edit_osra_Click(object sender, EventArgs e)
        {
            int osrs_id = Convert.ToInt32(dt_osra_data.CurrentRow.Cells[0].Value);
            if (osrs_id.ToString() != "")
            {
                DataTable Dt ;
                Dt = std.Get_osra_Data_ById(osrs_id);


                // Add Data

                FRM_OSRAA_DATA.Get_Osra_data.state = "edit";
                FRM_OSRAA_DATA.Get_Osra_data.txt_father_name.Text = Dt.Rows[0]["father_name"].ToString();
                FRM_OSRAA_DATA.Get_Osra_data.txt_last_name.Text = Dt.Rows[0]["father_last_name"].ToString();
                FRM_OSRAA_DATA.Get_Osra_data.txt_father_nat.Text = Dt.Rows[0]["father_nat"].ToString();
                FRM_OSRAA_DATA.Get_Osra_data.cmb_father_halaa.SelectedValue = Dt.Rows[0]["father_hala"];
                FRM_OSRAA_DATA.Get_Osra_data.txt_adrs.Text = Dt.Rows[0]["address"].ToString();
                FRM_OSRAA_DATA.Get_Osra_data.txt_father_moahel.Text = Dt.Rows[0]["father_moahel"].ToString();
                FRM_OSRAA_DATA.Get_Osra_data.txt_father_wazifa.Text = Dt.Rows[0]["father_wazifa"].ToString();
                FRM_OSRAA_DATA.Get_Osra_data.txt_tel.Text = Dt.Rows[0]["tel"].ToString();
                FRM_OSRAA_DATA.Get_Osra_data.txt_father_mobil1.Text = Dt.Rows[0]["father_mobil_1"].ToString();
                FRM_OSRAA_DATA.Get_Osra_data.txt_father_mobil2.Text = Dt.Rows[0]["father_mobil_2"].ToString();
                FRM_OSRAA_DATA.Get_Osra_data.txt_mother_name.Text = Dt.Rows[0]["mother_name"].ToString();
                FRM_OSRAA_DATA.Get_Osra_data.txt_mother_nat.Text = Dt.Rows[0]["mother_nat"].ToString();
                FRM_OSRAA_DATA.Get_Osra_data.txt_mother_moahel.Text = Dt.Rows[0]["mother_moahel"].ToString();
                FRM_OSRAA_DATA.Get_Osra_data.txt_mother_wazifa.Text = Dt.Rows[0]["mother_wazifa"].ToString();
                FRM_OSRAA_DATA.Get_Osra_data.cmb_mother_hala.SelectedValue = Dt.Rows[0]["mother_hala"];
                FRM_OSRAA_DATA.Get_Osra_data.txt_mother_mobil_1.Text = Dt.Rows[0]["mother_mobil_1"].ToString();
                FRM_OSRAA_DATA.Get_Osra_data.txt_mother_mobil2.Text = Dt.Rows[0]["mother_mobil_2"].ToString();
                FRM_OSRAA_DATA.Get_Osra_data.txt_memo.Text = Dt.Rows[0]["comments"].ToString();
                FRM_OSRAA_DATA.Get_Osra_data.txt_osra_code.Text = Dt.Rows[0]["Osraa_Id"].ToString();


                FRM_OSRAA_DATA.Get_Osra_data.ShowDialog();
                FRM_OSRAA_DATA.Get_Osra_data.txt_adrs.Focus();
            }
            else
            {
                msg.ErrorMesg("برجى اختيار البيانات المراد تعديلها ... !");
                return;
            }
        }

        private void btn_del_osra_Click(object sender, EventArgs e)
        {

            string name = dt_osra_data.CurrentRow.Cells["اسم الأب"].Value.ToString();

            int osrs_id = Convert.ToInt32(dt_osra_data.CurrentRow.Cells["id"].Value.ToString());
            if (osrs_id.ToString() != "")
            {
                DataTable Dt = new DataTable();
                Dt = std.Verify_Osra_Data(osrs_id);
                if(Convert.ToInt32(Dt.Rows[0]["Id"].ToString()) != 0){
                    msg.ErrorMesg("لا يمكن حذف البيانات الخاصة بالسيد /   " + name);
                }
                else
                {
                    if (msg.DialogeMsg("هل تريد حذف البيانات الخاصة بالسيد /  " + name) == DialogResult.Yes)
                    {
                        std.Delele_Osra_Data(osrs_id);
                        this.dt_osra_data.DataSource = std.Get_All_Osra_Data();
                        msg.ErrorMesg("تم حذف البيانات الخاصة بالسيد /   " + name);
                    }
                    else
                    {
                        msg.ErrorMesg("تم إلغاء عملية الحذف الخاصة بالسيد /   " + name);
                        return;
                    }

                }
            }
        }

        private void dt_osra_data_DoubleClick(object sender, EventArgs e)
        {
            if (BL.Globals.Add_Osra_Data_To_Student)
            {
                btn_ok_Click(sender, e);
            }
            else
            {
                btn_edit_osra_Click(sender, e);
            }
           


        }
    }
}
