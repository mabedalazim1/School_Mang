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
using School_Mang.BL.Common.Helper;
using School_Mang.BL;

namespace School_Mang.PL.MAIN
{
    public partial class FRM_MANGE_SITE : Form
    {
        // Async Data
        readonly BL.SITE.CLS_Merge_Data Merge_Data = new BL.SITE.CLS_Merge_Data();

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
        new readonly BL.SITE.CLS_MANGE_SITE Site = new BL.SITE.CLS_MANGE_SITE();
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
            Waiting.Start();
            user_code = Site.Get_User_Code();
            std_code = std.Get_Kaema_Data(year, 0);
            if (get_msg)
            {
                MSG.MyMesg("عدد الطلاب المسجلين فى قاعدة البيانات  : " + std_code.Rows.Count.ToString());
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
                    MSG.ErrorMesg("لا توجد بيانات غير متطابقة..!");
                }
                has_data = false;
            }
            Waiting.Stop();
            return has_data;
        }

        private Boolean Get_Site_Data(bool get_msg = false)
        {
            bool has_data;
            Waiting.Start();
            user_code = Site.Get_User_Code();
            std_code = std.Get_Kaema_Data(year, 0);

            if (get_msg)
            {
                MSG.MyMesg("عدد الطلاب المسجلين فى الموقع  : " + user_code.Rows.Count.ToString());
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
                    MSG.ErrorMesg("لا توجد بيانات غير متطابقة..!");
                }
                has_data = false;
            }
            Waiting.Stop();
            return has_data;
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
                MSG.ErrorMesg(ex.Message);
            }
        }

        private void pic_users_Click(object sender, EventArgs e)
        {
            lbl_users_Click(sender, e);
        }

        private async void lbl_final_test_Click(object sender, EventArgs e)
        {
            if (!await InternetFlow.EnsureAsync())
                return;

            try
            {

                // Load Data
                if (Get_Std_Data(true))
                {
                    MSG.MyMesg(" غير موجود في قاعدة الطلاب: " + unmatchedDataBase.Rows.Count.ToString());
                }
                else
                {
                    MSG.ErrorMesg("لا يوجد طلاب غير مسجل لهم مستخدم على الموقع  ..!");
                }


                if (Get_Site_Data(true))
                {
                    MSG.MyMesg(" غير موجود في قاعدة الطلاب: " + unmatchedSite.Rows.Count.ToString());
                }
                else
                {
                    MSG.ErrorMesg("لا يوجد طلاب غير مسجلين في قاعدة البيانات ..!");
                }
            }
            catch (Exception ex)
            {
                MSG.ErrorMesg(ex.Message);
                Waiting.Stop();
            }
            finally
            {
                Waiting.Stop();
            }
            Waiting.Stop();
        }

        private void pic_final_test_Click(object sender, EventArgs e)
        {
            lbl_final_test_Click(sender, e);
        }

        private async void lbl_unmach_database_Click(object sender, EventArgs e)
        {
            if (!await InternetFlow.EnsureAsync())
                return;

            try
            {
                if (Get_Site_Data())
                {
                    BL.Globals.Get_Site_Data = true;
                    FRM_UNMATCH_DATA.Get_Frm_UnMatch_Data.Dt_Un_Mathed = unmatchedSite;
                    FRM_UNMATCH_DATA.Get_Frm_UnMatch_Data.ShowDialog();
                }
                else
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MSG.ErrorMesg(ex.Message);
            }

        }

        private void pic_unmach_database_Click(object sender, EventArgs e)
        {
            lbl_unmach_database_Click(sender, e);
        }

        public async void lbl_unmach_site_Click(object sender, EventArgs e)
        {
            if (!await InternetFlow.EnsureAsync())
                return;

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
                MSG.ErrorMesg(ex.Message);
            }
        }

        private void pic_unmach_site_Click(object sender, EventArgs e)
        {
            lbl_unmach_site_Click(sender, e);
        }

        private void lbl_add_user_Click(object sender, EventArgs e)
        {
            MSG.ErrorMesg("هذا الإجراء غير متاح حالياً .. !");
            return;

        }

        private void pic_add_user_Click(object sender, EventArgs e)
        {
            lbl_add_user_Click(sender, e);
        }

        private void lbl_link_data_Click(object sender, EventArgs e)
        {
            MSG.ErrorMesg("لسه ما خلصش ..!");
        }

        private void pic_link_data_Click(object sender, EventArgs e)
        {

        }

        private void lbl_update_data_Click(object sender, EventArgs e)
        {
            MSG.ErrorMesg("هذا الإجراء غير متاح حالياً .. !");
            return;


            // Un Work 

            /* Begin **************************** Begin
             * 
            if (MSG.DialogeMsg("هل تريد تحديث بيانات الطلاب في الموقع ... ؟") == DialogResult.Yes)
            {
                MSG.MyExclamationMsg("هذا الإجراء سوف يستغرق بعض الوقت .. يرجي الإنتطار ..!");

                try
                {
                    BL.SITE.CLS_ADD_USER add_user = new BL.SITE.CLS_ADD_USER();
                    add_user.Update_Site_Data();
                }
                catch (Exception ex)
                {
                    MSG.ErrorMesg(ex.Message);
                }
            }
            else
            {
                MSG.ErrorMesg("تم إلفاء الإجراء ..!");
            }
            // End *************************************** End  
            */
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
            if (!await InternetFlow.EnsureAsync())
                return;

            // Get Std Data Form
            changePages(FRM_MANGE_LESSONS.Get_Mange_Lessons.pn_mange_lesson, "إدارة المقررات");

        }

        private void lbl_add_data_Click(object sender, EventArgs e)
        {
            using (var frm = new SITE.FRM_EDIT_DATA("تحديث المستخدمين", 10))
            {
                frm.ShowDialog();
            }
        }

        private void pic_add_data_Click(object sender, EventArgs e)
        {
            lbl_add_data_Click(sender, e);
        }

        private void lbl_add_studentd_Click(object sender, EventArgs e)
        {
            using (var frm = new SITE.FRM_EDIT_DATA("إضافة الطلاب", 11))
            {
                frm.ShowDialog();
            }
           
        }

        private void pic_add_studentd_Click(object sender, EventArgs e)
        {
            lbl_add_studentd_Click(sender, e);
        }

        private async void lbl_async_site_Click(object sender, EventArgs e)
        {
            if (!await InternetFlow.EnsureAsync())
                return;

            
            if (Properties.Settings.Default.Server_Name != "192.168.1.135")
            {
                if (MSG.DialogeErrMsg("هل تريد مزامنة قاعدة البيانات علي السيرفر ... ؟") == DialogResult.Yes)
                {
                    MSG.MyExclamationMsg("هذا الإجراء سوف يستغرق بعض الوقت .. يرجي الإنتطار ..!");
                    try
                    {
                        Merge_Data.SyncTable("OsraData", new string[] { "Osraa_Id" });
                        Merge_Data.SyncTable("StdData", new string[] { "std_code" });
                        Merge_Data.SyncTable("School_Std_Data", new string[] { "std_code", "Year_Id", "Grade_Id" });
                        Merge_Data.SyncTable("Final_Degrees", new string[] { "Golos", "Year_Id" });
                        Merge_Data.SyncTable("Transfers", new string[] { "Transfer_code" });
                    }
                    catch (Exception ex)
                    {
                        MSG.ErrorMesg(ex.Message);
                    }
                }
                else
                {
                    MSG.ErrorMesg("تم إلغاء الإجراء");
                    return;
                } 
            }
        }

        private void pic_async_site_Click(object sender, EventArgs e)
        {
            lbl_async_site_Click(sender, e);
        }
    }
}
