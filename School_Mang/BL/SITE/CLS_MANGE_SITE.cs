using School_Mang.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Mang.BL.SITE
{
   public class CLS_MANGE_SITE
    {
        MSG msg = new MSG();
        Waiting waiting = new Waiting();

        private SiteAccessLayer CreateDAL()
        {
            return new SiteAccessLayer();
        }

        
        public DataTable Get_Count_Users_Data()
        {
            SiteAccessLayer DAL = new SiteAccessLayer();
            DataTable Dt;

            Dt = DAL.Selectdata("SP_Get_Count_Users_Data ", null);
            DAL.Close();
            return Dt;
        }

        public DataTable Get_Users_Data(string fullName, int code = 0)
        {
            var DAL = CreateDAL();
            SqlParameter[] param = new SqlParameter[4];

            param[0] = new SqlParameter("@grade_Id", SqlDbType.TinyInt);
            param[0].Value = Convert.ToByte(Globals.test_grade_id);

            param[1] = new SqlParameter("@serach", SqlDbType.NVarChar,3);
            param[1].Value = "yes";

            param[2] = new SqlParameter("@fullName", SqlDbType.NVarChar, 100);
            param[2].Value = fullName;

            param[3] = new SqlParameter("@code", SqlDbType.Int);
            param[3].Value = code;

            DataTable Dt;

            Dt = DAL.Selectdata("SP_Get_Users_Data ", param);
            DAL.Close();
            return Dt;
        }


        public DataTable Get_Users_Data(int code)
        {
            var DAL = CreateDAL();
            SqlParameter[] param = new SqlParameter[4];

            param[0] = new SqlParameter("@grade_Id", SqlDbType.TinyInt);
            param[0].Value = Convert.ToByte(Globals.test_grade_id);

            param[1] = new SqlParameter("@serach", SqlDbType.NVarChar, 3);
            param[1].Value = "yes";

            param[2] = new SqlParameter("@fullName", SqlDbType.NVarChar, 100);
            param[2].Value = "";

            param[3] = new SqlParameter("@code", SqlDbType.Int);
            param[3].Value = code;

            DataTable Dt;

            Dt = DAL.Selectdata("SP_Get_Users_Data ", param);
            DAL.Close();
            return Dt;
        }
        public DataTable Get_Users_Data(byte grade_Id)
        {
            var DAL = CreateDAL();
            SqlParameter[] param = new SqlParameter[4];

            param[0] = new SqlParameter("@grade_Id", SqlDbType.TinyInt);
            param[0].Value = grade_Id;

            param[1] = new SqlParameter("@serach", SqlDbType.NVarChar, 3);
            param[1].Value = "no";

            param[2] = new SqlParameter("@fullName", SqlDbType.NVarChar, 100);
            param[2].Value = "";

            param[3] = new SqlParameter("@code", SqlDbType.Int);
            param[3].Value = 0;

            DataTable Dt;

            Dt = DAL.Selectdata("SP_Get_Users_Data ", param);
            DAL.Close();
            return Dt;
        }

        public void Update_User_Data(int Golos, string fullName, string firstName, string stdCode)
        {

            var DAL = CreateDAL();

            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@userSchoolId", SqlDbType.Int);
            param[0].Value = Golos;

            param[1] = new SqlParameter("@fullName", SqlDbType.NVarChar, 255);
            param[1].Value = fullName;

            param[2] = new SqlParameter("@firstName", SqlDbType.NVarChar,255);
            param[2].Value = firstName;

            param[3] = new SqlParameter("@stdCode", SqlDbType.NVarChar, 50);
            param[3].Value = stdCode;

            DAL.ExeucuteCommand("SP_Update_User_Data", param);
        }

        public void Update_Student_Data(int Golos,
                                        byte grade_Id,
                                        byte class_Id,
                                        byte gender_Id,
                                        byte religion_Id,
                                        string stdCode)
        {

            var DAL = CreateDAL();

            SqlParameter[] param = new SqlParameter[6];
            param[0] = new SqlParameter("@student_Id", SqlDbType.Int);
            param[0].Value = Golos;

            param[1] = new SqlParameter("@grade_Id", SqlDbType.TinyInt);
            param[1].Value = grade_Id;

            param[2] = new SqlParameter("@class_Id", SqlDbType.TinyInt);
            param[2].Value = class_Id;

            param[3] = new SqlParameter("@gender_Id", SqlDbType.TinyInt);
            param[3].Value = gender_Id;

            param[4] = new SqlParameter("@religion_Id", SqlDbType.TinyInt);
            param[4].Value = religion_Id;

            param[5] = new SqlParameter("@stdCode", SqlDbType.NVarChar,50);
            param[5].Value = stdCode;

            DAL.ExeucuteCommand("SP_Update_Student_Data", param);
        }

        public DataTable Get_User_Code(int Golos = 0)
        {
            var DAL = CreateDAL();
            DataTable Dt;

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Golos", SqlDbType.Int);
            param[0].Value = Golos;

            Dt = DAL.Selectdata("SP_Get_User_Code ", param);
            DAL.Close();
            return Dt;
        }

        public DataTable Verify_UserSchoolId(int userSchoolId)
        {
            var DAL = CreateDAL();
            DataTable Dt;

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@userSchoolId", SqlDbType.Int);
            param[0].Value = userSchoolId; 

            Dt = DAL.Selectdata("SP_Verify_UserSchoolId", param);
            DAL.Close();
            return Dt;
        }

        public DataTable Verify_Username(string username)
        {
            var DAL = CreateDAL();
            DataTable Dt;

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@username", SqlDbType.NVarChar,255);
            param[0].Value = username;

            Dt = DAL.Selectdata("SP_Verify_Username", param);
            DAL.Close();
            return Dt;
        }

        public DataTable Verify_Std_Degrees(int student_Id)
        {
            var DAL = CreateDAL();
            DataTable Dt;

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@student_Id", SqlDbType.NVarChar, 255);
            param[0].Value = student_Id;

            Dt = DAL.Selectdata("SP_Verify_Std_Degrees", param);
            DAL.Close();
            return Dt;
        }

        public DataTable Verify_Std_Marks(int student_Id)
        {
            var DAL = CreateDAL();
            DataTable Dt;

            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@student_Id", SqlDbType.Int);
            param[0].Value = student_Id;

            Dt = DAL.Selectdata("SP_Verify_Std_Marks", param);
            DAL.Close();
            return Dt;
        }
        public void Add_User_Data(string username,
                                  string password,
                                  int roleId)
        {
            var DAL = CreateDAL();

            SqlParameter[] param = new SqlParameter[10];

            param[0] = new SqlParameter("@username", SqlDbType.NVarChar,255);
            param[0].Value = username;

            param[1] = new SqlParameter("@password", SqlDbType.NVarChar, 255);
            param[1].Value = password;

            param[2] = new SqlParameter("@firstName", SqlDbType.NVarChar, 255);
            string user_first_name = char.ToUpper(username.First()) + username.Substring(1).ToLower();
            param[2].Value = user_first_name;

            param[3] = new SqlParameter("@fullName", SqlDbType.NVarChar, 255);
            param[3].Value = "";

            param[4] = new SqlParameter("@userSchoolId", SqlDbType.Int);
            param[4].Value = 0;

            param[5] = new SqlParameter("@roleId", SqlDbType.Int);
            param[5].Value = roleId;

            param[6] = new SqlParameter("@class_Id", SqlDbType.Int);
            param[6].Value = 0;

            param[7] = new SqlParameter("@gender_Id", SqlDbType.Int);
            param[7].Value = 0;

            param[8] = new SqlParameter("@religion_Id", SqlDbType.Int);
            param[8].Value = 0;

            param[9] = new SqlParameter("@grade_Id", SqlDbType.Int);
            param[9].Value = 0;

            DAL.Open();
            DAL.ExeucuteCommand("SP_Add_User_Data", param);
            DAL.Close();
        }

        public void Add_User_Data(string username,
                                 string password,
                                 string firstName,
                                 string fullName,
                                 int userSchoolId,
                                 int roleId,
                                 int class_Id,
                                 int gender_Id,
                                 int religion_Id,
                                 int grade_Id,
                                 string stdCode)
        {
            var DAL = CreateDAL();

            SqlParameter[] param = new SqlParameter[11];

            param[0] = new SqlParameter("@username", SqlDbType.NVarChar, 255);
            param[0].Value = username;

            param[1] = new SqlParameter("@password", SqlDbType.NVarChar, 255);
            param[1].Value = password;

            param[2] = new SqlParameter("@firstName", SqlDbType.NVarChar, 255);
            param[2].Value = firstName;

            param[3] = new SqlParameter("@fullName", SqlDbType.NVarChar, 255);
            param[3].Value = fullName;

            param[4] = new SqlParameter("@userSchoolId", SqlDbType.Int);
            param[4].Value = userSchoolId;

            param[5] = new SqlParameter("@roleId", SqlDbType.Int);
            param[5].Value = roleId;

            param[6] = new SqlParameter("@class_Id", SqlDbType.Int);
            param[6].Value = class_Id;

            param[7] = new SqlParameter("@gender_Id", SqlDbType.Int);
            param[7].Value = gender_Id;

            param[8] = new SqlParameter("@religion_Id", SqlDbType.Int);
            param[8].Value = religion_Id;

            param[9] = new SqlParameter("@grade_Id", SqlDbType.Int);
            param[9].Value = grade_Id;

            param[10] = new SqlParameter("@stdCode", SqlDbType.NVarChar,50);
            param[10].Value = stdCode;
            DAL.Open();
            DAL.ExeucuteCommand("SP_Add_User_Data", param);
            DAL.Close();
        }

        public void Update_User_stdCode(string stdCode, int Golos )
                               
        {
            var DAL = CreateDAL();
            SqlParameter[] param = new SqlParameter[2];

            param[0] = new SqlParameter("@stdCode", SqlDbType.NVarChar, 50);
            param[0].Value = stdCode;

            param[1] = new SqlParameter("@userSchoolId", SqlDbType.Int);
            param[1].Value = Golos;


            DAL.Open();
            DAL.ExeucuteCommand("SP_Update_User_stdCode", param);
            DAL.Close();
        }

        public DataTable Get_User_Table_Data()
        {
            SiteAccessLayer DAL = new SiteAccessLayer();
            DataTable Dt;

            string query = @"select * from students;";
            Dt = DAL.ReadData_Query(query, null);
            DAL.Close();
            return Dt;

        }
        public void Update_User_2025(
                               string username,
                               string password,
                               string firstName,
                               string fullName,
                               int roleId,
                               string osraId,
                               string note)
        {
            waiting.Wait();
           var DAL = CreateDAL();

            SqlParameter[] param = new SqlParameter[7];
            param[0] = new SqlParameter("@username", SqlDbType.NVarChar,20);
            param[0].Value = username;

            param[1] = new SqlParameter("@password", SqlDbType.NVarChar, 255);
            param[1].Value = password;

            param[2] = new SqlParameter("@firstName", SqlDbType.NVarChar, 50);
            param[2].Value = firstName;

            param[3] = new SqlParameter("@fullName", SqlDbType.NVarChar, 255);
            param[3].Value = fullName;

            param[4] = new SqlParameter("@roleId", SqlDbType.Int);
            param[4].Value = roleId;

            param[5] = new SqlParameter("@osraId", SqlDbType.NVarChar, 50);
            param[5].Value = osraId;

            param[6] = new SqlParameter("@note", SqlDbType.NVarChar, 250);
            param[6].Value = note;

            DAL.ExeucuteCommand("SP_Add_User_2025", param);
            waiting.End_WAit();
        }

        public void Update_Student_Data(
                              int Student_Id,
                              int Class_Id,
                              int Gender_Id,
                              int Religion_Id,
                              int Grade_Id,
                              string std_code,
                              string Osraa_Id,
                              string std_name,
                              string full_name)
        {
            waiting.Wait();
            var DAL = CreateDAL();

            SqlParameter[] param = new SqlParameter[9];
            param[0] = new SqlParameter("@Student_Id", SqlDbType.Int);
            param[0].Value = Student_Id;

            param[1] = new SqlParameter("@Class_Id", SqlDbType.Int);
            param[1].Value = Class_Id;

            param[2] = new SqlParameter("@Gender_Id", SqlDbType.Int);
            param[2].Value = Gender_Id;

            param[3] = new SqlParameter("@Religion_Id", SqlDbType.Int);
            param[3].Value = Religion_Id;

            param[4] = new SqlParameter("@Grade_Id", SqlDbType.Int);
            param[4].Value = Grade_Id;

            param[5] = new SqlParameter("@std_code", SqlDbType.NVarChar, 50);
            param[5].Value = std_code;

            param[6] = new SqlParameter("@Osraa_Id", SqlDbType.NVarChar, 50);
            param[6].Value = Osraa_Id;

            param[7] = new SqlParameter("@std_name", SqlDbType.NVarChar, 50);
            param[7].Value = std_name;

            param[8] = new SqlParameter("@full_name", SqlDbType.NVarChar, 255);
            param[8].Value = full_name;


            DAL.ExeucuteCommand("SP_Add_Students_Data", param);
            waiting.End_WAit();
        }

        public void Update_Topic_Data(int TopicId,
                                string Title,
                                string Description,
                                int GradeId,
                                int SubjectId,
                                int TermId,
                                short Lang,
                                short TopicSortNo)
        {
            waiting.Wait();
            var DAL = CreateDAL();

            SqlParameter[] param = new SqlParameter[8];
            param[0] = new SqlParameter("@TopicId", SqlDbType.Int);
            param[0].Value = TopicId;

            param[1] = new SqlParameter("@Title", SqlDbType.NVarChar,255);
            param[1].Value = Title;

            param[2] = new SqlParameter("@Description", SqlDbType.NVarChar, 500);
            param[2].Value = Description;

            param[3] = new SqlParameter("@GradeId", SqlDbType.Int);
            param[3].Value = GradeId;

            param[4] = new SqlParameter("@SubjectId", SqlDbType.Int);
            param[4].Value = SubjectId;

            param[5] = new SqlParameter("@TermId", SqlDbType.Int);
            param[5].Value = TermId;

            param[6] = new SqlParameter("@Lang", SqlDbType.TinyInt);
            param[6].Value = Lang;

            param[7] = new SqlParameter("@TopicSortNo", SqlDbType.TinyInt);
            param[7].Value = TopicSortNo;

            DAL.ExeucuteCommand("SP_Lessons_Add_Topic", param);
            waiting.End_WAit();
        }  
        
        public void Update_Course_Data(int courseId,
                                int topicId,
                                string title,
                                string description,
                                string courseImg,
                                short courseSortNo,
                                int gradeId,
                                int subjectId,
                                int termId)
        {
            waiting.Wait();
            var DAL = CreateDAL();

            SqlParameter[] param = new SqlParameter[9];
            param[0] = new SqlParameter("@courseId", SqlDbType.Int);
            param[0].Value = courseId;

            param[1] = new SqlParameter("@topicId", SqlDbType.Int);
            param[1].Value = topicId;

            param[2] = new SqlParameter("@title", SqlDbType.NVarChar,255);
            param[2].Value = title;

            param[3] = new SqlParameter("@description", SqlDbType.NVarChar, 1000);
            param[3].Value = description;

            param[4] = new SqlParameter("@courseImg", SqlDbType.NVarChar, 255);
            param[4].Value = courseImg;
            
            param[5] = new SqlParameter("@courseSortNo", SqlDbType.TinyInt);
            param[5].Value = courseSortNo;

            param[6] = new SqlParameter("@gradeId", SqlDbType.Int);
            param[6].Value = gradeId;

            param[7] = new SqlParameter("@subjectId", SqlDbType.Int);
            param[7].Value = subjectId;

            param[8] = new SqlParameter("@termId", SqlDbType.Int);
            param[8].Value = termId;


            DAL.ExeucuteCommand("SP_Lessons_Add_Course", param);
            waiting.End_WAit();
        }

        public void Update_SubPart_Data(int courseId,
                              string title,
                              string description,
                              string subpartmg,
                              short sound,
                              int gradeId,
                              int subjectId,
                              int termId)
        {
            waiting.Wait();
            var DAL = CreateDAL();

            SqlParameter[] param = new SqlParameter[8];
            param[0] = new SqlParameter("@courseId", SqlDbType.Int);
            param[0].Value = courseId;

            param[1] = new SqlParameter("@title", SqlDbType.NVarChar, 255);
            param[1].Value = title;

            param[2] = new SqlParameter("@description", SqlDbType.NVarChar, 1000);
            param[2].Value = description;

            param[3] = new SqlParameter("@subpartmg", SqlDbType.NVarChar, 255);
            param[3].Value = subpartmg;

            param[4] = new SqlParameter("@sound", SqlDbType.TinyInt);
            param[4].Value = sound;

            param[5] = new SqlParameter("@gradeId", SqlDbType.Int);
            param[5].Value = gradeId;

            param[6] = new SqlParameter("@subjectId", SqlDbType.Int);
            param[6].Value = subjectId;

            param[7] = new SqlParameter("@termId", SqlDbType.Int);
            param[7].Value = termId;


            DAL.ExeucuteCommand("SP_Lessons_Add_SubPart", param);
            waiting.End_WAit();
        }

        public void Update_Vocabulary_Data(int courseId,
                             string vocabulary,
                             string vocabularyText,
                             short vocabularyKind,
                             short sound,
                             int gradeId,
                             int subjectId,
                             int termId)
        {
            waiting.Wait();
            var DAL = CreateDAL();

            SqlParameter[] param = new SqlParameter[8];
            param[0] = new SqlParameter("@courseId", SqlDbType.Int);
            param[0].Value = courseId;

            param[1] = new SqlParameter("@vocabulary", SqlDbType.NVarChar, 50);
            param[1].Value = vocabulary;

            param[2] = new SqlParameter("@vocabularyText", SqlDbType.NVarChar, 100);
            param[2].Value = vocabularyText;

            param[3] = new SqlParameter("@vocabularyKind", SqlDbType.TinyInt);
            param[3].Value = vocabularyKind;

            param[4] = new SqlParameter("@sound", SqlDbType.TinyInt);
            param[4].Value = sound;

            param[5] = new SqlParameter("@gradeId", SqlDbType.Int);
            param[5].Value = gradeId;

            param[6] = new SqlParameter("@subjectId", SqlDbType.Int);
            param[6].Value = subjectId;

            param[7] = new SqlParameter("@termId", SqlDbType.Int);
            param[7].Value = termId;


            DAL.ExeucuteCommand("SP_Lessons_Add_Vocabulary", param);
            waiting.End_WAit();
        }
        
        public void Update_Review_Data(int courseId,
                             string question,
                             string answer,
                             string questionImg,
                             short sound,
                             int gradeId,
                             int subjectId,
                             int termId)
        {
            waiting.Wait();
            var DAL = CreateDAL();

            SqlParameter[] param = new SqlParameter[8];
            param[0] = new SqlParameter("@courseId", SqlDbType.Int);
            param[0].Value = courseId;

            param[1] = new SqlParameter("@question", SqlDbType.NVarChar, 255);
            param[1].Value = question;

            param[2] = new SqlParameter("@answer", SqlDbType.NVarChar, 255);
            param[2].Value = answer;

            param[3] = new SqlParameter("@questionImg", SqlDbType.NVarChar, 255);
            param[3].Value = questionImg;

            param[4] = new SqlParameter("@sound", SqlDbType.TinyInt);
            param[4].Value = sound;

            param[5] = new SqlParameter("@gradeId", SqlDbType.Int);
            param[5].Value = gradeId;

            param[6] = new SqlParameter("@subjectId", SqlDbType.Int);
            param[6].Value = subjectId;

            param[7] = new SqlParameter("@termId", SqlDbType.Int);
            param[7].Value = termId;


            DAL.ExeucuteCommand("SP_Lessons_Add_Review", param);
            waiting.End_WAit();
        }     
        
        public void Update_Quiz_Data(int quizId,
                             string quizTitle,
                             int courseId,
                             string quizDescription,
                             int gradeId,
                             int subjectId,
                             int termId,
                             short sound,
                             short quizType
                             )
        {
            waiting.Wait();
            var DAL = CreateDAL();

            SqlParameter[] param = new SqlParameter[9];
            param[0] = new SqlParameter("@quizId", SqlDbType.Int);
            param[0].Value = quizId;

            param[1] = new SqlParameter("@quizTitle", SqlDbType.NVarChar, 1000);
            param[1].Value = quizTitle;

            param[2] = new SqlParameter("@courseId", SqlDbType.Int);
            param[2].Value = courseId;

            param[3] = new SqlParameter("@quizDescription", SqlDbType.NVarChar, 1000);
            param[3].Value = quizDescription;

            param[4] = new SqlParameter("@gradeId", SqlDbType.Int);
            param[4].Value = gradeId;

            param[5] = new SqlParameter("@subjectId", SqlDbType.Int);
            param[5].Value = subjectId;

            param[6] = new SqlParameter("@termId", SqlDbType.Int);
            param[6].Value = termId;

            param[7] = new SqlParameter("@sound", SqlDbType.TinyInt);
            param[7].Value = sound;

            param[8] = new SqlParameter("@quizType", SqlDbType.TinyInt);
            param[8].Value = quizType;

            DAL.ExeucuteCommand("SP_Lessons_Add_Quiz", param);
            waiting.End_WAit();
        }


        public void Update_Question_Data(int questionId,
                                         int quizId,
                                         int courseId,
                                         string questionText,
                                         short questionType,
                                         int gradeId,
                                         int subjectId,
                                         int termId,
                                         short lang = 1)
        {
            waiting.Wait();
            var DAL = CreateDAL();

            SqlParameter[] param = new SqlParameter[9];
            param[0] = new SqlParameter("@questionId", SqlDbType.Int);
            param[0].Value = questionId;

            param[1] = new SqlParameter("@quizId", SqlDbType.Int);
            param[1].Value = quizId;

            param[2] = new SqlParameter("@courseId", SqlDbType.Int);
            param[2].Value = courseId;

            param[3] = new SqlParameter("@questionText", SqlDbType.NVarChar,500);
            param[3].Value = questionText;

            param[4] = new SqlParameter("@questionType", SqlDbType.TinyInt);
            param[4].Value = questionType;

            param[5] = new SqlParameter("@gradeId", SqlDbType.Int);
            param[5].Value = gradeId;

            param[6] = new SqlParameter("@subjectId", SqlDbType.Int);
            param[6].Value = subjectId;

            param[7] = new SqlParameter("@termId", SqlDbType.Int);
            param[7].Value = termId;
            
            param[8] = new SqlParameter("@lang", SqlDbType.TinyInt);
            param[8].Value = lang;

            DAL.ExeucuteCommand("SP_Lessons_Add_Question", param);
            waiting.End_WAit();
        }

        public void Update_Answer_Data(int courseId,
                                       int quizId,
                                       int questionId,
                                       string answerText,
                                       short isCorrect,
                                       int gradeId,
                                       int subjectId,
                                       int termId)
        {
            waiting.Wait();
            var DAL = CreateDAL();

            SqlParameter[] param = new SqlParameter[8];
            param[0] = new SqlParameter("@courseId", SqlDbType.Int);
            param[0].Value = courseId;
            
            param[1] = new SqlParameter("@quizId", SqlDbType.Int);
            param[1].Value = quizId;

            param[2] = new SqlParameter("@questionId", SqlDbType.Int);
            param[2].Value = questionId;

            param[3] = new SqlParameter("@answerText", SqlDbType.NVarChar, 500);
            param[3].Value = answerText;

            param[4] = new SqlParameter("@isCorrect", SqlDbType.TinyInt);
            param[4].Value = isCorrect;

            param[5] = new SqlParameter("@gradeId", SqlDbType.Int);
            param[5].Value = gradeId;

            param[6] = new SqlParameter("@subjectId", SqlDbType.Int);
            param[6].Value = subjectId;

            param[7] = new SqlParameter("@termId", SqlDbType.Int);
            param[7].Value = termId;

            DAL.ExeucuteCommand("SP_Lessons_Add_Answer", param);
            waiting.End_WAit();
        }



        // جلب كل المفاتيح الأربعة لكل جدول
        public HashSet<TableKey> GetTableKeys()
        {
            HashSet<TableKey> result = new HashSet<TableKey>();

            var DAL = CreateDAL();

            try
            {
                string query = @"
            SELECT course_id, grade_id, subject_id, term_id 
            FROM courses";

                DataTable dt = DAL.ReadData_Query(query, null);

                foreach (DataRow row in dt.Rows)
                {
                    if (row["course_id"] == DBNull.Value ||
                        row["grade_id"] == DBNull.Value ||
                        row["subject_id"] == DBNull.Value ||
                        row["term_id"] == DBNull.Value)
                        continue;

                    int k1 = Convert.ToInt32(row["course_id"]);
                    int k2 = Convert.ToInt32(row["grade_id"]);
                    int k3 = Convert.ToInt32(row["subject_id"]);
                    int k4 = Convert.ToInt32(row["term_id"]);

                    // حماية إضافية
                    if (k1 <= 0 || k2 <= 0 || k3 <= 0 || k4 <= 0)
                        continue;

                    result.Add(new TableKey(k1, k2, k3, k4));
                }
            }
            finally
            {
                DAL.Close();
            }

            return result;
        }

        public bool QuizExistsInContext(int courseId, int gradeId, int subjectId, int termId, int quizId)
        {
            var DAL = CreateDAL();
            string query = @"
                            SELECT TOP 1 1
                            FROM quizzes
                            WHERE course_id = @c
                              AND grade_id = @g
                              AND subject_id = @s
                              AND term_id = @t
                              AND quiz_id = @q";

            var prms = new SqlParameter[]
                      {
                        new SqlParameter("@c", courseId),
                        new SqlParameter("@g", gradeId),
                        new SqlParameter("@s", subjectId),
                        new SqlParameter("@t", termId),
                        new SqlParameter("@q", quizId)
                      };


            DataTable dt = DAL.ReadData_Query(query, prms);

            return dt.Rows.Count > 0;
        }
        public bool QuestionHasAnswers(int courseId, int quizId, int questionId, int gradeId, int subjectId, int termId)
        {
            var DAL = CreateDAL();

            string query = @"
        SELECT TOP 1 1
        FROM answers
        WHERE course_id = @c
          AND quiz_id = @qz
          AND question_id = @q
          AND grade_id = @g
          AND subject_id = @s
          AND term_id = @t";

            var prms = new SqlParameter[]
            {
        new SqlParameter("@c", courseId),
        new SqlParameter("@qz", quizId),
        new SqlParameter("@q", questionId),
        new SqlParameter("@g", gradeId),
        new SqlParameter("@s", subjectId),
        new SqlParameter("@t", termId)
            };

            DataTable dt = DAL.ReadData_Query(query, prms);

            return dt.Rows.Count > 0;
        }
        public bool QuestionExistsInContext(int courseId, int quizId, int questionId, int gradeId, int subjectId, int termId)
        {
            var DAL = CreateDAL();

            string query = @"
                                SELECT TOP 1 1
                                FROM questions
                                WHERE course_id = @c
                                  AND quiz_id = @qz
                                  AND question_id = @q
                                  AND grade_id = @g
                                  AND subject_id = @s
                                  AND term_id = @t";

            var prms = new SqlParameter[]
            {
        new SqlParameter("@c", courseId),
        new SqlParameter("@qz", quizId),
        new SqlParameter("@q", questionId),
        new SqlParameter("@g", gradeId),
        new SqlParameter("@s", subjectId),
        new SqlParameter("@t", termId)
            };

            DataTable dt = DAL.ReadData_Query(query, prms);

            return dt.Rows.Count > 0;
        }

    }
}
