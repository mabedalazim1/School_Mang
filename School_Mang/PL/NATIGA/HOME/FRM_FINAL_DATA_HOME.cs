using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using School_Mang.PL.MAIN;

namespace School_Mang.PL.NATIGA.HOME
{
    public partial class FRM_FINAL_DATA_HOME : Form
    {
        BL.NATEG.cls_NATAG_FUNCTIONS natag_func = new BL.NATEG.cls_NATAG_FUNCTIONS();
        BL.MSG msg = new BL.MSG();
        BL.NATEG.CLS_NATEG NATEG = new BL.NATEG.CLS_NATEG();
        BL.Waiting Waiting = new BL.Waiting();
        BL.NATEG.ExcelUtlity Excel = new BL.NATEG.ExcelUtlity();

        // Form Closed
        private static FRM_FINAL_DATA_HOME frm_Final_Data_home;
        static void frm_Form_Closed(object sender, FormClosedEventArgs e)
        {
            frm_Final_Data_home = null;
        }
        public static FRM_FINAL_DATA_HOME Get_Frm_Final_Data_Home
        {
            get
            {
                if (frm_Final_Data_home == null)
                {
                    frm_Final_Data_home = new FRM_FINAL_DATA_HOME();
                    frm_Final_Data_home.FormClosed += new FormClosedEventHandler(frm_Form_Closed);
                }
                return frm_Final_Data_home;
            }
        }


        public FRM_FINAL_DATA_HOME()
        {
            InitializeComponent();

            if (frm_Final_Data_home == null)
            {
                frm_Final_Data_home = this;
            }

        }

        private void Check_Data()
        {
            string file_name = natag_func.OpenDialoge(openFileDialog1);
            if (file_name == null)
            {
                msg.ErrorMesg("تم إلغاء الإجراء..!");
                return;
            }
            try
            {
                int Golos;
                decimal arabic;
                decimal din;
                decimal math;
                decimal scince;
                decimal scince_practical;
                decimal social;
                decimal english;
                decimal maharat;
                decimal tocnolegy;
                decimal tocnolegy_practical;
                decimal nashat_1;
                decimal nashat_2;

                Waiting.Wait();
                DataTable dt_information = Excel.GetInformationData(file_name);
                DataRow row = dt_information.Rows[0];

                // Test If File Have Valid Value
                string file_kind = row[0].ToString();
                if (file_kind == "" || file_kind == null)
                {
                    msg.ErrorMesg("الملف غير صالح .. يرجى التأكد من الملف المطلوب ..!");
                    return;
                }
                else
                {
                    string file_info = " سوف يتم تحميل  " +
                                    row[0].ToString() + " " +
                                    row[1].ToString() + " - الصف " +
                                    row[2].ToString() + " - " +
                                    row[3].ToString();

                    if (msg.DialogeMsg(file_info + "\n" + "هل تريد المتابعة .. ؟") == DialogResult.Yes)
                    {
                        byte test_kind = Convert.ToByte(row[4]);
                        byte test_grade = Convert.ToByte(row[5]);
                        byte term_id = Convert.ToByte(row[6]);
                        string file_data = row[7].ToString();

                        DataTable dt_degree = new DataTable();

                        if (file_data == "0" || file_data == null || file_data == "")
                        {
                            msg.ErrorMesg("يرجى التأكد من الدرجات ..!");
                            msg.ErrorMesg("تم إلغاء الإجراء ..!");
                            return;
                        }

                        switch (term_id)
                        {
                            case 1: // Term A
                                switch (test_kind)
                                {
                                    case 1: // Amal Term A
                                        switch (test_grade)
                                        {
                                            // 4-5-6 Amal term A
                                            case 4:
                                            case 5:
                                            case 6:

                                                dt_degree = Excel.Read_Amal_4_5_6(file_name);
                                                foreach (DataRow amal in dt_degree.Rows)
                                                {
                                                    Golos = Convert.ToInt32(amal[0]);
                                                    arabic = Convert.ToDecimal(amal[1]);
                                                    din = Convert.ToDecimal(amal[2]);
                                                    math = Convert.ToDecimal(amal[3]);
                                                    scince = Convert.ToDecimal(amal[4]);
                                                    social = Convert.ToDecimal(amal[5]);
                                                    english = Convert.ToDecimal(amal[6]);
                                                    maharat = Convert.ToDecimal(amal[7]);
                                                    tocnolegy = Convert.ToDecimal(amal[8]);

                                                    NATEG.Add_Amal_A_4_5_6(Golos,
                                                                            arabic,
                                                                            din,
                                                                            math,
                                                                            scince,
                                                                            social,
                                                                            english,
                                                                            maharat,
                                                                            tocnolegy);
                                                }
                                                Waiting.End_WAit();
                                                msg.MyMesg("تم تحديث الدرجات بنجاح .. !");
                                                break;
                                            // 7-8-9 Amal term A
                                            case 7:
                                            case 8:
                                            case 9:

                                                dt_degree = Excel.Read_Amal_7_8_9(file_name);
                                                foreach (DataRow amal in dt_degree.Rows)
                                                {
                                                    Golos = Convert.ToInt32(amal[0]);
                                                    arabic = Convert.ToDecimal(amal[1]);
                                                    din = Convert.ToDecimal(amal[2]);
                                                    math = Convert.ToDecimal(amal[3]);
                                                    scince = Convert.ToDecimal(amal[4]);
                                                    scince_practical = Convert.ToDecimal(amal[5]);
                                                    social = Convert.ToDecimal(amal[6]);
                                                    english = Convert.ToDecimal(amal[7]);
                                                    maharat = Convert.ToDecimal(amal[8]);
                                                    tocnolegy = Convert.ToDecimal(amal[9]);
                                                    tocnolegy_practical = Convert.ToDecimal(amal[10]);
                                                    nashat_1 = Convert.ToDecimal(amal[11]);
                                                    nashat_2 = Convert.ToDecimal(amal[12]);

                                                    NATEG.Add_Amal_A_7_8_9(Golos,
                                                                            arabic,
                                                                            din,
                                                                            math,
                                                                            scince,
                                                                            scince_practical,
                                                                            social,
                                                                            english,
                                                                            maharat,
                                                                            tocnolegy,
                                                                            tocnolegy_practical,
                                                                            nashat_1,
                                                                            nashat_2);
                                                }
                                                Waiting.End_WAit();
                                                msg.MyMesg("تم تحديث الدرجات بنجاح .. !");
                                                break;
                                        }
                                        break;
                                    case 2: // Test Term A

                                        switch (test_grade)
                                        {
                                            case 4:
                                            case 5:
                                            case 6:
                                                dt_degree = Excel.Read_Test(file_name);
                                                break;

                                            case 7:
                                            case 8:
                                            case 9:
                                                dt_degree = Excel.Read_Test(file_name,2);
                                                break;
                                        }
                                       
                                        foreach (DataRow test in dt_degree.Rows)
                                        {
                                            Golos = Convert.ToInt32(test[0]);
                                            arabic = Convert.ToDecimal(test[1]);
                                            din = Convert.ToDecimal(test[2]);
                                            math = Convert.ToDecimal(test[3]);
                                            scince = Convert.ToDecimal(test[4]);
                                            social = Convert.ToDecimal(test[5]);
                                            english = Convert.ToDecimal(test[6]);
                                            maharat = Convert.ToDecimal(test[7]);
                                            tocnolegy = Convert.ToDecimal(test[8]);

                                            NATEG.Add_Test_A(Golos,
                                                                    arabic,
                                                                    din,
                                                                    math,
                                                                    scince,
                                                                    social,
                                                                    english,
                                                                    maharat,
                                                                    tocnolegy);
                                        }

                                        Waiting.End_WAit();
                                        msg.MyMesg("تم تحديث الدرجات بنجاح .. !");
                                        break;
                                }
                                break;

                            case 2: // Term B
                                switch (test_kind)
                                {
                                    case 1: // Amal Term B

                                        switch (test_grade)
                                        {
                                            // 4-5-6 Amal term B
                                            case 4:
                                            case 5:
                                            case 6:

                                                dt_degree = Excel.Read_Amal_4_5_6(file_name);
                                                foreach (DataRow amal in dt_degree.Rows)
                                                {
                                                    Golos = Convert.ToInt32(amal[0]);
                                                    arabic = Convert.ToDecimal(amal[1]);
                                                    din = Convert.ToDecimal(amal[2]);
                                                    math = Convert.ToDecimal(amal[3]);
                                                    scince = Convert.ToDecimal(amal[4]);
                                                    social = Convert.ToDecimal(amal[5]);
                                                    english = Convert.ToDecimal(amal[6]);
                                                    maharat = Convert.ToDecimal(amal[7]);
                                                    tocnolegy = Convert.ToDecimal(amal[8]);

                                                    NATEG.Add_Amal_B_4_5_6(Golos,
                                                                            arabic,
                                                                            din,
                                                                            math,
                                                                            scince,
                                                                            social,
                                                                            english,
                                                                            maharat,
                                                                            tocnolegy);
                                                }
                                                Waiting.End_WAit();
                                                msg.MyMesg("تم تحديث الدرجات بنجاح .. !");
                                                break;
                                            // 7-8-9 Amal term B
                                            case 7:
                                            case 8:
                                            case 9:

                                                dt_degree = Excel.Read_Amal_7_8_9(file_name);
                                                foreach (DataRow amal in dt_degree.Rows)
                                                {
                                                    Golos = Convert.ToInt32(amal[0]);
                                                    arabic = Convert.ToDecimal(amal[1]);
                                                    din = Convert.ToDecimal(amal[2]);
                                                    math = Convert.ToDecimal(amal[3]);
                                                    scince = Convert.ToDecimal(amal[4]);
                                                    scince_practical = Convert.ToDecimal(amal[5]);
                                                    social = Convert.ToDecimal(amal[6]);
                                                    english = Convert.ToDecimal(amal[7]);
                                                    maharat = Convert.ToDecimal(amal[8]);
                                                    tocnolegy = Convert.ToDecimal(amal[9]);
                                                    tocnolegy_practical = Convert.ToDecimal(amal[10]);
                                                    nashat_1 = Convert.ToDecimal(amal[11]);
                                                    nashat_2 = Convert.ToDecimal(amal[12]);

                                                    NATEG.Add_Amal_B_7_8_9(Golos,
                                                                            arabic,
                                                                            din,
                                                                            math,
                                                                            scince,
                                                                            scince_practical,
                                                                            social,
                                                                            english,
                                                                            maharat,
                                                                            tocnolegy,
                                                                            tocnolegy_practical,
                                                                            nashat_1,
                                                                            nashat_2);
                                                }
                                                Waiting.End_WAit();
                                                msg.MyMesg("تم تحديث الدرجات بنجاح .. !");
                                                break;
                                        }
                                        break;
                                    case 2: // Test term b
                                        switch (test_grade)
                                        {
                                            case 4:
                                            case 5:
                                            case 6:
                                                dt_degree = Excel.Read_Test(file_name);
                                                break;

                                            case 7:
                                            case 8:
                                            case 9:
                                                dt_degree = Excel.Read_Test(file_name, 2);
                                                break;
                                        }
                                        foreach (DataRow test in dt_degree.Rows)
                                        {
                                            Golos = Convert.ToInt32(test[0]);
                                            arabic = Convert.ToDecimal(test[1]);
                                            din = Convert.ToDecimal(test[2]);
                                            math = Convert.ToDecimal(test[3]);
                                            scince = Convert.ToDecimal(test[4]);
                                            social = Convert.ToDecimal(test[5]);
                                            english = Convert.ToDecimal(test[6]);
                                            maharat = Convert.ToDecimal(test[7]);
                                            tocnolegy = Convert.ToDecimal(test[8]);

                                            NATEG.Add_Test_B(Golos,
                                                                    arabic,
                                                                    din,
                                                                    math,
                                                                    scince,
                                                                    social,
                                                                    english,
                                                                    maharat,
                                                                    tocnolegy);
                                        }

                                        Waiting.End_WAit();
                                        msg.MyMesg("تم تحديث الدرجات بنجاح .. !");
                                        break;
                                }
                                break;
                        }
                    }
                    else
                    {
                        msg.ErrorMesg("تم إلغاء الإجراء ..!");
                        return;
                    }
                }

                Waiting.End_WAit();
            }
            catch (Exception e)
            {
                msg.ErrorMesg(e.Message);
            }
            finally
            {
                Waiting.End_WAit();
            }
        }

        private void lbl_back_Click(object sender, EventArgs e)
        {
            natag_func.changePages(FRM_NATEG.Get_Frm_Nateg.pn_home, "التقييمات");
        }

        private void lbl_get_dgree_a_Click(object sender, EventArgs e)
        {
            try
            {
                BL.Globals.Amal_Sana = true;
                BL.Globals.Final_Test = false;
                FRM_CHOSE_FINAL_DATA frm = new FRM_CHOSE_FINAL_DATA();
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                msg.ErrorMesg(ex.Message);
            }
        }

        private void pic_get_dgree_a_Click(object sender, EventArgs e)
        {
            lbl_get_dgree_a_Click(sender, e);
        }

        private void lbl_get_dgree_b_Click(object sender, EventArgs e)
        {
            try
            {
                BL.Globals.Final_Test = true;
                BL.Globals.Amal_Sana = false;
                FRM_CHOSE_FINAL_DATA frm = new FRM_CHOSE_FINAL_DATA();
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                msg.ErrorMesg(ex.Message);
            }
        }

        private void pic_get_dgree_b_Click(object sender, EventArgs e)
        {
            lbl_get_dgree_b_Click(sender, e);
        }

        private void lbl_upload_file_Click(object sender, EventArgs e)
        {
            try
            {
                Check_Data();
            }
            catch (Exception ex)
            {
                msg.ErrorMesg(ex.Message);
            }
            finally
            {
                Waiting.End_WAit();
            }
        }

        private void pic_upload_file_Click(object sender, EventArgs e)
        {
            lbl_upload_file_Click(sender, e);
        }

        private void lbl_final_Click(object sender, EventArgs e)
        {
            BL.Globals.Amal_Sana = true;
            FRM_CHOSE_FINAL_RASD.Get_Frm_Chose_Final_Rasd.ShowDialog();
           
        }

        private void pic_final_Click(object sender, EventArgs e)
        {
            lbl_final_Click(sender, e);
        }


        private void lbl_final_test_Click(object sender, EventArgs e)
        {
            BL.Globals.Final_Test = true;
            FRM_CHOSE_FINAL_RASD.Get_Frm_Chose_Final_Rasd.ShowDialog();
        }

        private void pic_final_test_Click(object sender, EventArgs e)
        {
            lbl_final_test_Click(sender, e);
        }

        private void lbl_data_Click(object sender, EventArgs e)
        {
            FRM_FINAL_COUNT_DATA.Get_Frm_Final_Count_Data.ShowDialog();
        }

        private void pic_data_Click(object sender, EventArgs e)
        {
            lbl_data_Click(sender, e);
        }

        private void pic_back_Click(object sender, EventArgs e)
        {
            lbl_back_Click(sender, e);
        }

        private void pic_natega_a_Click(object sender, EventArgs e)
        {
            lbl_natega_a_Click(sender,e);
        }

        private void lbl_natega_a_Click(object sender, EventArgs e)
        {
            BL.Globals.Amal_Sana = false;
            BL.Globals.Final_Test = false;
            BL.Globals.Final_Nataga = true;
            FRM_CHOSE_FINAL_RASD.Get_Frm_Chose_Final_Rasd.ShowDialog();
        }
    }
}
