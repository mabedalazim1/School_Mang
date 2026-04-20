using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using School_Mang.BL;

namespace School_Mang.PL.USERS
{
    public partial class FRM_ADD_USER : Form
    {
        
        BL.USERS users = new BL.USERS();



        int new_role_id = 0;
        public int old_role_id;
        public int old_permission_id;

        int permission_id = 0;
        int role_id = 0;
        int role_id_2 = 0;
        int role_id_3 = 0;
        int role_id_4 = 0;
        int role_id_5 = 0;

        int chk_count = 0;

        int move;
        int move_x;
        int move_y;


        public FRM_ADD_USER()
        {
            InitializeComponent();
            chk_read.Checked = true;
            txt_user.Focus();
            // Edit User
            if (BL.Globals.EditUser)
            {
                label11.Text = "تعديل صلاحيات المستخدم";
                btn_add_user.ButtonText = "تعديل";
            }
            // Add Permissions
            if (BL.Globals.Add_User_Permission)
            {
                label11.Text = "إضافة صلاحيات للمستخدم";
                btn_add_user.ButtonText = "إضافة";
            }

        }

      
        private void btn_close_Click(object sender, EventArgs e)
        {
            btn_cancel_Click(sender, e);
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            BL.Globals.EditUser = false;
            BL.Globals.Add_User_Permission = false;
            this.Close();
        }


        private void chk_all_prem_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_all_prem.Checked)
            {
                chk_some_perm.Checked = false;
                chk_read.Checked = false;
                permission_id = 1;
            }
            else
            {
                permission_id = 0;
            }
        }

        private void chk_some_perm_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_some_perm.Checked)
            {
                chk_all_prem.Checked = false;
                chk_read.Checked = false;
                permission_id = 2;
            }
            else
            {
                permission_id = 0;
            }
        }

        private void chk_read_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_read.Checked)
            {
                chk_all_prem.Checked = false;
                chk_some_perm.Checked = false;
                permission_id = 3;
            }
            else
            {
                permission_id = 0;
            }
        }

        private void chk_admin_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_admin.Checked)
            {
                chk_count  ++;
                role_id = 1;

                chk_amlin.Checked = false;
                chk_takimat.Checked = false;
                chk_talba.Checked = false;
                chk_maliat.Checked = false;

                chk_amlin.Enabled = false;
                chk_takimat.Enabled = false;
                chk_talba.Enabled = false;
                chk_maliat.Enabled = false;

                chk_amlin.ForeColor = Color.LightGray;
                chk_takimat.ForeColor = Color.LightGray;
                chk_talba.ForeColor = Color.LightGray;
                chk_maliat.ForeColor = Color.LightGray;

                new_role_id = 1;


                if (BL.Globals.EditUser || BL.Globals.Add_User_Permission)
                {
                    // No One Get Admin With All Perm

                    chk_all_prem.Checked = false;
                    chk_all_prem.Enabled = false;
                    chk_some_perm.Checked = true;

                }
            }
            else
            {
                chk_count--;
                role_id = 0;

                chk_amlin.ForeColor = Color.FromArgb(60,60,60);
                chk_takimat.ForeColor = Color.FromArgb(60, 60, 60);
                chk_talba.ForeColor = Color.FromArgb(60, 60, 60);
                chk_maliat.ForeColor = Color.FromArgb(60, 60, 60);

                chk_amlin.Enabled = true;
                chk_takimat.Enabled = true;
                chk_talba.Enabled = true;
                chk_maliat.Enabled = true;

                chk_all_prem.Enabled = true;

            }

          
        }

        private void chk_talba_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_talba.Checked)
            {
                chk_count++;
                role_id_2 = 2;
                new_role_id = 2;
            }
            else
            {
                chk_count--;
                role_id_2 = 0;
              
            }

            if (BL.Globals.EditUser || BL.Globals.Add_User_Permission)
            {
                if (chk_talba.Checked)
                {
                    chk_admin.Checked = false;
                    chk_amlin.Checked = false;
                    chk_maliat.Checked = false;
                    chk_takimat.Checked = false;
                }
            }
        }

        private void chk_takimat_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_takimat.Checked)
            {
                chk_count++;
                role_id_3 = 3;
                new_role_id = 3;
            }
            else
            {
                chk_count--;
                role_id_3 = 0;
               
            }

            if (BL.Globals.EditUser || BL.Globals.Add_User_Permission)
            {
                if (chk_takimat.Checked)
                {
                    chk_admin.Checked = false;
                    chk_amlin.Checked = false;
                    chk_maliat.Checked = false;
                    chk_talba.Checked = false;
                }
            }
        }

        private void chk_maliat_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_maliat.Checked)
            {
                chk_count++;
                role_id_5 = 5;
                new_role_id = 5;
            }
            else
            {
                chk_count--;
                role_id_5 = 0;
          
            }

            if (BL.Globals.EditUser || BL.Globals.Add_User_Permission)
            {
                if (chk_maliat.Checked)
                {
                    chk_admin.Checked = false;
                    chk_amlin.Checked = false;
                    chk_takimat.Checked = false;
                    chk_talba.Checked = false;
                }
            }
        }

        private void chk_amlin_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_amlin.Checked)
            {
                chk_count++;
                role_id_4 = 4;
                new_role_id = 4;
            }
            else
            {
                chk_count--;
                role_id_4 = 0;
            }

            if (BL.Globals.EditUser || BL.Globals.Add_User_Permission)
            {
                if (chk_amlin.Checked)
                {
                    chk_admin.Checked = false;
                    chk_maliat.Checked = false;
                    chk_takimat.Checked = false;
                    chk_talba.Checked = false;
                }
            }
        }

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

        private void btn_add_user_Click(object sender, EventArgs e)
        {
            if (!BL.Globals.EditUser && !BL.Globals.Add_User_Permission)
            {
                
                    // Save User
                    Waiting.Start();
                if (txt_user.Text == "")
                {
                    MSG.ErrorMesg("ادخل اسم المستخدم ..!");
                    txt_user.Focus();
                    Waiting.Stop();
                    return;
                }
                if (txt_pass.Text == "")
                {
                    MSG.ErrorMesg("ادخل كلمة المرور ..!");
                    txt_pass.Focus();
                    Waiting.Stop();
                    return;
                }

                // Verify User Name

                DataTable dt;
                dt = users.Get_Users();

                foreach (DataRow row in dt.Rows)
                {
                    if (txt_user.Text == row["اسم المستخدم"].ToString())
                    {
                        MSG.ErrorMesg("تأكد من اسم المستخدم .. الاسم موجود مسبقاً...");
                        Waiting.Stop();
                        txt_user.Focus();
                        return;
                    }

                }

                if (chk_admin.Checked || chk_takimat.Checked ||
                    chk_talba.Checked || chk_amlin.Checked ||
                    chk_maliat.Checked)
                {
                    MSG.MyMesg("عدد الأقسام المحددة   " + chk_count.ToString());
                }
                else
                {
                    MSG.ErrorMesg("اختر القسم ..!");
                    chk_admin.Focus();
                    Waiting.Stop();
                    return;
                }

                if(permission_id == 0)
                {
                    MSG.ErrorMesg("اختر الصلاحية ..!");
                    chk_some_perm.Focus();
                    Waiting.Stop();
                    return;
                }

                try
                {
                    users.Add_Users_Data(
                    txt_user.Text, txt_pass.Text,
                    role_id,
                    permission_id,
                     role_id_2,
                    role_id_3, role_id_4, role_id_5);
                    MSG.MyMesg("تم إضافة المستخدم بنجاح  " + txt_user.Text);
                    txt_pass.Text = "";
                    txt_user.Text = "";
                    MAIN.FRM_SETTINGS.Get_Frm_Settings.dt_users_data.DataSource = users.Get_Users();
                    Waiting.Stop();

                    this.Close();
                }
                catch (Exception ex)
                {
                    MSG.ErrorMesg(ex.Message);
                    Waiting.Stop();
                }
                Waiting.Stop();
            }

            if (BL.Globals.EditUser)
            {
                // Update User
                if (!chk_admin.Checked && !chk_takimat.Checked &&
                    !chk_talba.Checked && !chk_amlin.Checked &&
                    !chk_maliat.Checked)
                {
                    MSG.ErrorMesg("اختر القسم ..!");
                    chk_admin.Focus();
                    return;
                }

                if (permission_id == 0)
                {
                    MSG.ErrorMesg("اختر الصلاحية ..!");
                    chk_some_perm.Focus();
                    Waiting.Stop();
                    return;
                }


                try
                {
                    Waiting.Start();

                    // Update User Prams
                    if (new_role_id != 0) 
                    { 
                        users.Update_User_Permission(
                            new_role_id,
                            Convert.ToInt32(txt_user_role_id.Text),
                            permission_id,
                            Convert.ToInt32(txt_role_permissions_id.Text));
                        MSG.MyMesg(txt_user.Text + "  تم تعديل صلاحيات المستخدم بنجاح...!  ");
                        MAIN.FRM_SETTINGS.Get_Frm_Settings.dt_users_data.DataSource = users.Get_Users();
                    }
                }
                catch(Exception ex)
                {
                    MSG.ErrorMesg(ex.Message);
                    Waiting.Stop();
                    this.Close();
                }
                this.Close();
            } 

            if (BL.Globals.Add_User_Permission)
            {
                // Add User Permissions

                if (!chk_admin.Checked && !chk_takimat.Checked &&
                    !chk_talba.Checked && !chk_amlin.Checked &&
                    !chk_maliat.Checked)
                {
                    MSG.ErrorMesg("اختر القسم ..!");
                    chk_admin.Focus();
                    return;
                }

                if (permission_id == 0)
                {
                    MSG.ErrorMesg("اختر الصلاحية ..!");
                    chk_some_perm.Focus();
                    Waiting.Stop();
                    return;
                }

                try
                {
                    Waiting.Start();

                    // Add User Permissions

                    //Copmare User Permissions
                    int compare_role = role_id + role_id_2 + role_id_3 + role_id_4 + role_id_5;
                    if (compare_role != old_role_id )
                    {
                        users.Add_User_Permission(
                            Convert.ToInt32(txt_user_id.Text),
                            compare_role,
                            permission_id);

                        MSG.MyMesg(txt_user.Text + "  تم إضافة  صلاحيات للمستخدم بنجاح...!  ");
                        MAIN.FRM_SETTINGS.Get_Frm_Settings.dt_users_data.DataSource = users.Get_Users();
                    }
                    else
                    {
                        MSG.ErrorMesg("لا يوجد تغيير فى الصلاحيات .. لم تتم الإضافة .. !");
                        Waiting.Stop();
                        return;
                    }
                                           
                    MAIN.FRM_SETTINGS.Get_Frm_Settings.dt_users_data.DataSource = users.Get_Users();
                    Waiting.Stop();
                }
                catch (Exception ex)
                {
                    MSG.ErrorMesg(ex.Message);
                    Waiting.Stop();
                    this.Close();
                }
                this.Close();

            }
           
            Waiting.Stop();

        }
    }
}
