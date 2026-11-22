using Bunifu.Framework.UI;
using School_Mang.BL;
using School_Mang.BL.Services;
using School_Mang.BL.Services.Nateg;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace School_Mang.PL.NATIGA
{
    public partial class FRM_CHOSE_FINAL_DATA : Form, INavigationAware
    {

        private NavigationContext _context = new NavigationContext();
        private readonly RasdService _rasdService = new RasdService();
        private readonly ExcelExportService _excelExportService =
                                    new ExcelExportService();

        public void SetNavigation(NavigationContext context)
        {
            _context = context ?? new NavigationContext();

            if (_context.Natiga == null)
            {
                lbl_title.Text = "بيانات التنقل غير مكتملة";
                return;
            }

            if (_context.Natiga.AmalSana)
            {
                lbl_title.Text = "أعمال السنة";
            }
            else
            {
                lbl_title.Text = "درجات الإختبار";
            }

        }

        private readonly LookupService _stdData = new LookupService();

        public FRM_CHOSE_FINAL_DATA()
        {
            InitializeComponent();

            // Fill Combo
            Waiting.Start();
            try
            {
                cmb_grade.DataSource = _stdData.Get_grades();
                cmb_grade.DisplayMember = "GradeDesc";
                cmb_grade.ValueMember = "Grade_Id";

                Add_To_Comb_Test();
            }
            finally
            {
                Waiting.Stop();
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
            Close();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            btn_close_b_Click(sender, e);
        }

        private bool TryGetSaveLocation(BunifuThinButton2 btn,
                                        byte term,
                                        string fileName,
                                        out string saveAsLocation)
        {
            saveAsLocation = null;

            string folder = term == 1
                ? Properties.Settings.Default.save_Trm_A_path
                : Properties.Settings.Default.save_Trm_B_path;

            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);

            folderBrowserDialog1.SelectedPath = folder;

            DialogResult result = folderBrowserDialog1.ShowDialog();

            if (result != DialogResult.OK)
            {
                MSG.ErrorMesg("يرجى اختيار مسار الحفظ .. !");
                btn.Focus();
                return false;
            }

            saveAsLocation = Path.Combine(
                                folderBrowserDialog1.SelectedPath,
                                fileName.TrimStart('\\')
                            );

            if (File.Exists(saveAsLocation))
            {
                if (MSG.DialogeErrMsg(
                    "الصف المحدد تم تصديره سابقاً .. سوف يتم حذف الملف .. هل تريد المتابعة ؟")
                    == DialogResult.No)
                {
                    MSG.ErrorMesg("تم إلغاء الإجراء ..!");
                    btn.Focus();
                    return false;
                }
            }

            return true;
        }

        private void Add_To_Comb_Test()
        {
            Dictionary<int, string> comboSource = new Dictionary<int, string>();
            comboSource.Add(1, "نصف العام");
            comboSource.Add(2, "أخر العام");

            cmb_test.DataSource = new BindingSource(comboSource, null);
            cmb_test.DisplayMember = "Value";
            cmb_test.ValueMember = "Key";
        }

        private void ExportAmalToExcel(BunifuThinButton2 btn, byte term)
        {
            if (term != 1 && term != 2)
            {
                MSG.ErrorMesg("الفصل الدراسي المحدد غير صحيح.");
                return;
            }

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

                default:
                    MSG.MyMesg("لا توجد ملفات للصف المحدد .. !");
                    return;
            }



            if (!TryGetSaveLocation(btn,
                                    term,
                                    file_name,
                                    out saveAsLocation))
            {
                return;
            }

            if (!File.Exists(staticExcelFile))
            {
                MSG.ErrorMesg("ملف قالب Excel غير موجود:\n" + staticExcelFile);
                return;
            }

            try
            {
                Waiting.Start();

                DataTable Dt_Rasd = _rasdService.GetRasdData(grade);
                if (Dt_Rasd == null)
                {
                    MSG.ErrorMesg("تعذر الحصول على بيانات الرصد.");
                    return;
                }

                if (_excelExportService.WriteAmalDataToExcel(
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
            }
            finally
            {
                Waiting.Stop();
            } 
        }

        private void ExportTestToExcel(BunifuThinButton2 btn, byte term)
        {
            if (term != 1 && term != 2)
            {
                MSG.ErrorMesg("الفصل الدراسي المحدد غير صحيح.");
                return;
            }

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

                default:
                    MSG.MyMesg("لا توجد ملفات للصف المحدد .. !");
                    return;
            }


            if (!TryGetSaveLocation(btn,
                                    term,
                                    file_name,
                                    out saveAsLocation))
            {
                return;
            }

            if (!File.Exists(staticExcelFile))
            {
                MSG.ErrorMesg("ملف قالب Excel غير موجود:\n" + staticExcelFile);
                return;
            }

            try
            {
                Waiting.Start();

                DataTable Dt_Rasd = _rasdService.GetRasdData(grade, 1);
                if (Dt_Rasd == null)
                {
                    MSG.ErrorMesg("تعذر الحصول على بيانات الرصد.");
                    return;
                }

                if (_excelExportService.WriteTestDataToExcel(Dt_Rasd, grade_desc, saveAsLocation,
                                                title, staticExcelFile, test_kind, grade_data,
                                                year_data, term_kind, grade, term_id))
                {
                    MSG.MyMesg("تم إعداد الملف بنجاح !");
                    MSG.MyMesg(saveAsLocation + "  مسار الملف هو  ");
                }
            }
            catch (Exception ex)
            {
                MSG.ErrorMesg(ex.Message);
            }
            finally 
            {
                Waiting.Stop();
            } 
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            if (_context?.Natiga == null)
            {
                MSG.ErrorMesg("بيانات التنقل غير مكتملة، يرجى فتح الشاشة مرة أخرى.");
                return;
            }

            try
            {
                byte term = Convert.ToByte(cmb_test.SelectedValue);

                if (_context.Natiga.AmalSana)
                {
                    ExportAmalToExcel(btn_ok, term);
                }
                else
                {
                    ExportTestToExcel(btn_ok, term);
                }
            }
            catch (Exception ex)
            {
                MSG.ErrorMesg(ex.Message);
            }
        }
    }
}
