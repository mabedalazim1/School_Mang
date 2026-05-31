using Bunifu.Framework.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using School_Mang.BL;
using School_Mang.BL.Services;

namespace School_Mang.PL.NATIGA
{
    public partial class FRM_CHOSE_FINAL_DATA : Form
    {

        BL.STD.CLS_STD std = new BL.STD.CLS_STD();
        BL.NATEG.CLS_NATEG nateg = new BL.NATEG.CLS_NATEG();
        BL.NATEG.ExcelUtlity Excel = new BL.NATEG.ExcelUtlity();
        private readonly LookupService _stdData = new LookupService();

        public FRM_CHOSE_FINAL_DATA()
        {
            InitializeComponent();

            // Fill Combo
            Waiting.Start();
            cmb_grade.DataSource = _stdData.Get_grades();
            cmb_grade.DisplayMember = "GradeDesc";
            cmb_grade.ValueMember = "Grade_Id";

            Add_To_Comb_Test();
            Waiting.Stop();

        }

        private void Add_To_Comb_Test()
        {
            Dictionary<int, string> comboSource = new Dictionary<int, string>();
            comboSource.Add(1, "نصف العام");
            comboSource.Add(2, "أخر العام");

            cmb_test.DataSource = new BindingSource(comboSource, null);
            cmb_test.DisplayMember = "Value";
            cmb_test.ValueMember = "Key";

            if (BL.Globals.Amal_Sana == true)
            {
                lbl_title.Text = "أعمال السنة";
            }
            else
            {
                lbl_title.Text = "درجات الإختبار";
            }
        }

        private void ExportAmalToExcel(BunifuThinButton2 btn, byte term)
        {
            string term_kind;
            string test_kind = "أعمال السنة";
            string grade_data = cmb_grade.Text;
            string year_data = Properties.Settings.Default.Year_Desc;
            byte term_id;

            string title;
            string file_name;
            string saveAsLocation;

            short grade = Convert.ToInt16(cmb_grade.SelectedValue);

            string staticExcelFile = AppDomain.CurrentDomain.BaseDirectory;
            string grade_desc = cmb_grade.Text + " - (" +
                Properties.Settings.Default.Year_Desc + ")";

            if (term == 1)
            {
                term_id = 1;
                term_kind = "الترم الأول";
                title = " أعمال السنة - الفصل الدراسى الأول - الصف " + grade_desc;
                file_name = @"\" + "أعمال السنة - ترم أول  -" + grade_desc + ".xlsx";
            }
            else
            {
                term_id = 2;
                term_kind = "الترم الثانى";
                title = " أعمال السنة - الفصل الدراسى الثاني - الصف " + grade_desc;
                file_name = @"\" + "أعمال السنة - ترم ثاني  -" + grade_desc + ".xlsx";
            }

            byte prim = 0;
            // Get staticExcelFile Name
            switch (grade)
            {
                case 10:
                case 11:
                    MSG.MyMesg("لا توجد ملفات للصف المحدد .. !");
                    return;

                case 1:
                case 2:
                    prim = 1;
                    if (term == 1)
                    {
                        staticExcelFile = staticExcelFile + @"Excel\Final\Term_A\Term_A_0.xlsx";
                    }
                    else
                    {
                        staticExcelFile = staticExcelFile + @"Excel\Final\Term_B\Term_B_0.xlsx";
                    }

                    break;

                case 3:
                    prim = 2;
                    if (term == 1)
                    {
                        staticExcelFile = staticExcelFile + @"Excel\Final\Term_A\Term_A_1.xlsx";
                    }
                    else
                    {
                        staticExcelFile = staticExcelFile + @"Excel\Final\Term_B\Term_B_1.xlsx";
                    }
                    break;

                case 4:
                case 5:
                case 6:
                    prim = 3;
                    if (term == 1)
                    {
                        staticExcelFile = staticExcelFile + @"Excel\Final\Term_A\Term_A_2.xlsx";
                    }
                    else
                    {
                        staticExcelFile = staticExcelFile + @"Excel\Final\Term_B\Term_B_2.xlsx";
                    }

                    break;

                case 7:
                case 8:
                case 9:
                    if (term == 1)
                    {
                        staticExcelFile = staticExcelFile + @"Excel\Final\Term_A\Term_A_3.xlsx";
                    }
                    else
                    {
                        staticExcelFile = staticExcelFile + @"Excel\Final\Term_B\Term_B_3.xlsx";
                    }
                    break;
            }



            // Folder Path
            string folder = "";

            if (term == 1)
            {
                folder = Properties.Settings.Default.save_Trm_A_path;
            }
            else
            {
                folder = Properties.Settings.Default.save_Trm_B_path;
            }
            bool exists = Directory.Exists(folder);
            if (!exists) Directory.CreateDirectory(folder);
            folderBrowserDialog1.SelectedPath = folder;

            // Show the FolderBrowserDialog.  
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result != DialogResult.OK)
            {
                MSG.ErrorMesg("يرجى اختيار مسار الحفظ .. !");
                btn.Focus();
                return;
            }
            else
            {
                saveAsLocation = folderBrowserDialog1.SelectedPath.ToString() + file_name;

                if (File.Exists(saveAsLocation))
                {
                    if (MSG.DialogeErrMsg("الصف المحدد تم تصديره سابقاً .. سوف يتم حذف الملف  .. هل تريد المتابعة ؟") == DialogResult.No)
                    {
                        MSG.ErrorMesg("تم إلغاء الإجراء ..!");
                        btn.Focus();
                        return;
                    }
                }
            }
            Waiting.Start();
            try
            {
                DataTable Dt_Rasd = nateg.Get_Rasd_Data(grade);
                if (Excel.WriteAmalDataToExcel(
                    Dt_Rasd, grade_desc, saveAsLocation, title,
                    staticExcelFile, test_kind, grade_data,
                    year_data, term_kind,grade,term_id, prim))
                {
                    MSG.MyMesg("تم إعداد الملف بنجاح !");
                    MSG.MyMesg(saveAsLocation + "  مسار الملف هو  ");
                }
            }
            catch (Exception ex)
            {
                MSG.ErrorMesg(ex.Message);
                Waiting.Stop();
            }
            Waiting.Stop();
        }

        private void ExportTestToExcel(BunifuThinButton2 btn, byte term)
        {
            string term_kind;
            string test_kind = "درجات الإختبار";
            string grade_data = cmb_grade.Text;
            string year_data = Properties.Settings.Default.Year_Desc;
            byte term_id;

            string title;
            string file_name;
            string saveAsLocation;

            short grade = Convert.ToInt16(cmb_grade.SelectedValue);

            string staticExcelFile = AppDomain.CurrentDomain.BaseDirectory;
            string grade_desc = cmb_grade.Text + " - (" +
                Properties.Settings.Default.Year_Desc + ")";

            if (term == 1)
            {
                term_id = 1;
                term_kind = "الترم الأول";
                title = " إختبار الفصل الدراسى الأول - الصف " + grade_desc;
                file_name = @"\" + "إختبار الترم الأول  -" + grade_desc + ".xlsx";
            }
            else
            {
                term_id = 2;
                term_kind = "الترم الثاني";
                title = " إختبار الفصل الدراسى الثاني - الصف " + grade_desc;
                file_name = @"\" + "إختبار الترم الثاني  -" + grade_desc + ".xlsx";
            }

            // Get staticExcelFile Name
            switch (grade)
            {
                case 10:
                case 11:
                case 1:
                case 2:
                    MSG.MyMesg("لا توجد ملفات للصف المحدد .. !");
                    return;
                case 3:
                    if (term == 1)
                    {
                        staticExcelFile = staticExcelFile + @"Excel\Final\Term_A\Term_A_1_Test.xlsx";
                    }
                    else
                    {
                        term_kind = "الترم الثاني";
                        staticExcelFile = staticExcelFile + @"Excel\Final\Term_B\Term_B_1_Test.xlsx";
                    }

                    break;

                case 4:
                case 5:
                case 6:
                    if (term == 1)
                    {
                        staticExcelFile = staticExcelFile + @"Excel\Final\Term_A\Term_A_2_Test.xlsx";
                    }
                    else
                    {
                        term_kind = "الترم الثاني";
                        staticExcelFile = staticExcelFile + @"Excel\Final\Term_B\Term_B_2_Test.xlsx";
                    }

                    break;

                case 7:
                case 8:
                case 9:
                    if (term == 1)
                    {
                        staticExcelFile = staticExcelFile + @"Excel\Final\Term_A\Term_A_3_Test.xlsx";
                    }
                    else
                    {
                        staticExcelFile = staticExcelFile + @"Excel\Final\Term_B\Term_B_3_Test.xlsx";
                    }
                    break;
            }



            // Folder Path
            string folder = "";

            if (term == 1)
            {
                folder = Properties.Settings.Default.save_Trm_A_path;
            }
            else
            {
                folder = Properties.Settings.Default.save_Trm_B_path;
            }
            bool exists = Directory.Exists(folder);
            if (!exists) Directory.CreateDirectory(folder);
            folderBrowserDialog1.SelectedPath = folder;

            // Show the FolderBrowserDialog.  
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result != DialogResult.OK)
            {
                MSG.ErrorMesg("يرجى اختيار مسار الحفظ .. !");
                btn.Focus();
                return;
            }
            else
            {
                saveAsLocation = folderBrowserDialog1.SelectedPath.ToString() + file_name;

                if (File.Exists(saveAsLocation))
                {
                    if (MSG.DialogeErrMsg("الصف المحدد تم تصديره سابقاً .. سوف يتم حذف الملف  .. هل تريد المتابعة ؟") == DialogResult.No)
                    {
                        MSG.ErrorMesg("تم إلغاء الإجراء ..!");
                        btn.Focus();
                        return;
                    }
                }
            }
            Waiting.Start();
            try
            {
                DataTable Dt_Rasd = nateg.Get_Rasd_Data(grade, 1);
                if (Excel.WriteTestDataToExcel(Dt_Rasd, grade_desc, saveAsLocation,
                                                title, staticExcelFile, test_kind, grade_data,
                                                year_data, term_kind,grade,term_id))
                {
                    MSG.MyMesg("تم إعداد الملف بنجاح !");
                    MSG.MyMesg(saveAsLocation + "  مسار الملف هو  ");
                }
            }
            catch (Exception ex)
            {
                MSG.ErrorMesg(ex.Message);
                Waiting.Stop();
            }
            Waiting.Stop();
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

        private void btn_close_b_Click(object sender, EventArgs e)
        {
            BL.Globals.Amal_Sana = false;
            BL.Globals.Final_Test = false;
            Close();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            btn_close_b_Click(sender, e);
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {

            try
            {
                if (BL.Globals.Amal_Sana)
                {
                    if (Convert.ToInt32(cmb_test.SelectedValue) == 1)
                    {
                        ExportAmalToExcel(btn_ok, 1);
                    }
                    else
                    {
                        ExportAmalToExcel(btn_ok, 2);
                    }
                }
                else
                {
                    if (Convert.ToInt32(cmb_test.SelectedValue) == 1)
                    {
                        ExportTestToExcel(btn_ok, 1);
                    }
                    else
                    {
                        ExportTestToExcel(btn_ok, 2);
                    }

                }
            }
            catch (Exception ex)
            {
                MSG.ErrorMesg(ex.Message);
            }
        }

        private void FRM_CHOSE_FINAL_DATA_Load(object sender, EventArgs e)
        {
           if(BL.Globals.Amal_Sana)
            {
                lbl_title.Text = "أعمال السنة";
                
            }
            else
            {
                lbl_title.Text = "درجات الإختبار";
              
            }
        }
    }
}
