using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using School_Mang.PL.SITE;

namespace School_Mang.PL.MAIN
{
    public partial class FRM_MANGE_SITE : Form
    {
        // Form Closed
        private static FRM_MANGE_SITE frm_Mange_Site;
        static void frm_Form_Closed(object sender, FormClosedEventArgs e)
        {
            frm_Mange_Site = null;
        }
        public static FRM_MANGE_SITE Get_Frm_Mange_Site
        {
            get
            {
                if (frm_Mange_Site == null)
                {
                    frm_Mange_Site = new FRM_MANGE_SITE();
                    frm_Mange_Site.FormClosed += new FormClosedEventHandler(frm_Form_Closed);
                }
                return frm_Mange_Site;
            }
        }


        public FRM_MANGE_SITE()
        {
            InitializeComponent();

            if (frm_Mange_Site == null)
            {
                frm_Mange_Site = this;
            }
        }

        BL.NATEG.cls_NATAG_FUNCTIONS natag_func = new BL.NATEG.cls_NATAG_FUNCTIONS();
        BL.MSG msg = new BL.MSG();
        new readonly BL.SITE.CLS_MANGE_SITE Site = new BL.SITE.CLS_MANGE_SITE();
        BL.Waiting Waiting = new BL.Waiting();
        BL.STD.CLS_STD std = new BL.STD.CLS_STD();


        int year = Properties.Settings.Default.year_cod;
        DataTable user_code;
        DataTable std_code;
        DataTable unmatchedDataBase;
        DataTable unmatchedSite;

        private void changePages(Panel pn, string lbl)
        {
            FRM_MAIN.Get_Frm_Main.pn_home.Visible = false;
            FRM_MAIN.Get_Frm_Main.pn_main.Controls.Clear();
            FRM_MAIN.Get_Frm_Main.pn_main.Visible = false;
            FRM_MAIN.Get_Frm_Main.lbl_main.Text = lbl;
            FRM_MAIN.Get_Frm_Main.lbl_main.Visible = false;
            FRM_MAIN.Get_Frm_Main.pn_main.BringToFront();
            FRM_MAIN.Get_Frm_Main.pn_main.Controls.Add(pn);
            FRM_MAIN.Get_Frm_Main.trans_a.ShowSync(FRM_MAIN.Get_Frm_Main.pn_main);
            FRM_MAIN.Get_Frm_Main.lbl_main.Visible = true;
        }

        private Boolean Get_Std_Data(bool get_msg = false)
        {
            bool has_data;
            Waiting.Wait();
            user_code = Site.Get_User_Code();
            std_code = std.Get_Kaema_Data(year, 0);
            if (get_msg)
            {
                msg.MyMesg("عدد الطلاب المسجلين فى قاعدة البيانات  : " + std_code.Rows.Count.ToString());
            }

            var unmatchedOnDataBase = from row1 in std_code.AsEnumerable()
                                      join row2 in user_code.AsEnumerable()
                                      on row1.Field<int>("Golos") equals row2.Field<int>("Golos") into joined
                                      from row2 in joined.DefaultIfEmpty()
                                      where row2 == null
                                      select row1;
            if (unmatchedOnDataBase.Count() != 0)
            {
                unmatchedDataBase = unmatchedOnDataBase.CopyToDataTable();
                has_data = true;
            }
            else
            {
                if (!get_msg)
                {
                    msg.ErrorMesg("لا توجد بيانات غير متطابقة..!");
                }
                has_data = false;
            }
            Waiting.End_WAit();
            return has_data;
        }

        private Boolean Get_Site_Data(bool get_msg = false)
        {
            bool has_data;
            Waiting.Wait();
            user_code = Site.Get_User_Code();
            std_code = std.Get_Kaema_Data(year, 0);

            if (get_msg)
            {
                msg.MyMesg("عدد الطلاب المسجلين فى الموقع  : " + user_code.Rows.Count.ToString());
            }
            var unmatchedOnSite = from row1 in user_code.AsEnumerable()
                                  join row2 in std_code.AsEnumerable()
                                  on row1.Field<int>("Golos") equals row2.Field<int>("Golos") into joined
                                  from row2 in joined.DefaultIfEmpty()
                                  where row2 == null
                                  select row1;

            if (unmatchedOnSite.Count() != 0)
            {
                unmatchedSite = unmatchedOnSite.CopyToDataTable();
                has_data = true;
            }
            else
            {
                if (!get_msg)
                {
                    msg.ErrorMesg("لا توجد بيانات غير متطابقة..!");
                }
                has_data = false;
            }
            Waiting.End_WAit();
            return has_data;
        }
        private async Task Test_Intrent()
        {
            Waiting.Wait();
            //Test Intrent Connection
            BL.CLS_TEST_INTRNET_CON test_intrent = new BL.CLS_TEST_INTRNET_CON();
            await test_intrent.ChecK_Internt_Con();
            Waiting.End_WAit();
        }

        private void lbl_back_Click(object sender, EventArgs e)
        {
            natag_func.changePages(FRM_SETTINGS.Get_Frm_Settings.pn_home, "الإعدادات");
        }

        private void lbl_users_Click(object sender, EventArgs e)
        {
            try
            {
                FRM_COUNT_USERS.Get_Frm_Count_Users.ShowDialog();
            }
            catch (Exception ex)
            {
                msg.ErrorMesg(ex.Message);
            }
        }

        private void pic_users_Click(object sender, EventArgs e)
        {
            lbl_users_Click(sender, e);
        }

        private async void lbl_final_test_Click(object sender, EventArgs e)
        {
            await Test_Intrent();
            if (!BL.Globals.Test_Internet_Con)
            {
                msg.ErrorMesg("تأكد من الإتصال بالإنترنت..!");
                return;
            }

            try
            {

                // Load Data
                if (Get_Std_Data(true))
                {
                    msg.MyMesg(" غير موجود في قاعدة الطلاب: " + unmatchedDataBase.Rows.Count.ToString());
                }
                else
                {
                    msg.ErrorMesg("لا يوجد طلاب غير مسجل لهم مستخدم على الموقع  ..!");
                }


                if (Get_Site_Data(true))
                {
                    msg.MyMesg(" غير موجود في قاعدة الطلاب: " + unmatchedSite.Rows.Count.ToString());
                }
                else
                {
                    msg.ErrorMesg("لا يوجد طلاب غير مسجلين في قاعدة البيانات ..!");
                }
            }
            catch (Exception ex)
            {
                msg.ErrorMesg(ex.Message);
                Waiting.End_WAit();
            }
            finally
            {
                Waiting.End_WAit();
            }
            Waiting.End_WAit();
        }

        private void pic_final_test_Click(object sender, EventArgs e)
        {
            lbl_final_test_Click(sender, e);
        }

        private async void lbl_unmach_database_Click(object sender, EventArgs e)
        {
            await Test_Intrent();
            if (!BL.Globals.Test_Internet_Con)
            {
                msg.ErrorMesg("تأكد من الإتصال بالإنترنت..!");
                return;
            }

            try
            {
                if (Get_Site_Data()) 
                {
                    BL.Globals.Get_Site_Data = true;
                    FRM_UNMATCH_DATA.Get_Frm_UnMatch_Data.Dt_Un_Mathed = unmatchedSite ;
                    FRM_UNMATCH_DATA.Get_Frm_UnMatch_Data.ShowDialog();
                }
                else
                {
                    return;
                }
            }catch(Exception ex)
            {
                msg.ErrorMesg(ex.Message);
            }
            
        }

        private void pic_unmach_database_Click(object sender, EventArgs e)
        {
            lbl_unmach_database_Click(sender, e);
        }

        public async void lbl_unmach_site_Click(object sender, EventArgs e)
        {
            await Test_Intrent();
            if (!BL.Globals.Test_Internet_Con)
            {
                msg.ErrorMesg("تأكد من الإتصال بالإنترنت..!");
                return;
            }

            try
            {
                if (Get_Std_Data())
                {
                    BL.Globals.Get_Site_Data = false;
                    FRM_UNMATCH_DATA.Get_Frm_UnMatch_Data.Dt_Un_Mathed = unmatchedDataBase;
                    FRM_UNMATCH_DATA.Get_Frm_UnMatch_Data.ShowDialog();
                }
                else
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                msg.ErrorMesg(ex.Message);
            }
        }

        private void pic_unmach_site_Click(object sender, EventArgs e)
        {
            lbl_unmach_site_Click(sender, e);
        }

        private void lbl_add_user_Click(object sender, EventArgs e)
        {
            msg.ErrorMesg("هذا الإجراء غير متاح حالياً .. !");
            return;

            // Un Work
            try
            {

                FRM_ADD_USER.Get_Add_User.ShowDialog();
                msg.ErrorMesg("لسه ما خلصش ..!");
            }catch(Exception ex)
            {
                msg.ErrorMesg(ex.Message);
            }
           
        }

        private void pic_add_user_Click(object sender, EventArgs e)
        {
            lbl_add_user_Click(sender, e);
        }

        private void lbl_link_data_Click(object sender, EventArgs e)
        {
            msg.ErrorMesg("لسه ما خلصش ..!");
        }

        private void pic_link_data_Click(object sender, EventArgs e)
        {
            
        }

        private void lbl_update_data_Click(object sender, EventArgs e)
        {
            msg.ErrorMesg("هذا الإجراء غير متاح حالياً .. !");
            return;

            // Un Work
            if (msg.DialogeMsg("هل تريد تحديث بيانات الطلاب في الموقع ... ؟") == DialogResult.Yes)
            {
                msg.MyExclamationMsg("هذا الإجراء سوف يستغرق بعض الوقت .. يرجي الإنتطار ..!");
                
                try
                {
                    BL.SITE.CLS_ADD_USER add_user = new BL.SITE.CLS_ADD_USER();
                    add_user.Update_Site_Data();
                }catch(Exception ex)
                {
                    msg.ErrorMesg(ex.Message);
                }
            }
            else
            {
                msg.ErrorMesg("تم إلفاء الإجراء ..!");
            }
        }

        private void pic_update_data_Click(object sender, EventArgs e)
        {
            lbl_update_data_Click(sender, e);
        }

        private void pic_study_Click(object sender, EventArgs e)
        {
            lbl_study_Click(sender, e);
        }

        private async void lbl_study_Click(object sender, EventArgs e)
        {
            await Test_Intrent();
            if (!BL.Globals.Test_Internet_Con)
            {
                msg.ErrorMesg("تأكد من الإتصال بالإنترنت..!");
                return;
            }
            // Get Std Data Form
            changePages(FRM_MANGE_LESSONS.Get_Mange_Lessons.pn_mange_lesson, "إدارة المقررات");
          
        }

        private void lbl_add_data_Click(object sender, EventArgs e)
        {
            SITE.FRM_EDIT_DATA.Get_Frm_Edid_Data.type = 10;
            SITE.FRM_EDIT_DATA.Get_Frm_Edid_Data.ShowDialog();
        }

        private void pic_add_data_Click(object sender, EventArgs e)
        {
            lbl_add_data_Click(sender, e);
        }

        private void lbl_add_studentd_Click(object sender, EventArgs e)
        {
            FRM_EDIT_DATA.Get_Frm_Edid_Data.type = 11;
            FRM_EDIT_DATA.Get_Frm_Edid_Data.lbl_title.Text = "إضافة الطلاب";
            FRM_EDIT_DATA.Get_Frm_Edid_Data.ShowDialog();
        }

        private void pic_add_studentd_Click(object sender, EventArgs e)
        {
            lbl_add_studentd_Click(sender, e);
        }
    }
}
