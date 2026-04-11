using School_Mang.BL.Common.Extensions;
using School_Mang.BL.SITE;
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
using static DevExpress.Xpo.Helpers.AssociatedCollectionCriteriaHelper;
using School_Mang.BL.Common.Helper;


namespace School_Mang.PL.SITE
{
    public partial class FRM_EDIT_DATA : Form
    {
        // Form Closed
        private static FRM_EDIT_DATA Frm_Edit_Data;
        static void frm_Form_Closed(object sender, FormClosedEventArgs e)
        {
            Frm_Edit_Data = null;
        }
        public static FRM_EDIT_DATA Get_Frm_Edit_Data
        {
            get
            {
                if (Frm_Edit_Data == null)
                {
                    Frm_Edit_Data = new FRM_EDIT_DATA();
                    Frm_Edit_Data.FormClosed += new FormClosedEventHandler(frm_Form_Closed);
                }
                return Frm_Edit_Data;
            }
        }
        BL.MSG msg = new BL.MSG();
        BL.Waiting waiting = new BL.Waiting();
        SiteExcelUtlity Excel = new SiteExcelUtlity();
        BL.NATEG.cls_NATAG_FUNCTIONS natag_func = new BL.NATEG.cls_NATAG_FUNCTIONS();
        CLS_MANGE_SITE Mange_Site = new CLS_MANGE_SITE();
        CLS_READ_EXCEL Read_Excel = new CLS_READ_EXCEL();

        public byte type;
        private string excel_file_name;
        public FRM_EDIT_DATA()
        {
            InitializeComponent();
            if (Frm_Edit_Data == null)
            {
                Frm_Edit_Data = this;
            }
        }

        private void Save_Data_TO_Excel(string worksheetName)
        {
            string title = worksheetName;
            string file_name = @"\" + worksheetName + ".xlsx";

            string saveAsLocation;

            string staticExcelFile = AppDomain.CurrentDomain.BaseDirectory + @"Excel\Lessons\" + worksheetName + ".xlsx";
            switch (type)
            {
                case 10:
                case 11:
                    staticExcelFile = AppDomain.CurrentDomain.BaseDirectory + @"Excel\Users\" + worksheetName + ".xlsx";
                    break;
            }


            // Folder Path
            string folder = Properties.Settings.Default.save_Lessons_path;
            switch (type)
            {
                case 10:
                case 11:
                    folder = Properties.Settings.Default.save_Users_path;
                    break;
            }
            bool exists = Directory.Exists(folder);
            if (!exists) Directory.CreateDirectory(folder);
            folderBrowserDialog1.SelectedPath = folder;

            // Show the FolderBrowserDialog.  
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result != DialogResult.OK)
            {
                msg.ErrorMesg("يرجى اختيار مسار الحفظ .. !");
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
                        return;
                    }
                }
            }
            waiting.Wait();

            try
            {

                if (Excel.WriteLessonsDataToExcel(worksheetName, saveAsLocation, title, staticExcelFile))
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
        private async void ReadData(byte type)
        {
            bool isConnected = await InternetHelper.CheckInternetAsync();
            if (!isConnected)
            {
                msg.ErrorMesg("تأكد من الإتصال بالإنترنت..!");
                return;
            }

            try
            {
                excel_file_name = natag_func.OpenDialoge(openFileDialog1);

                if (excel_file_name == null)
                {
                    msg.ErrorMesg("تم إلغاء الإجراء..!");
                    BL.Globals.Dir_Path = "D://Lessons";
                    return;
                }
                switch (type)
                {
                    case 1:
                        ReadTopic();
                        break;
                    case 2:
                        ReadCourse();
                        break;
                    case 3:
                        ReadSubPart();
                        break;
                    case 4:
                        ReadVocabulary();
                        break;
                    case 5:
                        ReadReview();
                        break;
                    case 6:
                        ReadQuiz();
                        break;
                    case 7:
                        ReadQuestion();
                        break;
                    case 8:
                        ReadAnswer();
                        break;
                    case 9:
                        ReadQusestionsByAnswer();
                        break;
                    case 10:
                        ReadUsers();
                        break;

                    case 11:
                        ReadStudents();
                        break;
                }
            }
            catch (Exception e)
            {
                msg.ErrorMesg(e.Message);
            }

        }

       
        private void ReadStudents()
        {
            try
            {
                waiting.Wait();
                DataTable data = Excel.ReadStudentsDataFromExcel(excel_file_name);

                if (data == null)
                {
                    msg.ErrorMesg("لا توجد بيانات..!");
                    BL.Globals.Dir_Path = "D://Users";
                    return;
                }
                else
                {
                    foreach (DataRow row in data.Rows)
                    {
                        int Student_Id = Convert.ToInt32(row["Student_Id"]);
                        int Class_Id = Convert.ToInt32(row["Class_Id"]);
                        int Gender_Id = Convert.ToInt32(row["Gender_Id"]);
                        int Religion_Id = Convert.ToInt32(row["Religion_Id"]);
                        int Grade_Id = Convert.ToInt32(row["Grade_Id"]);
                        string std_code = row["std_code"].ToString();
                        string Osraa_Id = row["Osraa_Id"].ToString();
                        string std_name = row["std_name"].ToString();
                        string full_name = row["full_name"].ToString();


                        Mange_Site.Update_Student_Data(Student_Id, Class_Id, Gender_Id, Religion_Id,
                                                    Grade_Id, std_code, Osraa_Id,
                                                    std_name, full_name);

                    }
                    waiting.End_WAit();
                    msg.MyMesg("تم تحديث الطلاب بنجاح .. !");
                }
                waiting.End_WAit();
            }
            catch (Exception ex)
            {
                msg.ErrorMesg(ex.Message);
                waiting.End_WAit();
            }
        }

        private void ReadUsers()
        {
            try
            {
                waiting.Wait();
                DataTable data = Excel.ReadUsersDataFromExcel(excel_file_name);

                if (data == null)
                {
                    msg.ErrorMesg("لا توجد بيانات..!");
                    BL.Globals.Dir_Path = "D://Users";
                    return;
                }
                else
                {
                    foreach (DataRow row in data.Rows)
                    {
                        string username = row["username"].ToString();
                        string password = row["password"].ToString();
                        var passwordHash = BCrypt.Net.BCrypt.HashPassword(password, 10);
                        string firstName = row["firstName"].ToString();
                        string fullName = row["fullName"].ToString();
                        int roleId = Convert.ToInt32(row["roleId"]);
                        string osraId = row["osraId"].ToString();
                        string note = row["note"].ToString();

                        Mange_Site.Update_User_2025(username, passwordHash, firstName,
                                                    fullName, roleId, osraId, note);

                    }
                    waiting.End_WAit();
                    msg.MyMesg("تم تحديث المستخدمين بنجاح .. !");
                }
                waiting.End_WAit();
            }
            catch (Exception ex)
            {
                msg.ErrorMesg(ex.Message);
                waiting.End_WAit();
            }
        }

        private void ReadTopic()
        {
            var manager = new ExcelDataManager(Read_Excel, Mange_Site);

            var result = manager.ImportTopicss(
                excel_file_name,
                "topic",
                msg.ErrorMesg,
                waiting.Wait,
                waiting.End_WAit,
                null
            );

            if (!result.Success)
            {
                foreach (var err in result.Errors)
                    msg.ErrorMesg(err);

                return;
            }

            msg.MyMesg($"تم بنجاح ✅ عدد الصفوف: {result.ProcessedRows}");
        }

        private void ReadCourse()
        {
            var manager = new ExcelDataManager(Read_Excel, Mange_Site);

            var result = manager.ImportCourses(
                excel_file_name,
                "course",
                msg.ErrorMesg,
                waiting.Wait,
                waiting.End_WAit,
                null
            );

            if (!result.Success)
            {
                foreach (var err in result.Errors)
                    msg.ErrorMesg(err);

                return;
            }

            msg.MyMesg($"تم بنجاح ✅ عدد الصفوف: {result.ProcessedRows}");
        }


        private void ReadSubPart()
        {
            var manager = new ExcelDataManager(Read_Excel, Mange_Site);

            var result = manager.ImportSubParts(
                excel_file_name,
                "subpart",
                msg.ErrorMesg,
                waiting.Wait,
                waiting.End_WAit,
                "subparts"
            );

            if (!result.Success)
            {
                foreach (var err in result.Errors)
                    msg.ErrorMesg(err);

                return;
            }

            msg.MyMesg($"تم بنجاح ✅ عدد الصفوف: {result.ProcessedRows}");
        }

        private void ReadVocabulary()
        {
            var manager = new ExcelDataManager(Read_Excel, Mange_Site);

            var result = manager.ImportVocabularies(
                excel_file_name,
                "vocabulary",
                msg.ErrorMesg,
                waiting.Wait,
                waiting.End_WAit,
                "vocabularies"
            );

            if (!result.Success)
            {
                foreach (var err in result.Errors)
                    msg.ErrorMesg(err);

                return;
            }

            msg.MyMesg($"تم بنجاح ✅ عدد الصفوف: {result.ProcessedRows}");
        }


        private void ReadReview()
        {
            var manager = new ExcelDataManager(Read_Excel, Mange_Site);

            var result = manager.ImportReviews(
                excel_file_name,
                "review",
                msg.ErrorMesg,
                waiting.Wait,
                waiting.End_WAit,
                "reviews"
            );

            if (!result.Success)
            {
                foreach (var err in result.Errors)
                    msg.ErrorMesg(err);

                return;
            }

            msg.MyMesg($"تم بنجاح ✅ عدد الصفوف: {result.ProcessedRows}");
        }
        private void ReadQuiz()
        {
            var manager = new ExcelDataManager(Read_Excel, Mange_Site);

            var result = manager.ImportQuizes(
                excel_file_name,
                "quiz",
                msg.ErrorMesg,
                waiting.Wait,
                waiting.End_WAit,
                "quizzes"
            );

            if (!result.Success)
            {
                foreach (var err in result.Errors)
                    msg.ErrorMesg(err);

                return;
            }

            msg.MyMesg($"تم بنجاح ✅ عدد الصفوف: {result.ProcessedRows}");
        }

        private void ReadQuestion()
        {
            var manager = new ExcelDataManager(Read_Excel, Mange_Site);

            var result = manager.ImportQuestions(
            excel_file_name,
            "question",
            msg.ErrorMesg,
            waiting.Wait,
            waiting.End_WAit,
            "questions");
               

            if (!result.Success)
            {
                foreach (var err in result.Errors)
                    msg.ErrorMesg(err);

                return;
            }

            msg.MyMesg($"تم بنجاح ✅ عدد الصفوف: {result.ProcessedRows}");
        }
        

        private void ReadAnswer()
        {
            var manager = new ExcelDataManager(Read_Excel, Mange_Site);

            var result = manager.ImportAnswers(
            excel_file_name,
            "answer",
            msg.ErrorMesg,
            waiting.Wait,
            waiting.End_WAit,
            "answers");

            if (!result.Success)
            {
                foreach (var err in result.Errors)
                    msg.ErrorMesg(err);

                return;                
            }
            msg.MyMesg($"تم بنجاح ✅ عدد الصفوف: {result.ProcessedRows}");
        }

        private void ReadQusestionsByAnswer()
        {
            var manager = new ExcelDataManager(Read_Excel, Mange_Site);

            var result = manager.ImportQuestionsWithAnswers(
            excel_file_name,
            "mlutiquestion",
            msg.ErrorMesg,
            waiting.Wait,
            waiting.End_WAit,
            "questions");

            if (!result.Success)
            {
                foreach (var err in result.Errors)
                    msg.ErrorMesg(err);

                return;
            }
            msg.MyMesg($"تم بنجاح ✅ عدد الصفوف: {result.ProcessedRows}");
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

        private void FRM_EDIT_DATA_Load(object sender, EventArgs e)
        {

        }

        private void lbl_get_file_Click(object sender, EventArgs e)
        {
            string exel_name;
            switch (type)
            {
                case 1:
                    exel_name = "topic";
                    break;
                case 2:
                    exel_name = "course";
                    break;
                case 3:
                    exel_name = "subpart"; // Add The names >> >> >>
                    break;
                case 4:
                    exel_name = "vocabulary";
                    break;
                case 5:
                    exel_name = "review";
                    break;
                case 6:
                    exel_name = "quiz";
                    break;
                case 7:
                    exel_name = "question";
                    break;
                case 8:
                    exel_name = "answer";
                    break;
                case 9:
                    exel_name = "questions_by_answers";
                    break;
                case 10:
                    exel_name = "users";
                    break;

                case 11:
                    exel_name = "students";
                    break;

                default:
                    exel_name = "topic";
                    break;
            }

            Save_Data_TO_Excel(exel_name);
        }


        private void pic_get_file_Click(object sender, EventArgs e)
        {
            lbl_get_file_Click(sender, e);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            if (type == 3)
            {
                msg.MyExclamationMsg("تحديث الفقرات يعتمد على عنوان الفقرة ..!");
            }
            if (type == 4)
            {
                msg.MyExclamationMsg("تحديث الفقرات يعتمد على المفردة  ..!");
                msg.MyExclamationMsg("في حالة تغيير المفردة سيتم إضافة مفردة جديدة ..!");
            }
            if (type == 8)
            {
                msg.MyExclamationMsg("سوف يتم إضافة جميع الإجابات ..!");
                if (msg.DialogeErrMsg("هل تريد إضافة جميع الإجابات ... ؟") == DialogResult.No)
                {
                    return;
                }
            }
            // Chang Void By Names
            ReadData(type);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            label1_Click(sender, e);
        }
    }
}
