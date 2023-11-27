using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bunifu.Framework.UI;

namespace School_Mang.PL.NATIGA
{
    public partial class FRM_KSHOF_RASD : Form
    {

        BL.STD.CLS_STD std = new BL.STD.CLS_STD();
        BL.MSG msg = new BL.MSG();
        BL.Waiting waiting = new BL.Waiting();
        BL.NATEG.CLS_NATEG nateg = new BL.NATEG.CLS_NATEG();
        BL.NATEG.ExcelUtlity Excel = new BL.NATEG.ExcelUtlity();
        RPT.REPORT_CONNECTION RPT = new RPT.REPORT_CONNECTION();

        int year = Properties.Settings.Default.year_cod;

        public FRM_KSHOF_RASD()
        {
            InitializeComponent();
            // Fill Combo
            cmb_grade.DataSource = std.Get_grades();
            cmb_grade.DisplayMember = "GradeDesc";
            cmb_grade.ValueMember = "Grade_Id";

            cmb_month.DataSource = nateg.Get_Test_Month();
            cmb_month.DisplayMember = "testkind_desc";
            cmb_month.ValueMember = "id";

            if (!BL.Globals.Kashof_Rasd)
            {
                lbl_title.Text = "ملفات كشوف الرصد";
                pic_rasd.Image = Properties.Resources.excel_48;
            }
            else
            {
                lbl_title.Text = " كشوف رصد فارغة";
                pic_rasd.Image = Properties.Resources.note_48;
            }

        }

        private void ExportToExcel(BunifuThinButton2 btn,byte status)
        {
            string title;
            string file_name;
            string saveAsLocation;

            short grade = Convert.ToInt16(cmb_grade.SelectedValue);
            
            string staticExcelFile = AppDomain.CurrentDomain.BaseDirectory;
            string grade_desc = cmb_grade.Text;
            string month_desc = cmb_month.Text;
            short test_kind = Convert.ToInt16(cmb_month.SelectedValue);
            if(status == 1)
            {
                title = " كشف رصد تقييمات - الصف " + grade_desc + "  -  " + month_desc;
                file_name = @"\" + "تقييم-" + grade_desc + "-" + month_desc + ".xlsx";

                // Get staticExcelFile Name
                switch (grade)
                {
                    case 10:
                    case 11:
                    case 1:
                    case 2:
                    case 3:
                        staticExcelFile = staticExcelFile + @"Excel\degree-1p.xlsx";
                        break;

                    case 4:
                    case 5:
                    case 6:
                        staticExcelFile = staticExcelFile + @"Excel\degree-2p.xlsx";
                        break;

                    case 7:
                    case 8:
                    case 9:
                        staticExcelFile = staticExcelFile + @"Excel\degree-3p.xlsx";
                        break;
                }
            }
            else
            {
                title = " كشف رصد درجات اختبار - الصف " + grade_desc + "  -  " + month_desc;
                file_name = @"\" + "اختبار-" + grade_desc + "-" + month_desc + ".xlsx";

                // Get staticExcelFile Name
                switch (grade)
                {
                    case 10:
                    case 11:
                        staticExcelFile = staticExcelFile + @"Excel\mark-1p.xlsx";
                        break;

                    case 1:
                    case 2:
                    case 3:
                        staticExcelFile = staticExcelFile + @"Excel\mark-2p.xlsx";
                        break;

                    case 4:
                    case 5:
                    case 6:
                        staticExcelFile = staticExcelFile + @"Excel\mark-3p.xlsx";
                        break;

                    case 7:
                    case 8:
                    case 9:
                        staticExcelFile = staticExcelFile + @"Excel\mark-4p.xlsx";
                        break;
                }
            }
            

            // Folder Path
            string folder = Properties.Settings.Default.save_path;
            bool exists = Directory.Exists(folder);
            if (!exists) Directory.CreateDirectory(folder);
            folderBrowserDialog1.SelectedPath = folder;

            // Show the FolderBrowserDialog.  
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result != DialogResult.OK)
            {
                msg.ErrorMesg("يرجى اختيار مسار الحفظ .. !");
                btn.Focus();
                return;
            }
            else
            {
                saveAsLocation = folderBrowserDialog1.SelectedPath.ToString() + file_name;

                if (File.Exists(saveAsLocation))
                {
                    if (msg.DialogeErrMsg("الصف المحدد تم تصديره سابقاً .. سوف يتم حذف الملف  .. هل تريد المتابعة ؟") == DialogResult.No)
                    {
                        msg.ErrorMesg("تم إلغاء الإجراء ..!");
                        btn.Focus();
                        return;
                    }
                }
            }
            waiting.Wait();
            try
            {
                DataTable Dt_Rasd = nateg.Get_Rasd_Data(grade);
                if (Excel.WriteRasdDataToExcel(Dt_Rasd, grade_desc, saveAsLocation, title, staticExcelFile, test_kind))
                {
                    msg.MyMesg("تم إعداد الملف بنجاح !");
                    msg.MyMesg(saveAsLocation + "  مسار الملف هو  ");
                }
            }
            catch (Exception ex)
            {
                msg.ErrorMesg(ex.Message);
                waiting.End_WAit();
            }
            waiting.End_WAit();
        }

        private void OpenRasdReport(byte test_kind)
        {
            waiting.Wait();
            try
            {
                int grade = Convert.ToInt32(cmb_grade.SelectedValue);

                string month = cmb_month.Text;

                RPT.OpenKoshof_Rasd(grade, month, test_kind);

                waiting.End_WAit();
            }
            catch (Exception e)
            {
                msg.ErrorMesg(e.Message);
            }
            finally
            {
                waiting.End_WAit();
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
            BL.Globals.Kashof_Rasd = false;
            this.Close();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            btn_close_b_Click(sender, e);
        }

        private void btn_degree_Click(object sender, EventArgs e)
        {

            if (BL.Globals.Kashof_Rasd)
            {
                OpenRasdReport(1);
            }
            else
            {
                ExportToExcel(btn_degree,1);
            }
        }

        private void btn_mark_Click(object sender, EventArgs e)
        {
            if (BL.Globals.Kashof_Rasd)
            {
                OpenRasdReport(2);
            }
            else
            {
                ExportToExcel(btn_mark, 2);
            }
        }
    }
}
