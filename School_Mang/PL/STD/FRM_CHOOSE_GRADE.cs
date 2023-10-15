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
    public partial class FRM_CHOOSE_GRADE : Form
    {
        BL.STD.CLS_STD std = new BL.STD.CLS_STD();
        MAIN.CLS_FUNCATIONS Func = new MAIN.CLS_FUNCATIONS();

        DataTable dt_count = new DataTable();
        int year_code = Properties.Settings.Default.year_cod;
        int year;
        // Form Closed
       
        public FRM_CHOOSE_GRADE()
        {
            InitializeComponent();

            if (BL.Globals.Current_Year_Data)
            {
                year = year_code;
            }
            else
            {
                year = year_code + 1;
            }

            dt_count = std.Get_School_year_Data(year, 0, 0);

        }

        int move;
        int move_x;
        int move_y;

        private void Add_Data()
        {
            dt_std_data.ColumnCount = 7;
            dt_std_data.Columns[0].Name = "الصف";
            dt_std_data.Columns[1].Name = "مقيد";
            dt_std_data.Columns[2].Name = "ذكر";
            dt_std_data.Columns[3].Name = "أنثى";
            dt_std_data.Columns[4].Name = "مسلم";
            dt_std_data.Columns[5].Name = "مسيحى";
            dt_std_data.Columns[6].Name = "grade";

            string[] row = new string[]
            {
                "KG 1",
                Func.ToArabic(dt_count.Select("Grade_Id = 10").Length),
                Func.ToArabic(dt_count.Select("Grade_Id = 10  and Gender_Id =1").Length),
                Func.ToArabic(dt_count.Select("Grade_Id = 10  and Gender_Id =2").Length),
                Func.ToArabic(dt_count.Select("Grade_Id = 10 and Religion_Id =1").Length),
                Func.ToArabic(dt_count.Select("Grade_Id = 10 and Religion_Id =2").Length),
                "10"
        };
            dt_std_data.Rows.Add(row);

            row = new string[]
            {
                "KG 2",
                Func.ToArabic(dt_count.Select("Grade_Id = 11").Length),
                Func.ToArabic(dt_count.Select("Grade_Id = 11  and Gender_Id =1").Length),
                Func.ToArabic(dt_count.Select("Grade_Id = 11  and Gender_Id =2").Length),
                Func.ToArabic(dt_count.Select("Grade_Id = 11 and Religion_Id =1").Length),
                Func.ToArabic(dt_count.Select("Grade_Id = 11 and Religion_Id =2").Length),
                "11"
        };
            dt_std_data.Rows.Add(row);

            row = new string[]
            {
                "جملة رياض أطفال",
                Func.ToArabic(dt_count.Select("Grade_Id >9").Length),
                Func.ToArabic(dt_count.Select("Grade_Id >9  and Gender_Id =1").Length),
                Func.ToArabic(dt_count.Select("Grade_Id >9  and Gender_Id =2").Length),
                Func.ToArabic(dt_count.Select("Grade_Id >9 and Religion_Id =1").Length),
                Func.ToArabic(dt_count.Select("Grade_Id >9 and Religion_Id =2").Length),
                "10"
        };
            dt_std_data.Rows.Add(row);

            row = new string[]
            {
                "الأول ب",
                Func.ToArabic(dt_count.Select("Grade_Id =1").Length),
                Func.ToArabic(dt_count.Select("Grade_Id =1  and Gender_Id =1").Length),
                Func.ToArabic(dt_count.Select("Grade_Id =1  and Gender_Id =2").Length),
                Func.ToArabic(dt_count.Select("Grade_Id =1 and Religion_Id =1").Length),
                Func.ToArabic(dt_count.Select("Grade_Id =1 and Religion_Id =2").Length),
                "1"
        };
            dt_std_data.Rows.Add(row);

            row = new string[]
            {
                "الثانى ب",
                Func.ToArabic(dt_count.Select("Grade_Id =2").Length),
                Func.ToArabic(dt_count.Select("Grade_Id =2  and Gender_Id =1").Length),
                Func.ToArabic(dt_count.Select("Grade_Id =2  and Gender_Id =2").Length),
                Func.ToArabic(dt_count.Select("Grade_Id =2 and Religion_Id =1").Length),
                Func.ToArabic(dt_count.Select("Grade_Id =2 and Religion_Id =2").Length),
                "2"
        };
            dt_std_data.Rows.Add(row);

            row = new string[]
           {
                "الثالث ب",
                Func.ToArabic(dt_count.Select("Grade_Id =3").Length),
                Func.ToArabic(dt_count.Select("Grade_Id =3  and Gender_Id =1").Length),
                Func.ToArabic(dt_count.Select("Grade_Id =3  and Gender_Id =2").Length),
                Func.ToArabic(dt_count.Select("Grade_Id =3 and Religion_Id =1").Length),
                Func.ToArabic(dt_count.Select("Grade_Id =3 and Religion_Id =2").Length),
                "3"
       };
            dt_std_data.Rows.Add(row);


            row = new string[]
         {
                "الرابع ب",
                Func.ToArabic(dt_count.Select("Grade_Id =4").Length),
                Func.ToArabic(dt_count.Select("Grade_Id =4  and Gender_Id =1").Length),
                Func.ToArabic(dt_count.Select("Grade_Id =4  and Gender_Id =2").Length),
                Func.ToArabic(dt_count.Select("Grade_Id =4 and Religion_Id =1").Length),
                Func.ToArabic(dt_count.Select("Grade_Id =4 and Religion_Id =2").Length),
                "4"
     };
            dt_std_data.Rows.Add(row);

            row = new string[]
           {
                "الخامس ب",
                Func.ToArabic(dt_count.Select("Grade_Id =5").Length),
                Func.ToArabic(dt_count.Select("Grade_Id =5  and Gender_Id =1").Length),
                Func.ToArabic(dt_count.Select("Grade_Id =5  and Gender_Id =2").Length),
                Func.ToArabic(dt_count.Select("Grade_Id =5 and Religion_Id =1").Length),
                Func.ToArabic(dt_count.Select("Grade_Id =5 and Religion_Id =2").Length),
                "5"
       };
            dt_std_data.Rows.Add(row);

            row = new string[]
          {
                "السادس ب",
                Func.ToArabic(dt_count.Select("Grade_Id =6").Length),
                Func.ToArabic(dt_count.Select("Grade_Id =6  and Gender_Id =1").Length),
                Func.ToArabic(dt_count.Select("Grade_Id =6  and Gender_Id =2").Length),
                Func.ToArabic(dt_count.Select("Grade_Id =6 and Religion_Id =1").Length),
                Func.ToArabic(dt_count.Select("Grade_Id =6 and Religion_Id =2").Length),
                "6"
      };
            dt_std_data.Rows.Add(row);

            row = new string[]
            {
                "جملة المرحلة الإبتدائية",
                Func.ToArabic(dt_count.Select("Grade_Id < 7").Length),
                Func.ToArabic(dt_count.Select("Grade_Id < 7  and Gender_Id =1").Length),
                Func.ToArabic(dt_count.Select("Grade_Id < 7  and Gender_Id =2").Length),
                Func.ToArabic(dt_count.Select("Grade_Id < 7 and Religion_Id =1").Length),
                Func.ToArabic(dt_count.Select("Grade_Id < 7 and Religion_Id =2").Length),
                "1"
        };
            dt_std_data.Rows.Add(row);


            row = new string[]
         {
                "الأول ع",
                Func.ToArabic(dt_count.Select("Grade_Id =7").Length),
                Func.ToArabic(dt_count.Select("Grade_Id =7  and Gender_Id =1").Length),
                Func.ToArabic(dt_count.Select("Grade_Id =7  and Gender_Id =2").Length),
                Func.ToArabic(dt_count.Select("Grade_Id =7 and Religion_Id =1").Length),
                Func.ToArabic(dt_count.Select("Grade_Id =7 and Religion_Id =2").Length),
                "7"
     };
            dt_std_data.Rows.Add(row);

            row = new string[]
           {
                "الثانى ع",
                Func.ToArabic(dt_count.Select("Grade_Id =8").Length),
                Func.ToArabic(dt_count.Select("Grade_Id =8  and Gender_Id =1").Length),
                Func.ToArabic(dt_count.Select("Grade_Id =8  and Gender_Id =2").Length),
                Func.ToArabic(dt_count.Select("Grade_Id =8 and Religion_Id =1").Length),
                Func.ToArabic(dt_count.Select("Grade_Id =8 and Religion_Id =2").Length),
                "8"
       };
            dt_std_data.Rows.Add(row);

            row = new string[]
          {
                "الثالث ع",
                Func.ToArabic(dt_count.Select("Grade_Id =9").Length),
                Func.ToArabic(dt_count.Select("Grade_Id =9  and Gender_Id =1").Length),
                Func.ToArabic(dt_count.Select("Grade_Id =9  and Gender_Id =2").Length),
                Func.ToArabic(dt_count.Select("Grade_Id =9 and Religion_Id =1").Length),
                Func.ToArabic(dt_count.Select("Grade_Id =9 and Religion_Id =2").Length),
                "9"
      };
            dt_std_data.Rows.Add(row);

            row = new string[]
            {
                "جملة المرحلة الإعدادية",
                Func.ToArabic(dt_count.Select("Grade_Id > 6 and  Grade_Id < 10").Length),
                Func.ToArabic(dt_count.Select("Grade_Id > 6 and Grade_Id < 10  and Gender_Id =1").Length),
                Func.ToArabic(dt_count.Select("Grade_Id > 6 and Grade_Id < 10  and Gender_Id =2").Length),
                Func.ToArabic(dt_count.Select("Grade_Id > 6 and Grade_Id < 10 and Religion_Id =1").Length),
                Func.ToArabic(dt_count.Select("Grade_Id > 6 and Grade_Id < 10 and Religion_Id =2").Length),
                "7"
        };
            dt_std_data.Rows.Add(row);

            row = new string[]
            {
                "الجملة العامة",
                Func.ToArabic(dt_count.Select("Grade_Id >0").Length),
                Func.ToArabic(dt_count.Select("Gender_Id =1").Length),
                Func.ToArabic(dt_count.Select("Gender_Id =2").Length),
                Func.ToArabic(dt_count.Select("Religion_Id =1").Length),
                Func.ToArabic(dt_count.Select("Religion_Id =2").Length),
                "0"
        };
            dt_std_data.Rows.Add(row);

            foreach(DataGridViewRow dtrow in dt_std_data.Rows)
            {
                if (dtrow.Cells[0].Value.ToString() == "جملة رياض أطفال" ||
                    dtrow.Cells[0].Value.ToString() == "جملة المرحلة الإبتدائية" ||
                    dtrow.Cells[0].Value.ToString() == "جملة المرحلة الإعدادية") 
                {
                    dtrow.DefaultCellStyle.BackColor = Color.LightGray;
                }
                if (dtrow.Cells[0].Value.ToString() == "الجملة العامة") 
                {
                    dtrow.DefaultCellStyle.BackColor = Color.Teal;
                }

                dt_std_data.Columns[0].Width = 200;
                dt_std_data.Columns[6].Visible = false;
            }

        }
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

        private void btn_close_Click(object sender, EventArgs e)
        {
            btn_close_b_Click(sender, e);
        }

        private void FRM_CHOOSE_GRADE_Load(object sender, EventArgs e)
        {

            Add_Data();
            lbl_current_year.Text ="احصاء " + Func.Year_Desc();
        }

        private void btn_close_b_Click(object sender, EventArgs e)
        {
            this.Close();
            BL.Globals.Current_Year_Data = false;
        }

        private void btn_show_data_Click(object sender, EventArgs e)
        { 
            short grade = 0;
            if (dt_std_data.SelectedRows.Count != 0)
            {
                grade =Convert.ToInt16(dt_std_data.CurrentRow.Cells[6].Value);
            }
            this.Dispose();

            FRM_CURRENT_STD.Get_Current_Std.grade = grade;
            FRM_CURRENT_STD.Get_Current_Std.ShowDialog(MAIN.FRM_MAIN.Get_Frm_Main);
           
                  
        }

        private void dt_std_data_DoubleClick(object sender, EventArgs e)
        {
            btn_show_data_Click(sender, e);
        }

        private void FRM_CHOOSE_GRADE_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btn_close_b_Click(sender, e);
            }
        }
    }
}
