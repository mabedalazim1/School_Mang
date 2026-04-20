using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Drawing;
using System.Data;
using School_Mang.BL;

namespace School_Mang.PL.STD
{
    class CLS_STD_FUNCATIONS
    {
        
        BL.STD.CLS_STD std = new BL.STD.CLS_STD();


        public Boolean Checked_Is_Numeric(TextBox txt_nat)
        {
            Waiting.Start();
            Regex nonNumericRegex = new Regex(@"\D");
            if (nonNumericRegex.IsMatch(txt_nat.Text))
            {
                txt_nat.BackColor = Color.MistyRose;
                MSG.ErrorMesg("تأكد من القيمة المدخلة .. يسمح بالأرقام فقط ..! ");
                Waiting.Stop();
                return false;
            }
            else
            {
                Waiting.Stop();
                return true;
            }

        }

        //Verify Std Nat
        public int Verify_Std_Nat(TextBox txt_std_code ,
                                  TextBox txt_nat, 
                                  bool isUpdateMode = false)
        {
            Waiting.Start();
            int nat = 0;
            string std_code = "0";
            try
            {
                if (isUpdateMode)
                {
                    std_code = txt_std_code.Text;
                }
                DataTable Dt = std.Verify_Std_Nat(txt_nat.Text, std_code);
                if (Dt != null)
                {
                    if (Dt.Rows.Count > 0)
                    {
                        string name = Dt.Rows[0][1].ToString();
                        MSG.ErrorMesg(" الرقم القومى للطالب  " + name + "  مسجل من قبل");
                        txt_nat.BackColor = Color.MistyRose;
                        txt_nat.Focus();
                        nat = 1;
                    }
                    else
                    {
                        nat = 0;
                    }
                }

            }
            catch (Exception e)
            {
                MSG.ErrorMesg(e.Message);
            }
            finally
            {
                Waiting.Stop();
            }
            Waiting.Stop();
            return nat;

        }

        public int Verify_Osra_Nat( TextBox txt_nat)
        {
            Waiting.Start();
            int osra_nat = 0;
            try
            {
                DataTable Dt = std.Verify_Osra_Nat(txt_nat.Text, 0);
                if (Dt != null)
                {
                    if (Dt.Rows.Count > 0)
                    {
                        string name = Dt.Rows[0][1].ToString();
                        MSG.ErrorMesg("الرقم القومى مسجل من قبل");
                        txt_nat.BackColor = Color.MistyRose;
                        txt_nat.Focus();
                        osra_nat = 1;
                    }
                    else
                    {
                        osra_nat = 0;
                    }
                }

            }
            catch (Exception e)
            {
                MSG.ErrorMesg(e.Message);
            }
            finally
            {
                Waiting.Stop();
            }
            Waiting.Stop();
            return osra_nat;

        }

        // Change Pages
        public void changePages(Panel pn)
        {
            MAIN.FRM_MAIN.Get_Frm_Main.pn_home.Visible = false;
            MAIN.FRM_MAIN.Get_Frm_Main.pn_main.Controls.Clear();
            MAIN.FRM_MAIN.Get_Frm_Main.pn_main.Visible = false;
            MAIN.FRM_MAIN.Get_Frm_Main.pn_main.BringToFront();
            MAIN.FRM_MAIN.Get_Frm_Main.lbl_main.Text = "شئون الطلاب";
            MAIN.FRM_MAIN.Get_Frm_Main.lbl_main.Visible = false;
            MAIN.FRM_MAIN.Get_Frm_Main.pn_main.Controls.Add(pn);
            MAIN.FRM_MAIN.Get_Frm_Main.trans_a.ShowSync(MAIN.FRM_MAIN.Get_Frm_Main.pn_main);
            MAIN.FRM_MAIN.Get_Frm_Main.lbl_main.Visible = true;
        }

        public void Get_Update_Name_For_OSRAA_DATA(DataTable Dt)
        {
            if (Dt.Rows[0]["Updated_by"].ToString() != "")
            {
                DateTime my_date = Convert.ToDateTime(Dt.Rows[0]["Updated_At"].ToString());
                FRM_OSRAA_DATA.Get_Osra_data.lbl_edit_date.Visible = true;
                FRM_OSRAA_DATA.Get_Osra_data.lbl_by.Visible = true;
                FRM_OSRAA_DATA.Get_Osra_data.lbl_edit_by.Visible = true;
                FRM_OSRAA_DATA.Get_Osra_data.lbl_date.Visible = true;
                FRM_OSRAA_DATA.Get_Osra_data.lbl_edit_date.Text = my_date.ToString("dd/MM/yyyy");
                FRM_OSRAA_DATA.Get_Osra_data.lbl_edit_by.Text = Dt.Rows[0]["Updated_by"].ToString();
            }
            else
            {
                FRM_OSRAA_DATA.Get_Osra_data.lbl_edit_date.Visible = false;
                FRM_OSRAA_DATA.Get_Osra_data.lbl_edit_by.Visible = false;
                FRM_OSRAA_DATA.Get_Osra_data.lbl_by.Visible = false;
                FRM_OSRAA_DATA.Get_Osra_data.lbl_date.Visible = false;
            }
        }


    }
}
