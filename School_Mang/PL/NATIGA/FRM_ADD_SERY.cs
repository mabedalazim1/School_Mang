using Bunifu.Framework.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace School_Mang.PL.NATIGA
{
    public partial class FRM_ADD_SERY : Form
    {
        BL.STD.CLS_STD std = new BL.STD.CLS_STD();
        BL.MSG msg = new BL.MSG();
        BL.Waiting waiting = new BL.Waiting();
        BL.NATEG.CLS_NATEG nateg = new BL.NATEG.CLS_NATEG();
        BL.NATEG.ExcelUtlity Excel = new BL.NATEG.ExcelUtlity();
       

        public FRM_ADD_SERY()
        {
            InitializeComponent();
            // Fill Combo
            cmb_grade.DataSource = std.Get_grades();
            cmb_grade.DisplayMember = "GradeDesc";
            cmb_grade.ValueMember = "Grade_Id";
        }


        private void Save_Sery_TO_Excel(BunifuThinButton2 btn)
        {
            string grade_desc = cmb_grade.Text;
            string title = " كشف السري - للصف " + grade_desc;
            string file_name = @"\" + "سري - " + grade_desc + ".xlsx"; ;
            string saveAsLocation;
            string staticExcelFile = AppDomain.CurrentDomain.BaseDirectory + @"Excel\Final\sery-a.xlsx";

            short grade = Convert.ToInt16(cmb_grade.SelectedValue);

            // Folder Path
            string folder = Properties.Settings.Default.save_Sery_path;
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
                DataTable Dt_Rasd = nateg.Get_Rasd_Data(grade,1);
                if (Excel.WriteSeryDataToExcel(Dt_Rasd, grade_desc, saveAsLocation, title, staticExcelFile))
                {
                    msg.MyMesg("تم إعداد الملف بنجاح !");
                    msg.MyMesg(saveAsLocation + "  مسار الملف هو  ");
                }
            }
            catch (Exception ex)
            {
                msg.ErrorMesg(ex.Message);
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

        private void btn_save_Click(object sender, EventArgs e)
        {
            Save_Sery_TO_Excel(btn_save);
        }
    }
}
