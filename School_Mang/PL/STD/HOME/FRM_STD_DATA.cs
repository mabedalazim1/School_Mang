using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace School_Mang.PL.STD.HOME
{
    public partial class FRM_STD_DATA : Form
    {
        BL.STD.CLS_STD std = new BL.STD.CLS_STD();
        BL.MSG msg = new BL.MSG();
        BL.Waiting waiting = new BL.Waiting();
        CLS_STD_FUNCATIONS Func = new CLS_STD_FUNCATIONS();

        int permission_id = Properties.Settings.Default.permission_id;
        // Form Closed
        private static FRM_STD_DATA frm_Std_Data;
        static void frm_Form_Closed(object sender, FormClosedEventArgs e)
        {
            frm_Std_Data = null;
        }
        public static FRM_STD_DATA Get_Frm_Std_Data
        {
            get
            {
                if (frm_Std_Data == null)
                {
                    frm_Std_Data = new FRM_STD_DATA();
                    frm_Std_Data.FormClosed += new FormClosedEventHandler(frm_Form_Closed);
                }
                return frm_Std_Data;
            }
        }

        public FRM_STD_DATA()
        {
            InitializeComponent();

            if (frm_Std_Data == null)
            {
                frm_Std_Data = this;
            }

            // Set User permission
            switch (permission_id)
            {
                case 3:
                    card_new.Visible = false;
                    break;
                case 1:
                case 2:
                    card_new.Visible = true;
                    break;
            }
        }



        private void lbl_current_stds_Click(object sender, EventArgs e)
        {
            waiting.Wait();
            BL.Globals.Current_Year_Data = true;
            FRM_CHOOSE_GRADE frm = new FRM_CHOOSE_GRADE();
            frm.ShowDialog(MAIN.FRM_MAIN.Get_Frm_Main);
        }

        private void lbl_back_Click(object sender, EventArgs e)
        {
            Func.changePages(MAIN.FRM_TALABA.Get_Frm_Talaba.pn_home);
        }

        private void lbl_show_stds_Click(object sender, EventArgs e)
        {
            DataTable Dt = std.Get_All_Std_Data(0);
            if (Dt.Rows.Count == 0)
            {
                msg.ErrorMesg("لم يتم تسجيل طلاب جدد لهذا العام .. !");
                return;
            }

            FRM_GET_STD.Get_Student.ShowDialog(); // frm = new FRM_GET_STD();

            //frm.ShowDialog();
        }

        private void lbl_get_osra_data_Click(object sender, EventArgs e)
        {
            BL.Globals.Open_Form_Get_osra = true;
            FRM_GET_OSRAA.Get_Osra_data.ShowDialog();
        }

        private void lbl_add_std_Click(object sender, EventArgs e)
        {
            BL.Globals.Open_Form_Get_osra = false;
            FRM_ADD_STD.getAdd_Std_Frm.ShowDialog(); //frm = new FRM_ADD_STD();
                                                     //frm.ShowDialog();

        }

        private void pic_current_stds_Click(object sender, EventArgs e)
        {
            lbl_current_stds_Click(sender, e);
        }

        private void pic_add_std_Click(object sender, EventArgs e)
        {
            lbl_add_std_Click(sender, e);
        }

        private void pic_get_osra_data_Click(object sender, EventArgs e)
        {
            lbl_get_osra_data_Click(sender, e);
        }

        private void pic_show_stds_Click(object sender, EventArgs e)
        {
            lbl_show_stds_Click(sender, e);
        }

        private void lbl_next_year_Click(object sender, EventArgs e)
        {
            BL.Globals.Current_Year_Data = false;
            FRM_CHOOSE_GRADE frm = new FRM_CHOOSE_GRADE();
            frm.ShowDialog(MAIN.FRM_MAIN.Get_Frm_Main);

        }

        private void pic_next_year_Click(object sender, EventArgs e)
        {
            lbl_next_year_Click(sender, e);
        }

        private void pic_back_Click(object sender, EventArgs e)
        {
            lbl_back_Click(sender, e);
        }

        public void lbl_tahwelat_Click(object sender, EventArgs e)
        {

            FRM_TAHWELAT.Get_Frm_Tahwelat.ShowDialog();
        }

        private void pic_tahwelat_Click(object sender, EventArgs e)
        {
            lbl_tahwelat_Click(sender, e);
        }

        private void lbl_std_details_Click(object sender, EventArgs e)
        {
            BL.Globals.Details_Std = true;
            FRM_CURRENT_STD.Get_Current_Std.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            lbl_std_details_Click(sender, e);
        }

        private void lbl_update_std_data_Click(object sender, EventArgs e)
        {
            DataTable dt_verify_std;
            int year = Properties.Settings.Default.year_cod;
            int new_year = year + 1;


            if (msg.DialogeMsg("هل تريد ترحيل بيانات العام الحالى ..!") == DialogResult.Yes)
            {
                // Update Student New Year Data

                waiting.Wait();
                DataTable Dt = std.Get_School_year_Data(year, 0, 0);
                if (Dt.Rows.Count == 0)
                {
                    msg.ErrorMesg("لا يوجد بيانات مسجلة .. !");
                    waiting.End_WAit();
                    return;
                }
                else
                {
                    try
                    {

                        foreach (DataRow row in Dt.Rows)
                        {
                            int new_grade = 0;
                            int new_class_id = 0;
                            string std_code = row["std_code"].ToString();
                            int grade = Convert.ToInt32(row["Grade_Id"]);
                            int std_status = Convert.ToInt32(row["Std_Status_Id"]);
                            int claas_id = Convert.ToInt32(row["Class_Id"]);
                            switch (grade)
                            {
                                case 10:
                                    new_grade = 11;
                                    new_class_id = claas_id + 2;

                                    break;
                                case 11:
                                    new_grade = 1;
                                    new_class_id = claas_id + 2;

                                    break;
                                case 1:
                                case 2:
                                case 3:
                                case 4:
                                case 5:
                                    new_grade = grade + 1;
                                    new_class_id = claas_id + 3;
                                    break;
                                case 6:
                                    new_grade = grade + 1;
                                    if(claas_id == 20)
                                    {
                                        new_class_id = 23;
                                    }
                                    else
                                    {
                                        new_class_id = 24;
                                    }
                                    break;
                                case 7:
                                case 8:
                                    new_grade = grade + 1;
                                    new_class_id = claas_id + 2;
                                    break;
                                case 9:
                                    new_grade = 0;
                                    break;

                                default:
                                    new_grade = 0;
                                    break;
                            }

                            dt_verify_std = std.Verify_Std_School_Code(std_code, new_year);
                            if (dt_verify_std.Rows.Count != 0)
                            {
                                // Delete Std
                                if (std_status == 3 || std_status == 6 || new_grade == 0)
                                {
                                    std.Delete_School_Std_Data(std_code, new_year);
                                }
                                else
                                {
                                    // Update Std
                                    std.Update_New_School_Std(
                                    std_code,
                                    new_grade,
                                    2,
                                    new_class_id,
                                    new_year);
                                }

                            }
                            else
                            {
                                // Add New School Std
                                if (new_grade != 0 && std_status != 6 && std_status != 3 )
                                {

                                    std.Add_School_Std_Data(
                                        std_code,
                                        new_year,
                                        new_grade,
                                        2,
                                        new_class_id);
                                }
                            }

                        }
                        waiting.End_WAit();
                        msg.MyMesg("تم تحديث بيانات العام الجديد بنجاح");
                        // Update data
                        DataTable dt_count;
                        dt_count = std.Get_School_year_Data(new_year, 0, 0);
                        if (dt_count.Rows.Count != 0)
                        {
                            FRM_STD_DATA.Get_Frm_Std_Data.card_new_year.Visible = true;
                        }

                    }
                    catch (Exception ex)
                    {
                        msg.ErrorMesg(ex.Message);
                        waiting.End_WAit();
                        return;
                    }
                }

            }
            else
            {
                waiting.End_WAit();
                msg.ErrorMesg("تم إلغاء تحديث بيانات العام الجديد..!");
            }
        }

        private void pic_update_std_data_Click(object sender, EventArgs e)
        {
            lbl_update_std_data_Click(sender, e);
        }

        private void lbl_to_excel_Click(object sender, EventArgs e)
        {
            FRM_TOEXCEL.get_frm_To_Excel.ShowDialog();
        }

        private void pic_to_excel_Click(object sender, EventArgs e)
        {
            lbl_to_excel_Click(sender, e);
        }
    }
}
