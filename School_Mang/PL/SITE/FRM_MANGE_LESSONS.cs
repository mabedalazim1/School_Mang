using School_Mang.PL.STD;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace School_Mang.PL.SITE
{
    public partial class FRM_MANGE_LESSONS : Form
    {
        CLS_STD_FUNCATIONS Func = new CLS_STD_FUNCATIONS();
        // Form Closed
        private static FRM_MANGE_LESSONS Frm_Mange_Lessons;
        static void frm_Form_Closed(object sender, FormClosedEventArgs e)
        {
            Frm_Mange_Lessons = null;
        }

        public static FRM_MANGE_LESSONS Get_Mange_Lessons
        {
            get
            {
                if (Frm_Mange_Lessons == null)
                {
                    Frm_Mange_Lessons = new FRM_MANGE_LESSONS();
                    Frm_Mange_Lessons.FormClosed += new FormClosedEventHandler(frm_Form_Closed);
                }
                return Frm_Mange_Lessons;
            }
        }
        public FRM_MANGE_LESSONS()
        { 
            InitializeComponent();
            if (Frm_Mange_Lessons == null)
            {
                Frm_Mange_Lessons = this;
            }
           
        }
        private void OpenEdidData(string title,byte type)
        {
            FRM_EDIT_DATA.Get_Frm_Edid_Data.type = type;
            FRM_EDIT_DATA.Get_Frm_Edid_Data.lbl_title.Text = title;
            FRM_EDIT_DATA.Get_Frm_Edid_Data.ShowDialog();
        }
        private void lbl_index_Click(object sender, EventArgs e)
        {
            OpenEdidData("الموضوعات", 1);
        }

        private void pic_index_Click(object sender, EventArgs e)
        {
            lbl_index_Click(sender, e);
        }

        private void lbl_lessons_Click(object sender, EventArgs e)
        {
            OpenEdidData("الدروس", 2);
        }

        private void pic_lessons_Click(object sender, EventArgs e)
        {
            lbl_lessons_Click(sender, e);
        }

        private void lbl_sub_part_Click(object sender, EventArgs e)
        {
            OpenEdidData("الفقرات", 3);
        }

        private void pic_sub_part_Click(object sender, EventArgs e)
        {
            lbl_sub_part_Click(sender, e);
        }

        private void lbl_vocab_Click(object sender, EventArgs e)
        {
            OpenEdidData("المفردات", 4);
        }

        private void pic_vocab_Click(object sender, EventArgs e)
        {
            lbl_vocab_Click(sender, e);
        }

        private void lbl_review_Click(object sender, EventArgs e)
        {
            OpenEdidData("المراجعة", 5);
        }

        private void pic_review_Click(object sender, EventArgs e)
        {
            lbl_review_Click(sender, e);
        }

        private void lbl_quiz_Click(object sender, EventArgs e)
        {
            OpenEdidData("الإختبارات", 6);
        }

        private void pic_quiz_Click(object sender, EventArgs e)
        {
            lbl_quiz_Click(sender, e);
        }

        private void lbl_qustioan_Click(object sender, EventArgs e)
        {
            OpenEdidData("الأسئلة", 7);
        }

        private void pic_qustioan_Click(object sender, EventArgs e)
        {
            lbl_qustioan_Click(sender, e);
        }

        private void lbl_answer_Click(object sender, EventArgs e)
        {
            OpenEdidData("الإجابات", 8);
        }

        private void pic_answer_Click(object sender, EventArgs e)
        {
            lbl_answer_Click(sender, e);
        }

        private void lbl_home_Click(object sender, EventArgs e)
        {
            Func.changePages(MAIN.FRM_MANGE_SITE.Get_Frm_Mange_Site.pn_home);
        }

        private void pic_home_Click(object sender, EventArgs e)
        {
            lbl_home_Click(sender, e);
        }
    }
}
