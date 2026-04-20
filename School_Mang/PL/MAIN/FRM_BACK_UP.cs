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

namespace School_Mang.PL.MAIN
{
    public partial class FRM_BACK_UP : Form
    {
        BL.CLS_BACKUP_DATABASE backup = new BL.CLS_BACKUP_DATABASE();
        CLS_FUNCATIONS func = new CLS_FUNCATIONS();
        public FRM_BACK_UP()
        {
            InitializeComponent();
        }

        private void pic_help_Click(object sender, EventArgs e)
        {
            if (BL.Globals.Restore_DataBase)
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
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
            string server = Properties.Settings.Default.Server_Name;
            string file_name;
            string temp_data = "/data/mssql/backup/temp/KPS_DATA_2023-" +
                            DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss")
                            + ".bak";

            string local_data_name = txt_bath.Text + "\\KPS_DATA_2023-" +
                            DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss")
                             + ".bak";

            if (BL.Globals.Restore_DataBase)
            {
                file_name = txt_bath.Text;
                try
                {
                    if (server.Substring(0, 2) == "19")
                    {
                        string database_path = "/data/mssql/backup/temp/KPS_DATA_2023.bck";

                        // UpLoad Data BAse
                        func.UploadDataBase(file_name, database_path);

                        // Back Up Data Base
                        backup.Restore_DataBase(database_path);
                    }
                    else
                    {
                        // Back Up Data Base
                        backup.Restore_DataBase(file_name);
                    }

                    MSG.MyMesg("تم استعادة النسخة الاحتياطية بنجاح ..!");
                    this.Close();
                    BL.Globals.Restore_DataBase = false;
                }
                catch (Exception ex)
                {
                    MSG.ErrorMesg(ex.Message);
                }
            }
            else
            {
                try
                {
                    if (server.Substring(0, 2) == "19")
                    {
                        file_name = "/data/mssql/backup/KPS_DATA_2023.bak";
                        // Backup DataBase
                        backup.BackUP_DataBase(file_name);

                        // Add Temp DataBase
                        backup.BackUP_DataBase(temp_data);


                        // Get Temp Data Name
                        string temp_data_name = backup.temp_data_name;

                        // Dawnload DataBase
                        func.DowanloadDataBase(local_data_name, temp_data_name);
                    }
                    else
                    {
                        // If Data On Local server
                        
                        file_name = txt_bath.Text + @"\KPS_DATA_2023-" +
                            DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss")
                             + ".bak";
                        backup.BackUP_DataBase(file_name);
                    }

                    MSG.MyMesg("تم إنشاء النسخة الاحتياطية بنجاح ..!");

                }
                catch (Exception ex)
                {
                    MSG.ErrorMesg(ex.Message);
                    return;
                }

                this.Close();
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

        private void lbl_select_Click(object sender, EventArgs e)
        {
            pic_help_Click(sender, e);
        }

        private void txt_bath_DoubleClick(object sender, EventArgs e)
        {
            pic_help_Click(sender, e);
        }
    }
}
