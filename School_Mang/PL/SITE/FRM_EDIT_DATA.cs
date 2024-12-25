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

namespace School_Mang.PL.SITE
{
    public partial class FRM_EDIT_DATA : Form
    {
        // Form Closed
        private static FRM_EDIT_DATA Frm_Edid_Data;
        static void frm_Form_Closed(object sender, FormClosedEventArgs e)
        {
            Frm_Edid_Data = null;
        }
        public static FRM_EDIT_DATA Get_Frm_Edid_Data
        {
            get
            {
                if (Frm_Edid_Data == null)
                {
                    Frm_Edid_Data = new FRM_EDIT_DATA();
                    Frm_Edid_Data.FormClosed += new FormClosedEventHandler(frm_Form_Closed);
                }
                return Frm_Edid_Data;
            }
        }
        BL.MSG msg = new BL.MSG();
        BL.Waiting waiting = new BL.Waiting();
        BL.SITE.SiteExcelUtlity Excel = new BL.SITE.SiteExcelUtlity();
        BL.NATEG.cls_NATAG_FUNCTIONS natag_func = new BL.NATEG.cls_NATAG_FUNCTIONS();
        BL.SITE.CLS_MANGE_SITE Mange_Site = new BL.SITE.CLS_MANGE_SITE();

        public byte type ;
        private string excel_file_name;
        public FRM_EDIT_DATA()
        {
            InitializeComponent();
            if (Frm_Edid_Data == null)
            {
                Frm_Edid_Data = this;
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
        private void ReadData(byte type)
        {
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

                    case 10:
                        ReadUsers();
                        break;

                    case 11:
                        ReadStudents();
                        break;
                }
            }
            catch(Exception e)
            {
                msg.ErrorMesg(e.Message);
            }
           
        }

        private void ReadTopic()
        {
            try
            {
                waiting.Wait();
                DataTable data = Excel.ReadTopicDataFromExcel(excel_file_name);

                if (data == null)
                {
                    msg.ErrorMesg("لا توجد بيانات..!");
                    BL.Globals.Dir_Path = "D://Lessons";
                    return;
                }
                else
                {
                    foreach (DataRow row in data.Rows)
                    {
                        int TopicId = Convert.ToInt32(row["topic_id"]);
                        string Title = row["title"].ToString();
                        string Description = row["description"].ToString();
                        int GradeId = Convert.ToInt32(row["grade_id"]);
                        int SubjectId = Convert.ToInt32(row["subject_id"]);
                        int TermId = Convert.ToInt32(row["term_id"]);
                        short Lang = Convert.ToByte(row["lang"]);
                        short TopicSortNo = Convert.ToByte(row["topic_sort_no"]);

                        Mange_Site.Update_Topic_Data(TopicId, Title, Description, GradeId,
                                                    SubjectId, TermId, Lang, TopicSortNo);

                    }
                    waiting.End_WAit();
                    msg.MyMesg("تم تحديث الموضوعات بنجاح .. !");
                }
                waiting.End_WAit();
            }
            catch (Exception ex)
            {
                msg.ErrorMesg(ex.Message);
                waiting.End_WAit();
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
                        

                        Mange_Site.Update_Student_Data(Student_Id,Class_Id, Gender_Id, Religion_Id,
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

                        Mange_Site.Update_User_2025(username, passwordHash, firstName,
                                                    fullName,roleId,osraId);

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

        private void ReadCourse()
        {
            try
            {
                waiting.Wait();
                DataTable data = Excel.ReadCourseDataFromExcel(excel_file_name);

                if (data == null)
                {
                    msg.ErrorMesg("لا توجد بيانات..!");
                    BL.Globals.Dir_Path = "D://Lessons";
                    return;
                }
                else
                {
                    foreach (DataRow row in data.Rows)
                    {
                        int courseId = Convert.ToInt32(row["course_id"]);
                        int topicId = Convert.ToInt32(row["topic_id"]);
                        string title = row["title"].ToString();
                        string description = row["description"].ToString();
                        string courseImg = row["course_img"].ToString();
                        short courseSortNo = Convert.ToByte(row["course_sort_no"]);
                        int gradeId = Convert.ToInt32(row["grade_id"]);
                        int subjectId = Convert.ToInt32(row["subject_id"]);
                        int termId = Convert.ToInt32(row["term_id"]);
                       

                        Mange_Site.Update_Course_Data(courseId, topicId, title, description,
                                                    courseImg,courseSortNo,gradeId,subjectId,termId );

                    }
                    waiting.End_WAit();
                    msg.MyMesg("تم تحديث الدروس بنجاح .. !");
                }
                waiting.End_WAit();
            }
            catch (Exception ex)
            {
                msg.ErrorMesg(ex.Message);
                waiting.End_WAit();
            }
        }

        private void ReadSubPart()
        {
            try
            {
                waiting.Wait();
                DataTable data = Excel.ReadSubPartDataFromExcel(excel_file_name);

                if (data == null)
                {
                    msg.ErrorMesg("لا توجد بيانات..!");
                    BL.Globals.Dir_Path = "D://Lessons";
                    return;
                }
                else
                {
                    foreach (DataRow row in data.Rows)
                    {
                        int courseId = Convert.ToInt32(row["course_id"]);
                        string title = row["title"].ToString();
                        string description = row["description"].ToString();
                        string subpartmg = row["subpart_img"].ToString();
                        short sound = Convert.ToByte(row["sound"]);
                        int gradeId = Convert.ToInt32(row["grade_id"]);
                        int subjectId = Convert.ToInt32(row["subject_id"]);
                        int termId = Convert.ToInt32(row["term_id"]);


                        Mange_Site.Update_SubPart_Data(courseId, title, description,
                                                    subpartmg, sound, gradeId, subjectId, termId);

                    }
                    waiting.End_WAit();
                    msg.MyMesg("تم تحديث الفقرات بنجاح .. !");
                }
                waiting.End_WAit();
            }
            catch (Exception ex)
            {
                msg.ErrorMesg(ex.Message);
                waiting.End_WAit();
            }
        }

        private void ReadVocabulary()
        {
            try
            {
                waiting.Wait();
                DataTable data = Excel.ReadVocabularyDataFromExcel(excel_file_name);

                if (data == null)
                {
                    msg.ErrorMesg("لا توجد بيانات..!");
                    BL.Globals.Dir_Path = "D://Lessons";
                    return;
                }
                else
                {
                    foreach (DataRow row in data.Rows)
                    {
                        int courseId = Convert.ToInt32(row["course_id"]);
                        string vocabulary = row["vocabulary"].ToString();
                        string vocabularyText = row["vocabulary_text"].ToString();
                        short vocabularyKind = Convert.ToByte(row["vocabulary_kind"]);
                        short sound = Convert.ToByte(row["sound"]);
                        int gradeId = Convert.ToInt32(row["grade_id"]);
                        int subjectId = Convert.ToInt32(row["subject_id"]);
                        int termId = Convert.ToInt32(row["term_id"]);


                        Mange_Site.Update_Vocabulary_Data(courseId, vocabulary, vocabularyText,
                                                    vocabularyKind, sound, gradeId, subjectId, termId);

                    }
                    waiting.End_WAit();
                    msg.MyMesg("تم تحديث المفردات بنجاح .. !");
                }
                waiting.End_WAit();
            }
            catch (Exception ex)
            {
                msg.ErrorMesg(ex.Message);
                waiting.End_WAit();
            }
        } 
        private void ReadReview()
        {
            try
            {
                waiting.Wait();
                DataTable data = Excel.ReadReviewDataFromExcel(excel_file_name);

                if (data == null)
                {
                    msg.ErrorMesg("لا توجد بيانات..!");
                    BL.Globals.Dir_Path = "D://Lessons";
                    return;
                }
                else
                {
                    foreach (DataRow row in data.Rows)
                    {
                        int courseId = Convert.ToInt32(row["course_id"]);
                        string question = row["question"].ToString();
                        string answer = row["answer"].ToString();
                        string questionImg = row["question_img"].ToString();
                        short sound = Convert.ToByte(row["sound"]);
                        int gradeId = Convert.ToInt32(row["grade_id"]);
                        int subjectId = Convert.ToInt32(row["subject_id"]);
                        int termId = Convert.ToInt32(row["term_id"]);


                        Mange_Site.Update_Review_Data(courseId, question, answer,
                                                    questionImg, sound, gradeId, subjectId, termId);

                    }
                    waiting.End_WAit();
                    msg.MyMesg("تم تحديث المراجعات بنجاح .. !");
                }
                waiting.End_WAit();
            }
            catch (Exception ex)
            {
                msg.ErrorMesg(ex.Message);
                waiting.End_WAit();
            }
        }


        private void ReadQuiz()
        {
            try
            {
                waiting.Wait();
                DataTable data = Excel.ReadQuizDataFromExcel(excel_file_name);

                if (data == null)
                {
                    msg.ErrorMesg("لا توجد بيانات..!");
                    BL.Globals.Dir_Path = "D://Lessons";
                    return;
                }
                else
                {
                    foreach (DataRow row in data.Rows)
                    {  
                        int quizId = Convert.ToInt32(row["quiz_id"]);
                        string quizTitle = row["quiz_title"].ToString();
                        int courseId = Convert.ToInt32(row["course_id"]);
                        string quizDescription = row["quiz_description"].ToString();
                        int gradeId = Convert.ToInt32(row["grade_id"]);
                        int subjectId = Convert.ToInt32(row["subject_id"]);
                        int termId = Convert.ToInt32(row["term_id"]);
                        short sound = Convert.ToByte(row["sound"]);
                        short quizType = Convert.ToByte(row["quizType"]);
                        Mange_Site.Update_Quiz_Data(quizId, quizTitle,
                                         courseId, quizDescription, 
                                         gradeId,subjectId, termId,
                                         sound, quizType);
                    }
                    waiting.End_WAit();
                    msg.MyMesg("تم تحديث الإختبارات بنجاح .. !");
                }
                waiting.End_WAit();
            }
            catch (Exception ex)
            {
                msg.ErrorMesg(ex.Message);
                waiting.End_WAit();
            }
        }

        private void ReadQuestion()
        {
            try
            {
                waiting.Wait();
                DataTable data = Excel.ReadQuestionDataFromExcel(excel_file_name);

                if (data == null)
                {
                    msg.ErrorMesg("لا توجد بيانات..!");
                    BL.Globals.Dir_Path = "D://Lessons";
                    return;
                }
                else
                {
                    foreach (DataRow row in data.Rows)
                    {
                        int questionId = Convert.ToInt32(row["question_id"]);
                        int quizId = Convert.ToInt32(row["quiz_id"]);
                        int courseId = Convert.ToInt32(row["course_id"]);
                        string questionText = row["question_text"].ToString();
                        short questionType = Convert.ToByte(row["question_type"]);
                        int gradeId = Convert.ToInt32(row["grade_id"]);
                        int subjectId = Convert.ToInt32(row["subject_id"]);
                        int termId = Convert.ToInt32(row["term_id"]);
                       
                        Mange_Site.Update_Question_Data(questionId, quizId, courseId, questionText,
                                                        questionType, gradeId, subjectId,termId);                               

                    }
                    waiting.End_WAit();
                    msg.MyMesg("تم تحديث الأسئلة بنجاح .. !");
                }
                waiting.End_WAit();
            }
            catch (Exception ex)
            {
                msg.ErrorMesg(ex.Message);
                waiting.End_WAit();
            }
        }

        private void ReadAnswer()
        {
            try
            {
                waiting.Wait();
                DataTable data = Excel.ReadAnswerDataFromExcel(excel_file_name);

                if (data == null)
                {
                    msg.ErrorMesg("لا توجد بيانات..!");
                    BL.Globals.Dir_Path = "D://Lessons";
                    return;
                }
                else
                {
                    foreach (DataRow row in data.Rows)
                    {
                        int quizId = Convert.ToInt32(row["quiz_id"]);
                        int questionId = Convert.ToInt32(row["question_id"]);
                        string answerText = row["answer_text"].ToString();
                        short isCorrect = Convert.ToByte(row["is_correct"]);
                        int gradeId = Convert.ToInt32(row["grade_id"]);
                        int subjectId = Convert.ToInt32(row["subject_id"]);
                        int termId = Convert.ToInt32(row["term_id"]);

                        Mange_Site.Update_Answer_Data(quizId, questionId, answerText,
                                                       isCorrect, gradeId, subjectId, termId);

                    }
                    waiting.End_WAit();
                    msg.MyMesg("تم إضافة الإجابات بنجاح .. !");
                }
                waiting.End_WAit();
            }
            catch (Exception ex)
            {
                msg.ErrorMesg(ex.Message);
                waiting.End_WAit();
            }
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
            if(type == 3)
            {
                msg.MyExclamationMsg("تحديث الفقرات يعتمد على عنوان الفقرة ..!");
            }
            if(type == 4)
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
