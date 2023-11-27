using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace School_Mang.PL.STD
{
    public partial class FRM_HESAB_SEN : Form
    {
        // Load Bl HesabSen
        BL.HESAB_SEN BL = new BL.HESAB_SEN();
        int move;
        int move_x;
        int move_y;

        public FRM_HESAB_SEN()
        {
            InitializeComponent();

        }

        BL.MSG msg = new BL.MSG();
        private void btn_close_Click(object sender, EventArgs e)
        {
            btn_close_b_Click(sender, e);
        }

        private void btn_close_b_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void pn_top_MouseDown(object sender, MouseEventArgs e)
        {
            move = 1;
            move_x = e.X;
            move_y = e.Y;
        }

        private void pn_top_MouseUp(object sender, MouseEventArgs e)
        {
            move = 0;
        }

        private void pn_top_MouseMove(object sender, MouseEventArgs e)
        {
            if (move == 1)
            {
                this.SetDesktopLocation(MousePosition.X - move_x, MousePosition.Y - move_y);
            }
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            if (cmb_chose_year.SelectedIndex == -1)
            {
                msg.ErrorMesg("اختر العام الدراسى");
                cmb_chose_year.Focus();
                return;
            }
            // By Tarehk
            if (chk_traehk.Checked)
            {

                if (cmb_day.SelectedIndex == -1)
                {
                    msg.ErrorMesg("اختر اليوم");
                    cmb_day.Focus();
                    return;
                }
                if (cmb_month.SelectedIndex == -1)
                {
                    msg.ErrorMesg("اختر الشهر");
                    cmb_month.Focus();
                    return;
                }
                if (cmb_year.SelectedIndex == -1)
                {
                    msg.ErrorMesg("اختر السنة");
                    cmb_year.Focus();
                    return;
                }

                int dd = Convert.ToInt32(cmb_day.SelectedItem);
                int mm = Convert.ToInt32(cmb_month.SelectedItem);
                int yy = Convert.ToInt32(cmb_year.SelectedItem);
                int sana = Convert.ToInt32(cmb_chose_year.SelectedItem);

                if (BL.HesabSen(dd, mm, yy, sana) != null)
                {

                    lbl_day.Text = BL.HesabSen(dd, mm, yy, sana)[0];
                    lbl_month.Text = BL.HesabSen(dd, mm, yy, sana)[1];
                    lbl_year.Text = BL.HesabSen(dd, mm, yy, sana)[2];
                }
                else
                {
                    lbl_day.Text = "";
                    lbl_month.Text = "";
                    lbl_year.Text = "";
                }
            }
            // By Nat
            else
            {
                if (txt_nat != null)
                {

                    int sana = Convert.ToInt32(cmb_chose_year.SelectedItem);
                    if (txt_nat.TextLength == 14)
                    {
                        if (BL.Nat_HesabSen(txt_nat.Text, sana) != null)
                        {
                            lbl_day.Text = BL.Nat_HesabSen(txt_nat.Text, sana)[0];
                            lbl_month.Text = BL.Nat_HesabSen(txt_nat.Text, sana)[1];
                            lbl_year.Text = BL.Nat_HesabSen(txt_nat.Text, sana)[2];
                        }
                    }
                    else
                    {
                        msg.ErrorMesg();
                        txt_nat.Focus();
                        return;
                    }
                }
                else
                {
                    msg.ErrorMesg("يجب إدخال الرقم القومى");
                    txt_nat.Focus();
                    return;
                }
            }

        }

        private void chk_traehk_OnChange(object sender, EventArgs e)
        {
            if (chk_traehk.Checked)
            {
                chk_nat.Checked = false;
                pn_tarihk.Visible = true;
                txt_nat.Visible = false;
                lbl_nat.Visible = false;

            }
            else
            {
                chk_nat.Checked = true;
                pn_tarihk.Visible = false;
                txt_nat.Visible = true;
                lbl_nat.Visible = true;
                txt_nat.Focus();

            }
        }

        private void chk_nat_OnChange(object sender, EventArgs e)
        {
            if (chk_nat.Checked)
            {
                chk_traehk.Checked = false;
                pn_tarihk.Visible = false;
                txt_nat.Visible = true;
                lbl_nat.Visible = true;
                txt_nat.Focus();

            }
            else
            {
                chk_traehk.Checked = true;
                pn_tarihk.Visible = true;
                txt_nat.Visible = false;
                lbl_nat.Visible = false;
            }
        }

        private void FRM_HESAB_SEN_Load(object sender, EventArgs e)
        {
            cmb_chose_year.SelectedIndex = 0;
            chk_nat.Checked = false;
            txt_nat.Location = new Point(105, 150);
            lbl_nat.Location = new Point(385, 150);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            if (!chk_traehk.Checked)
            {
                chk_traehk.Checked = true;
                chk_nat.Checked = false;
            }
            else
            {
                chk_traehk.Checked = false;
                chk_nat.Checked = true;

            }
            chk_nat_OnChange(sender, e);
        }

        private void label3_Click(object sender, EventArgs e)
        {
            label1_Click(sender, e);
        }

        private void txt_nat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void FRM_HESAB_SEN_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btn_close_b_Click(sender, e);
            }
        }
    }
}
