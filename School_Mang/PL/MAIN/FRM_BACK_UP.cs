using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace School_Mang.PL.MAIN
{
    public partial class FRM_BACK_UP : Form
    {
        BL.MSG msg = new BL.MSG();
        public FRM_BACK_UP()
        {
            InitializeComponent();
        }

        private void pic_help_Click(object sender, EventArgs e)
        {
            if (BL.Globals.Restore_DataBase)
            {
                if(openFileDialog1.ShowDialog()== DialogResult.OK)
                {
                    txt_bath.Text = openFileDialog1.FileName;
                }
            }
            else
            {
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    txt_bath.Text = folderBrowserDialog1.SelectedPath;
                }
            }
            
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
            BL.Globals.Restore_DataBase = false;
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            btn_cancel_Click(sender, e);
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            DAL.DataAcceseLayer DAL = new DAL.DataAcceseLayer();

            if (BL.Globals.Restore_DataBase)
            {
                try
                {
                    DAL.Restore_DataBase(txt_bath.Text);
                    msg.MyMesg("تم استعادة النسخة الاحتياطية بنجاح ..!");
                    this.Close();
                    BL.Globals.Restore_DataBase = false;
                }
                catch (Exception ex)
                {
                    msg.ErrorMesg(ex.Message);
                }
            }
            else
            {
                try
                {
                    DAL.BackUP_DataBase(txt_bath.Text);

                    msg.MyMesg("تم إنشاء النسخة الاحتياطية بنجاح ..!");
                    this.Close();

                }
                catch (Exception ex)
                {
                    msg.ErrorMesg(ex.Message);
                }
            }
            
        }

        private void FRM_BACK_UP_Load(object sender, EventArgs e)
        {
            if (BL.Globals.Restore_DataBase)
            {
                lbl_title.Text = "استعادة نسخة احتياطية";
                lbl_select.Text = "اختر الملف"; 
               
            }
            else
            { 
                lbl_select.Text = "مسار الحفظ";
                lbl_title.Text = "إنشاء نسخة احتياطية";
                folderBrowserDialog1.SelectedPath = @"E:\School_Mang\BackUp";
                txt_bath.Text = folderBrowserDialog1.SelectedPath;
            }
            

        }
    }
}
