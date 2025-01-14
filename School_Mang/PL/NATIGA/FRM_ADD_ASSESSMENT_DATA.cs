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
    public partial class FRM_ADD_ASSESSMENT_DATA : Form
    {
        // Form Closed
        private static FRM_ADD_ASSESSMENT_DATA frm_Add_Assessment;
        static void frm_Form_Closed(object sender, FormClosedEventArgs e)
        {
            frm_Add_Assessment = null;
        }
        public static FRM_ADD_ASSESSMENT_DATA Get_Frm_Add_Assessment
        {
            get
            {
                if (frm_Add_Assessment == null)
                {
                    frm_Add_Assessment = new FRM_ADD_ASSESSMENT_DATA();
                    frm_Add_Assessment.FormClosed += new FormClosedEventHandler(frm_Form_Closed);
                }
                return frm_Add_Assessment;
            }
        }

        public FRM_ADD_ASSESSMENT_DATA()
        {
            InitializeComponent();
            if (frm_Add_Assessment == null)
            {
                frm_Add_Assessment = this;
            }

        }

        BL.MSG msg = new BL.MSG();
        BL.Waiting Waiting = new BL.Waiting();
        HTTP.HTTPCLINT HTTP = new HTTP.HTTPCLINT();
        BL.NATEG.CLS_NATEG Nateg = new BL.NATEG.CLS_NATEG();

        int move;
        int move_x;
        int move_y;

        private async Task Test_Intrent()
        {
            Waiting.Wait();
            //Test Intrent Connection
            BL.CLS_TEST_INTRNET_CON test_intrent = new BL.CLS_TEST_INTRNET_CON();
            await test_intrent.ChecK_Internt_Con();
            Waiting.End_WAit();
        }

        // Upload File
        private async Task UploadFile(string path)
        {
            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    await Test_Intrent();
                    if (!BL.Globals.Test_Internet_Con)
                    {
                        msg.ErrorMesg("تأكد من الإتصال بالإنترنت..!");
                        return;
                    }
                    await HTTP.UplodFile(openFileDialog1.FileName, path);
                }
                else
                {
                    msg.ErrorMesg("تم إلغاء الإجراء ..!");
                    BL.Globals.Dir_Path = "D://Rasd";
                }

            }
            catch (Exception ex)
            {
                msg.ErrorMesg(ex.Message);
            }

        }

        // Delete Assessment
        private void deleteAssement(int grade, int year, int term , string sp_name)
        {
            try
            {
                Waiting.Wait();

                Nateg.DeleteAssessmentFromSite(year, term, grade, sp_name);

                Waiting.End_WAit();
                msg.MyMesg("تم حذف البيان المحدد");
            }
            catch(Exception e)
            {
                msg.ErrorMesg(e.Message);
                Waiting.End_WAit();
            }
            
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_close_b_Click(object sender, EventArgs e)
        {
            btn_close_Click(sender, e);
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

        private void pn_top_MouseDown(object sender, MouseEventArgs e)
        {
            move = 1;
            move_x = e.X;
            move_y = e.Y;
        }

        private void FRM_ADD_ASSESSMENT_DATA_Load(object sender, EventArgs e)
        {
            cmb_subject.DisplayMember = "Text";
            cmb_subject.ValueMember = "Value";
            
            cmb_grade.DisplayMember = "Text";
            cmb_grade.ValueMember = "Value";

            cmb_year.DisplayMember = "Text";
            cmb_year.ValueMember = "Value";

            cmb_term.DisplayMember = "Text";
            cmb_term.ValueMember = "Value";


            var subjects = new[] {
            new { Text = "اللغة العربية", Value = "1" },
            new { Text = "الرياضيات", Value = "2" },
            new { Text = "العلوم", Value = "3" },
            new { Text = "الدراسات الإجتماعية", Value = "4" },
            new { Text = "اللغة الإنجليزية", Value = "5" },
            new { Text = "التربية الدينية", Value = "6" },
            new { Text = "المهارات أو الفنية", Value = "7" },
            new { Text = "الحاسب الآلي", Value = "8" },
            new { Text = "الغياب", Value = "9" },
            };

            var graeds = new[] {
            new { Text = "الأول الإبتدائي", Value = "1" },
            new { Text = "الثاني الإبتدائي", Value = "2" },
            new { Text = "الثالث الإبتدائي", Value = "3" },
            new { Text = "الرابع الإبتدائي", Value = "4" },
            new { Text = "الخامس الإبتدائي", Value = "5" },
            new { Text = "السادس الإبتدائي", Value = "6" },
            new { Text = "الأول الإعدادي", Value = "7" },
            new { Text = "الثاني الإعدادي", Value = "8" },
            new { Text = "الثالث الإعدادي", Value = "9" },
            };

            var years = new[] {
            new { Text = "2025-2024", Value = "4" },
            new { Text = "2026-2025", Value = "5" },
            new { Text = "2027-2026", Value = "6" },
            new { Text = "2028-2027", Value = "7" },
            new { Text = "2029-2028", Value = "8" },
            new { Text = "2030-2029", Value = "9" },
            new { Text = "2031-2030", Value = "10" },
            new { Text = "2032-2031", Value = "11" },
            new { Text = "2033-2032", Value = "12" },
            new { Text = "2034-20332", Value = "13" },
            new { Text = "2035-2034", Value = "14" },
            };

            var terms = new[] {
            new { Text = "الأول", Value = "1" },
            new { Text = "الثاني", Value = "2" },
            };

            cmb_subject.DataSource = subjects;
            cmb_grade.DataSource = graeds;
            cmb_year.DataSource = years;
            cmb_term.DataSource = terms;

            if (BL.Globals.Del_Assessment_Data)
            {
                cmb_grade.Enabled = true;
                label11.Text = "حذف درجات استمارة التقييم";
                btn_del.Visible = true;
                btn_show_data.Visible = false;
                cmb_year.Visible = true;
                cmb_term.Visible = true;
                lbl_term.Visible = true;
                lbl_year.Visible = true;
                lbl_info.Visible = false;
            }
            else
            {
                cmb_grade.Enabled = false;
                label11.Text = "إضافة درجات استمارة التقييم";
                btn_del.Visible = false;
                btn_show_data.Visible = true;
                cmb_year.Visible = false;
                cmb_term.Visible = false;
                lbl_term.Visible = false;
                lbl_year.Visible = false;
                lbl_info.Visible = true;
            }

        }

        private async void btn_show_data_Click(object sender, EventArgs e)
        {
            if (msg.DialogeErrMsg("سوف يتم رفع درجات استمارةالتقييم .. وسيتم حذف البيانات السابقة للصف المحدد .. هل تريد المتابعة ؟") == DialogResult.No)
            {
                msg.ErrorMesg("تم إلغاء الإجراء ..!");
                return;
            }
            else
            {
                if (msg.DialogeErrMsg("سوف يتم تغيير درجات مادة   " + cmb_subject.Text +" هل تريد المتابعة ؟ ..  ") == DialogResult.No)
                {
                    msg.ErrorMesg("تم إلغاء الإجراء ..!");
                    return;
                }
            }
            await Test_Intrent();
            if (!BL.Globals.Test_Internet_Con)
            {
                msg.ErrorMesg("تأكد من الإتصال بالإنترنت..!");
                return;
            }
            byte degree_kind = Convert.ToByte(cmb_subject.SelectedValue);
            string upload = "upload/";
            
            switch (degree_kind)
            {
                case 1:
                    upload += "asesarabic";
                    break;
                case 2:
                    upload += "asesmath";
                    break;
                case 3:
                    upload += "asesscince";
                    break;
                case 4:
                    upload += "asessocial";
                    break;
                case 5:
                    upload += "aseenglish";
                    break;
                case 6:
                    upload += "asesdain";
                    break;
                case 7:
                    upload += "asesmaharat";
                    break;
                case 8:
                    upload += "asestocnolegy";
                    break;
                case 9:
                    upload += "asesgiab"; 
                    break;
            }
            await UploadFile(upload);
        }

        private void btn_del_Click(object sender, EventArgs e)
        {
            if (msg.DialogeMsg("يرجي التأكد من العام والفصل الدراسي والمادة .. هل تريد المتابعة ؟") == DialogResult.No)
            {
                msg.ErrorMesg("تم إلغاء الإجراء ..!");
                return;
            }
            else
            {
                msg.MyExclamationMsg("سوف يتم حذف " + cmb_subject.Text + " - للصف " + cmb_grade.Text + " العام الدراسي " + cmb_year.Text);
            }
                if (msg.DialogeErrMsg("سوف يتم حذف درجات استمارةالتقييم للصف المحدد .. هل تريد المتابعة ؟") == DialogResult.No)
            {
                msg.ErrorMesg("تم إلغاء الإجراء ..!");
                return;
            }
            else
            {
                if (msg.DialogeErrMsg("سوف يتم حذف درجات مادة   " + cmb_subject.Text + " هل تريد المتابعة ؟ ..  ") == DialogResult.No)
                {
                    msg.ErrorMesg("تم إلغاء الإجراء ..!");
                    return;
                }
               
            }
            int year =Convert.ToInt32(cmb_year.SelectedValue);
            int term = Convert.ToInt32(cmb_term.SelectedValue);
            int grade = Convert.ToInt32(cmb_grade.SelectedValue);
            byte subject = Convert.ToByte(cmb_subject.SelectedValue);
            string sp_name = "";

            switch (subject)
            {
                case 1:
                    sp_name = "AsesArabic";
                    break;
                case 2:
                    sp_name = "AsesMath";
                    break;
                case 3:
                    sp_name = "AsesScince";
                    break;
                case 4:
                    sp_name = "AsesSocial";
                    break;
                case 5:
                    sp_name = "AsesEnglish";
                    break;
                case 6:
                    sp_name = "AsesDain";
                    break;
                case 7:
                    sp_name = "AsesMaharat";
                    break;
                case 8:
                    sp_name = "AsesTocnolegy";
                    break;
                case 9:
                    msg.ErrorMesg("لم يتم تخزين اجراء لهذه العملية ..!");
                    return;
            }
            deleteAssement(grade, year, term, sp_name);
                
        }
    }
}
