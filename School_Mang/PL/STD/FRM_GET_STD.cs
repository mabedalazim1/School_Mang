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
    public partial class FRM_GET_STD : Form
    {
        BL.Waiting waiting = new BL.Waiting();
        BL.MSG msg = new BL.MSG();
        

        BL.STD.CLS_STD std = new BL.STD.CLS_STD();
        DAL.TestConcation testConcation = new DAL.TestConcation();

        public FRM_GET_STD()
        {
            InitializeComponent();

            cmb_sana.SelectedIndex = 0;

            waiting.Wait();
            if (testConcation.IsServerConnected())
            {
                this.dt_std_data.DataSource = std.Get_All_Std_Data(0);
                dt_std_data.Columns["std_code"].Visible = false;
                dt_std_data.Columns["id"].Visible = false;
                dt_std_data.Columns["std_name"].Visible = false;
                dt_std_data.Columns["Gender_Id"].Visible = false;
                dt_std_data.Columns["Grade_Id"].Visible = false;
                dt_std_data.Columns["Std_Status_Id"].Visible = false;
                dt_std_data.Columns["Nationality_Id"].Visible = false;
                dt_std_data.Columns["Year_Id"].Visible = false;
                dt_std_data.Columns["Religion_Id"].Visible = false;
                dt_std_data.Columns["اسم الأب"].Visible = false;
                dt_std_data.Columns["الوظيفة"].Visible = false;
                dt_std_data.Columns["اسم الأم"].Visible = false;
                lbl_count.Text = dt_std_data.Rows.Count.ToString();

            }
            waiting.End_WAit();
        }

        // Verify Stdunet Status 
        private Boolean Verify_Std_Status()
        {
            if (dt_std_data.SelectedRows.Count == 0)
            {
                msg.ErrorMesg(" يرجى إختيار طالب أولاً ..!");
                return true;
            }
            else
            {
                return false;
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
            BL.Globals.Add_From_Get_Std = false;
            BL.Globals.Elthak_Std = false;

            this.Close();
        }

        private void txt_std_data_OnValueChanged(object sender, EventArgs e)
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
                Dt = std.Search_Std_Data(txt_std_data.Text, cmb_sana.SelectedIndex);
                if (Dt != null)
                {
                    dt_std_data.DataSource = Dt;
                    lbl_count.Text = Dt.Rows.Count.ToString();
                }


            }
            catch (Exception ex)
            {
                msg.ErrorMesg(ex.Message);
            }
            finally
            {
                waiting.End_WAit();
            }
            waiting.End_WAit();
        }

        private void pic_help_MouseHover(object sender, EventArgs e)
        {
            lbl_help.Text = " البحث بالاسم أو الهاتف أو الأرقام القومية ";
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

        private void txt_std_data_Leave(object sender, EventArgs e)
        {
            pic_help_MouseLeave(sender, e);
        }

        private void btn_new_std_Click(object sender, EventArgs e)
        {

            BL.Globals.Add_From_Get_Std = true;

            this.Dispose();
            FRM_ADD_STD frm = new FRM_ADD_STD();
            frm.ShowDialog(MAIN.FRM_MAIN.Get_Frm_Main);
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            btn_close_b_Click(sender, e);
        }

        private void cmb_sana_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable Dt = new DataTable();
                Dt = std.Search_Std_Data(txt_std_data.Text, cmb_sana.SelectedIndex);
                if (Dt != null)
                {
                    dt_std_data.DataSource = Dt;
                    lbl_count.Text = Dt.Rows.Count.ToString();
                }

            }
            catch(Exception ex)
            {
                msg.ErrorMesg(ex.Message);
            }
        }

        private void btn_edit_std_Click(object sender, EventArgs e)
        {
            if (Verify_Std_Status()) return;

            BL.Globals.Update_Std_Data = true;
            
           
            try
            {
                FRM_ADD_STD.getAdd_Std_Frm.txt_std_code.Text=
                  dt_std_data.CurrentRow.Cells["std_code"].Value.ToString();

                FRM_ADD_STD.getAdd_Std_Frm.txt_nat.Text =
                  dt_std_data.CurrentRow.Cells["الرقم القومى"].Value.ToString();

                FRM_ADD_STD.getAdd_Std_Frm.txt_std_name.Text =
                  dt_std_data.CurrentRow.Cells["std_name"].Value.ToString();

                FRM_ADD_STD.getAdd_Std_Frm.cmb_type.SelectedValue =
                 dt_std_data.CurrentRow.Cells["Gender_Id"].Value;

                FRM_ADD_STD.getAdd_Std_Frm.cmb_grade.SelectedValue =
                    dt_std_data.CurrentRow.Cells["Grade_Id"].Value;

                FRM_ADD_STD.getAdd_Std_Frm.cmb_hala.SelectedValue =
                   dt_std_data.CurrentRow.Cells["Std_Status_Id"].Value;

                FRM_ADD_STD.getAdd_Std_Frm.cmb_national.SelectedValue =
                  dt_std_data.CurrentRow.Cells["Nationality_Id"].Value;

                FRM_ADD_STD.getAdd_Std_Frm.cmb_sana.SelectedValue =
                  dt_std_data.CurrentRow.Cells["Year_Id"].Value;

                FRM_ADD_STD.getAdd_Std_Frm.cmb_religion.SelectedValue =
               dt_std_data.CurrentRow.Cells["Religion_Id"].Value;

                FRM_ADD_STD.getAdd_Std_Frm.txt_osra_id.Text =
                   dt_std_data.CurrentRow.Cells["id"].Value.ToString();

                FRM_ADD_STD.getAdd_Std_Frm.txt_father_name.Text =
                   dt_std_data.CurrentRow.Cells["اسم الأب"].Value.ToString();

                FRM_ADD_STD.getAdd_Std_Frm.txt_adrs.Text =
                    dt_std_data.CurrentRow.Cells["العنوان"].Value.ToString();

                FRM_ADD_STD.getAdd_Std_Frm.txt_wazifa.Text =
                    dt_std_data.CurrentRow.Cells["الوظيفة"].Value.ToString();

                FRM_ADD_STD.getAdd_Std_Frm.txt_mother_name.Text =
                    dt_std_data.CurrentRow.Cells["اسم الأم"].Value.ToString();

                FRM_ADD_STD.getAdd_Std_Frm.txt_father_tel.Text =
                    dt_std_data.CurrentRow.Cells["هاتف الأب"].Value.ToString();

                FRM_ADD_STD.getAdd_Std_Frm.txt_mother_tel.Text =
                    dt_std_data.CurrentRow.Cells["هاتف الأم"].Value.ToString();

                this.Close();
                this.Dispose();

                FRM_ADD_STD.getAdd_Std_Frm.ShowDialog(MAIN.FRM_MAIN.Get_Frm_Main);

            }catch(Exception ex)
            {
                msg.ErrorMesg(ex.Message);
            }

        }

        private void FRM_GET_STD_Load(object sender, EventArgs e)
        {
            try
            {
                dt_std_data.Columns["اسم الطالب"].Width = 230;
                dt_std_data.Columns["الرقم القومى"].Width = 200;
                dt_std_data.Columns["العنوان"].Width = 270;
                
            }
            catch(Exception ex)
            {
                msg.ErrorMesg(ex.Message);
            }
            
        }

        private void dt_std_data_DoubleClick(object sender, EventArgs e)
        {
            if (BL.Globals.Elthak_Std)
            {
                btn_talab_elthak_Click(sender, e);
                return;
            }

            btn_edit_std_Click(sender, e);
        }

        private void btn_del_std_Click(object sender, EventArgs e)
        {
            if (Verify_Std_Status()) return;


            string name = dt_std_data.CurrentRow.Cells["اسم الطالب"].Value.ToString();

            int osrs_id = Convert.ToInt32(dt_std_data.CurrentRow.Cells["id"].Value.ToString());
            if (osrs_id.ToString() != "")
            {
                DataTable Dt;
                Dt = std.Verify_Osra_Data(osrs_id);

                if (msg.DialogeMsg("هل تريد حذف البيانات الخاصة بالطالب /  " + name) == DialogResult.Yes)
                {
                    std.Delele_Std_Data(dt_std_data.CurrentRow.Cells["std_code"].Value.ToString());
                    this.dt_std_data.DataSource = std.Get_All_Std_Data(Convert.ToInt32(cmb_sana.SelectedValue));
                   
                    if (Convert.ToInt32(Dt.Rows[0]["Id"].ToString()) == 1)
                    {
                        std.Delele_Osra_Data(osrs_id); 
                    }
                   
                    msg.ErrorMesg("تم حذف البيانات الخاصة بالطالب /   " + name);

                }
                else
                {
                    msg.ErrorMesg("تم إلغاء عملية الحذف الخاصة بالطالب /   " + name);
                    return;
                }

            }
        }

        private void btn_talab_elthak_Click(object sender, EventArgs e)
        {
            if (Verify_Std_Status()) return;


            int grade = Convert.ToInt32(dt_std_data.CurrentRow.Cells["Grade_Id"].Value);
            FRM_STD_ELTEHK.Get_Std_Eltehk.txt_std_code.Text = dt_std_data.CurrentRow.Cells["std_code"].Value.ToString();
            FRM_STD_ELTEHK.Get_Std_Eltehk.txt_std_name.Text = dt_std_data.CurrentRow.Cells["اسم الطالب"].Value.ToString();
            FRM_STD_ELTEHK.Get_Std_Eltehk.cmb_grade.SelectedValue = dt_std_data.CurrentRow.Cells["Grade_Id"].Value;
            FRM_STD_ELTEHK.Get_Std_Eltehk.cmb_hala.SelectedValue = dt_std_data.CurrentRow.Cells["Std_Status_Id"].Value;
            FRM_STD_ELTEHK.Get_Std_Eltehk.cmb_grade.SelectedValue = grade;

            if ((10 > grade  && grade >1))
            {

                BL.Globals.Taheewl_To_School = true;

                FRM_TAHEEL_STD.Get_Tahweel_Std.txt_std_code.Text = dt_std_data.CurrentRow.Cells["std_code"].Value.ToString();
                FRM_TAHEEL_STD.Get_Tahweel_Std.txt_std_name.Text = dt_std_data.CurrentRow.Cells["اسم الطالب"].Value.ToString();
                FRM_TAHEEL_STD.Get_Tahweel_Std.txt_guardian_name.Text = dt_std_data.CurrentRow.Cells["اسم الأب"].Value.ToString();
                FRM_TAHEEL_STD.Get_Tahweel_Std.txt_adrs.Text = dt_std_data.CurrentRow.Cells["العنوان"].Value.ToString();
                FRM_TAHEEL_STD.Get_Tahweel_Std.txt_transfer_reason.Text = "رغبة ولى الأمر";
                FRM_TAHEEL_STD.Get_Tahweel_Std.chk_resom_no.Checked = true;
                FRM_TAHEEL_STD.Get_Tahweel_Std.chk_kotob_no.Checked = true;
                FRM_TAHEEL_STD.Get_Tahweel_Std.transfer_status = 4;
                FRM_TAHEEL_STD.Get_Tahweel_Std.lbl_mohwel.Text = "محول من";
                FRM_TAHEEL_STD.Get_Tahweel_Std.grade = Convert.ToInt32(dt_std_data.CurrentRow.Cells["Grade_Id"].Value);

                FRM_TAHEEL_STD.Get_Tahweel_Std.ShowDialog();
            }
            else
            {
                FRM_STD_ELTEHK.Get_Std_Eltehk.ShowDialog(MAIN.FRM_MAIN.Get_Frm_Main);
            }

            
            this.Close();
            this.Dispose();
           
        }

        private void dt_std_data_Click(object sender, EventArgs e)
        {
            int grade = Convert.ToInt32(dt_std_data.CurrentRow.Cells["Grade_Id"].Value);
            if ((10 > grade && grade > 1))
            {
                btn_talab_elthak.ButtonText = "طلب تحويل";
            }
            else
            {
                btn_talab_elthak.ButtonText = "طلب إلتحاق";
            }
        }
    }
}
