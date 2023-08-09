using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Drawing;
using System.Data;

namespace School_Mang.PL.STD
{
    class CLS_STD_FUNCATIONS
    {
        BL.Waiting Waiting = new BL.Waiting();
        BL.MSG msg = new BL.MSG();
        BL.STD.CLS_STD std = new BL.STD.CLS_STD();


        public Boolean Checked_Is_Numeric(TextBox txt_nat)
        {
            Waiting.Wait();
            Regex nonNumericRegex = new Regex(@"\D");
            if (nonNumericRegex.IsMatch(txt_nat.Text))
            {
                txt_nat.BackColor = Color.MistyRose;
                msg.ErrorMesg("تأكد من القيمة المدخلة .. يسمح بالأرقام فقط ..! ");
                Waiting.End_WAit();
                return false;
            }
            else
            {
                Waiting.End_WAit();
                return true;
            }

        }

        //Verify Std Nat
        public int Verify_Std_Nat(TextBox txt_std_code , TextBox txt_nat)
        {
            Waiting.Wait();
            int nat = 0;
            string std_code = "0";
            try
            {
                if (BL.Globals.Update_Std_Data)
                {
                    std_code = txt_std_code.Text;
                }
                DataTable Dt = std.Verify_Std_Nat(txt_nat.Text, std_code);
                if (Dt != null)
                {
                    if (Dt.Rows.Count > 0)
                    {
                        string name = Dt.Rows[0][1].ToString();
                        msg.ErrorMesg(" الرقم القومى للطالب  " + name + "  مسجل من قبل");
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
                msg.ErrorMesg(e.Message);
            }
            finally
            {
                Waiting.End_WAit();
            }
            Waiting.End_WAit();
            return nat;

        }

        public int Verify_Osra_Nat( TextBox txt_nat)
        {
            Waiting.Wait();
            int osra_nat = 0;
            try
            {
                DataTable Dt = std.Verify_Osra_Nat(txt_nat.Text, 0);
                if (Dt != null)
                {
                    if (Dt.Rows.Count > 0)
                    {
                        string name = Dt.Rows[0][1].ToString();
                        msg.ErrorMesg("الرقم القومى مسجل من قبل");
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
                msg.ErrorMesg(e.Message);
            }
            finally
            {
                Waiting.End_WAit();
            }
            Waiting.End_WAit();
            return osra_nat;

        }


    }
}
