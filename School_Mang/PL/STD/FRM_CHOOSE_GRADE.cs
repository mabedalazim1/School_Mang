using School_Mang.BL;
using School_Mang.BL.Common;
using School_Mang.BL.Enums;
using School_Mang.BL.Services;
using School_Mang.BL.Extensions;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using School_Mang.BL.Services.STD;


namespace School_Mang.PL.STD
{
    public partial class FRM_CHOOSE_GRADE : Form, INavigationAware
    {
        private readonly StudentDataService _dataService = new StudentDataService();
        private NavigationContext _context;

        public void SetNavigation(NavigationContext context)
        {
            _context = context;

        }

        DataTable dt_count = new DataTable();
        int year_code = Properties.Settings.Default.year_cod;
        int year;



        // Form Closed

        public FRM_CHOOSE_GRADE()
        {
            InitializeComponent();

        }

        int move;
        int move_x;
        int move_y;


        short grade = 0;
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
                SchoolFormatter.ToArabic(dt_count.Select("Grade_Id = 10").Length),
                SchoolFormatter.ToArabic(dt_count.Select("Grade_Id = 10  and Gender_Id =1").Length),
                SchoolFormatter.ToArabic(dt_count.Select("Grade_Id = 10  and Gender_Id =2").Length),
                SchoolFormatter.ToArabic(dt_count.Select("Grade_Id = 10 and Religion_Id =1").Length),
                SchoolFormatter.ToArabic(dt_count.Select("Grade_Id = 10 and Religion_Id =2").Length),
                "10"
        };
            dt_std_data.Rows.Add(row);

            row = new string[]
            {
                "KG 2",
                SchoolFormatter.ToArabic(dt_count.Select("Grade_Id = 11").Length),
                SchoolFormatter.ToArabic(dt_count.Select("Grade_Id = 11  and Gender_Id =1").Length),
                SchoolFormatter.ToArabic(dt_count.Select("Grade_Id = 11  and Gender_Id =2").Length),
                SchoolFormatter.ToArabic(dt_count.Select("Grade_Id = 11 and Religion_Id =1").Length),
                SchoolFormatter.ToArabic(dt_count.Select("Grade_Id = 11 and Religion_Id =2").Length),
                "11"
        };
            dt_std_data.Rows.Add(row);

            row = new string[]
            {
                "جملة رياض أطفال",
                SchoolFormatter.ToArabic(dt_count.Select("Grade_Id >9").Length),
                SchoolFormatter.ToArabic(dt_count.Select("Grade_Id >9  and Gender_Id =1").Length),
                SchoolFormatter.ToArabic(dt_count.Select("Grade_Id >9  and Gender_Id =2").Length),
                SchoolFormatter.ToArabic(dt_count.Select("Grade_Id >9 and Religion_Id =1").Length),
                SchoolFormatter.ToArabic(dt_count.Select("Grade_Id >9 and Religion_Id =2").Length),
                "10"
        };
            dt_std_data.Rows.Add(row);

            row = new string[]
            {
                "الأول ب",
                SchoolFormatter.ToArabic(dt_count.Select("Grade_Id =1").Length),
                SchoolFormatter.ToArabic(dt_count.Select("Grade_Id =1  and Gender_Id =1").Length),
                SchoolFormatter.ToArabic(dt_count.Select("Grade_Id =1  and Gender_Id =2").Length),
                SchoolFormatter.ToArabic(dt_count.Select("Grade_Id =1 and Religion_Id =1").Length),
                SchoolFormatter.ToArabic(dt_count.Select("Grade_Id =1 and Religion_Id =2").Length),
                "1"
        };
            dt_std_data.Rows.Add(row);

            row = new string[]
            {
                "الثانى ب",
                SchoolFormatter.ToArabic(dt_count.Select("Grade_Id =2").Length),
                SchoolFormatter.ToArabic(dt_count.Select("Grade_Id =2  and Gender_Id =1").Length),
                SchoolFormatter.ToArabic(dt_count.Select("Grade_Id =2  and Gender_Id =2").Length),
                SchoolFormatter.ToArabic(dt_count.Select("Grade_Id =2 and Religion_Id =1").Length),
                SchoolFormatter.ToArabic(dt_count.Select("Grade_Id =2 and Religion_Id =2").Length),
                "2"
        };
            dt_std_data.Rows.Add(row);

            row = new string[]
           {
                "الثالث ب",
                SchoolFormatter.ToArabic(dt_count.Select("Grade_Id =3").Length),
                SchoolFormatter.ToArabic(dt_count.Select("Grade_Id =3  and Gender_Id =1").Length),
                SchoolFormatter.ToArabic(dt_count.Select("Grade_Id =3  and Gender_Id =2").Length),
                SchoolFormatter.ToArabic(dt_count.Select("Grade_Id =3 and Religion_Id =1").Length),
                SchoolFormatter.ToArabic(dt_count.Select("Grade_Id =3 and Religion_Id =2").Length),
                "3"
       };
            dt_std_data.Rows.Add(row);


            row = new string[]
         {
                "الرابع ب",
                SchoolFormatter.ToArabic(dt_count.Select("Grade_Id =4").Length),
                SchoolFormatter.ToArabic(dt_count.Select("Grade_Id =4  and Gender_Id =1").Length),
                SchoolFormatter.ToArabic(dt_count.Select("Grade_Id =4  and Gender_Id =2").Length),
                SchoolFormatter.ToArabic(dt_count.Select("Grade_Id =4 and Religion_Id =1").Length),
                SchoolFormatter.ToArabic(dt_count.Select("Grade_Id =4 and Religion_Id =2").Length),
                "4"
     };
            dt_std_data.Rows.Add(row);

            row = new string[]
           {
                "الخامس ب",
                SchoolFormatter.ToArabic(dt_count.Select("Grade_Id =5").Length),
                SchoolFormatter.ToArabic(dt_count.Select("Grade_Id =5  and Gender_Id =1").Length),
                SchoolFormatter.ToArabic(dt_count.Select("Grade_Id =5  and Gender_Id =2").Length),
                SchoolFormatter.ToArabic(dt_count.Select("Grade_Id =5 and Religion_Id =1").Length),
                SchoolFormatter.ToArabic(dt_count.Select("Grade_Id =5 and Religion_Id =2").Length),
                "5"
       };
            dt_std_data.Rows.Add(row);

            row = new string[]
          {
                "السادس ب",
                SchoolFormatter.ToArabic(dt_count.Select("Grade_Id =6").Length),
                SchoolFormatter.ToArabic(dt_count.Select("Grade_Id =6  and Gender_Id =1").Length),
                SchoolFormatter.ToArabic(dt_count.Select("Grade_Id =6  and Gender_Id =2").Length),
                SchoolFormatter.ToArabic(dt_count.Select("Grade_Id =6 and Religion_Id =1").Length),
                SchoolFormatter.ToArabic(dt_count.Select("Grade_Id =6 and Religion_Id =2").Length),
                "6"
      };
            dt_std_data.Rows.Add(row);

            row = new string[]
            {
                "جملة المرحلة الإبتدائية",
                SchoolFormatter.ToArabic(dt_count.Select("Grade_Id < 7").Length),
                SchoolFormatter.ToArabic(dt_count.Select("Grade_Id < 7  and Gender_Id =1").Length),
                SchoolFormatter.ToArabic(dt_count.Select("Grade_Id < 7  and Gender_Id =2").Length),
                SchoolFormatter.ToArabic(dt_count.Select("Grade_Id < 7 and Religion_Id =1").Length),
                SchoolFormatter.ToArabic(dt_count.Select("Grade_Id < 7 and Religion_Id =2").Length),
                "1"
        };
            dt_std_data.Rows.Add(row);


            row = new string[]
         {
                "الأول ع",
                SchoolFormatter.ToArabic(dt_count.Select("Grade_Id =7").Length),
                SchoolFormatter.ToArabic(dt_count.Select("Grade_Id =7  and Gender_Id =1").Length),
                SchoolFormatter.ToArabic(dt_count.Select("Grade_Id =7  and Gender_Id =2").Length),
                SchoolFormatter.ToArabic(dt_count.Select("Grade_Id =7 and Religion_Id =1").Length),
                SchoolFormatter.ToArabic(dt_count.Select("Grade_Id =7 and Religion_Id =2").Length),
                "7"
     };
            dt_std_data.Rows.Add(row);

            row = new string[]
           {
                "الثانى ع",
                SchoolFormatter.ToArabic(dt_count.Select("Grade_Id =8").Length),
                SchoolFormatter.ToArabic(dt_count.Select("Grade_Id =8  and Gender_Id =1").Length),
                SchoolFormatter.ToArabic(dt_count.Select("Grade_Id =8  and Gender_Id =2").Length),
                SchoolFormatter.ToArabic(dt_count.Select("Grade_Id =8 and Religion_Id =1").Length),
                SchoolFormatter.ToArabic(dt_count.Select("Grade_Id =8 and Religion_Id =2").Length),
                "8"
       };
            dt_std_data.Rows.Add(row);

            row = new string[]
          {
                "الثالث ع",
                SchoolFormatter.ToArabic(dt_count.Select("Grade_Id =9").Length),
                SchoolFormatter.ToArabic(dt_count.Select("Grade_Id =9  and Gender_Id =1").Length),
                SchoolFormatter.ToArabic(dt_count.Select("Grade_Id =9  and Gender_Id =2").Length),
                SchoolFormatter.ToArabic(dt_count.Select("Grade_Id =9 and Religion_Id =1").Length),
                SchoolFormatter.ToArabic(dt_count.Select("Grade_Id =9 and Religion_Id =2").Length),
                "9"
      };
            dt_std_data.Rows.Add(row);

            row = new string[]
            {
                "جملة المرحلة الإعدادية",
                SchoolFormatter.ToArabic(dt_count.Select("Grade_Id > 6 and  Grade_Id < 10").Length),
                SchoolFormatter.ToArabic(dt_count.Select("Grade_Id > 6 and Grade_Id < 10  and Gender_Id =1").Length),
                SchoolFormatter.ToArabic(dt_count.Select("Grade_Id > 6 and Grade_Id < 10  and Gender_Id =2").Length),
                SchoolFormatter.ToArabic(dt_count.Select("Grade_Id > 6 and Grade_Id < 10 and Religion_Id =1").Length),
                SchoolFormatter.ToArabic(dt_count.Select("Grade_Id > 6 and Grade_Id < 10 and Religion_Id =2").Length),
                "7"
        };
            dt_std_data.Rows.Add(row);

            row = new string[]
            {
                "الجملة العامة",
                SchoolFormatter.ToArabic(dt_count.Select("Grade_Id >0").Length),
                SchoolFormatter.ToArabic(dt_count.Select("Gender_Id =1").Length),
                SchoolFormatter.ToArabic(dt_count.Select("Gender_Id =2").Length),
                SchoolFormatter.ToArabic(dt_count.Select("Religion_Id =1").Length),
                SchoolFormatter.ToArabic(dt_count.Select("Religion_Id =2").Length),
                "0"
        };
            dt_std_data.Rows.Add(row);

            foreach (DataGridViewRow dtrow in dt_std_data.Rows)
            {
                if (dtrow.Cells[0].Value?.ToString() == "جملة رياض أطفال" ||
                    dtrow.Cells[0].Value?.ToString() == "جملة المرحلة الإبتدائية" ||
                    dtrow.Cells[0].Value?.ToString() == "جملة المرحلة الإعدادية")
                {
                    dtrow.DefaultCellStyle.BackColor = Color.LightGray;
                }
                if (dtrow.Cells[0].Value?.ToString() == "الجملة العامة")
                {
                    dtrow.DefaultCellStyle.BackColor = Color.Teal;
                }
            }
            dt_std_data.Columns[0].Width = 200;
            dt_std_data.Columns[6].Visible = false;
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

        private void LoadData()
        {
            Waiting.Start();
            if (_context != null && _context.CurrentYearData)
            {
                year = year_code;

            }
            else
            {
                year = year_code + 1;
            }
            dt_count = _dataService.Get_School_year_Data(year, 0, 0);

            Add_Data();
            int myYear = Properties.Settings.Default.MyYear;

            if (_context?.StudentCase.Has(GetStudentCase.DegreeStatement) != true)
            {

                lbl_current_year.Text = "احصاء " + SchoolFormatter.Year_Desc(
                     myYear,
                      _context?.CurrentYearData ?? false,
                      _context?.StudentCase.Has(GetStudentCase.StudentDetails) ?? false,
                      _context?.StudentCase.Has(GetStudentCase.ElthakStdNextYear) ?? false);
            }
            else
            {
                lbl_current_year.Text = "بيانات " + SchoolFormatter.Year_Desc(
                     myYear,
                     _context?.CurrentYearData ?? false,
                     _context?.StudentCase.Has(GetStudentCase.StudentDetails) ?? false,
                     _context?.StudentCase.Has(GetStudentCase.ElthakStdNextYear) ?? false);
            }
            Waiting.Stop();
        }
        private void FRM_CHOOSE_GRADE_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btn_close_b_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void btn_show_data_Click(object sender, EventArgs e)
        {
            Waiting.Start();
            if (dt_std_data.SelectedRows.Count != 0)
            {
                grade = Convert.ToInt16(dt_std_data.CurrentRow.Cells[6].Value);

            }
            FRM_CURRENT_STD.Get_Current_Std.grade = grade;


            AppNavigation.Instance
                .WithOwner(MAIN.FRM_MAIN.Get_Frm_Main)
                .SetContext(c =>
                {
                                
                c.CurrentYearData = _context.CurrentYearData;

                if (_context.StudentCase.Has(GetStudentCase.DegreeStatement))
                {
                    c.StudentCase |= GetStudentCase.DegreeStatement;
                }
                }).Show(FRM_CURRENT_STD.Get_Current_Std);


            //FRM_CURRENT_STD.Get_Current_Std.ShowDialog(MAIN.FRM_MAIN.Get_Frm_Main);
            this.Close();
            Waiting.Stop();

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
