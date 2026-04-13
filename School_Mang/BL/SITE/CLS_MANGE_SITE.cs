using School_Mang.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using School_Mang.BL.Common.Helper;


namespace School_Mang.BL.SITE
{
    public class CLS_MANGE_SITE
    {
        MSG msg = new MSG();
        Waiting waiting = new Waiting();
        private readonly SiteAccessLayer DAL = new SiteAccessLayer();


        public void RunInTransaction(Action action)
        {
             DAL.RunInTransaction(action);
        }

        // =========================
        // USERS
        // =========================

        public DataTable Get_Count_Users_Data()
        {
            return DAL.ExecQuery("SP_Get_Count_Users_Data");
        }

        public DataTable Get_Users_Data(string fullName, int code = 0)
        {
            return DAL.ExecQuery("SP_Get_Users_Data",
                 SqlParam.Byte("@grade_Id", Convert.ToByte(Globals.test_grade_id)),
                 SqlParam.NVar("@serach", "yes", 3),
                 SqlParam.NVar("@fullName", fullName, 100),
                 SqlParam.Int("@code", code)
             );
        }

        public DataTable Get_Users_Data(int code)
        {
            return DAL.ExecQuery("SP_Get_Users_Data",
                 SqlParam.Byte("@grade_Id", Convert.ToByte(Globals.test_grade_id)),
                 SqlParam.NVar("@serach", "yes", 3),
                 SqlParam.NVar("@fullName", "", 100),
                 SqlParam.Int("@code", code)
             );
        }
        public DataTable Get_Users_Data(byte grade_Id)
        {
            return DAL.ExecQuery("SP_Get_Users_Data",
                            SqlParam.Byte("@grade_Id", grade_Id),
                            SqlParam.NVar("@serach", "no", 3),
                            SqlParam.NVar("@fullName", "", 100),
                            SqlParam.Int("@code", 0)
                        );

        }

        public void Update_User_Data(int Golos, string fullName, string firstName, string stdCode)
        {
            DAL.ExecNonQuery("SP_Update_User_Data",
                SqlParam.Int("@userSchoolId", Golos),
                SqlParam.NVar("@fullName", fullName, 255),
                SqlParam.NVar("@firstName", firstName, 255),
                SqlParam.NVar("@stdCode", stdCode, 50)
            );
        }

        public void Update_Student_Data(int Golos, byte grade_Id, byte class_Id, byte gender_Id, byte religion_Id, string stdCode)
        {
            DAL.ExecNonQuery("SP_Update_Student_Data",
                SqlParam.Int("@student_Id", Golos),
                SqlParam.Byte("@grade_Id", grade_Id),
                SqlParam.Byte("@class_Id", class_Id),
                SqlParam.Byte("@gender_Id", gender_Id),
                SqlParam.Byte("@religion_Id", religion_Id),
                SqlParam.NVar("@stdCode", stdCode, 50)
            );
        }

        public DataTable Get_User_Code(int Golos = 0)
        {
            return DAL.ExecQuery("SP_Get_User_Code",
                 SqlParam.Int("@Golos", Golos)
             );
        }

        public DataTable Verify_UserSchoolId(int userSchoolId)
        {
            return DAL.ExecQuery("SP_Verify_UserSchoolId",
                 SqlParam.Int("@userSchoolId", userSchoolId)
             );
        }
        public DataTable Verify_Username(string username)
        {
            return DAL.ExecQuery("SP_Verify_Username",
                 SqlParam.NVar("@username", username, 255)
             );
        }
        public DataTable Verify_Std_Degrees(int student_Id)
        {
            return DAL.ExecQuery("SP_Verify_Std_Degrees",
                 SqlParam.Int("@student_Id", student_Id)
             );
        }

        public DataTable Verify_Std_Marks(int student_Id)
        {
            return DAL.ExecQuery("SP_Verify_Std_Marks",
                 SqlParam.Int("@student_Id", student_Id)
             );
        }

        public void Add_User_Data(string username, string password, int roleId)
        {
            string first = char.ToUpper(username.First()) + username.Substring(1).ToLower();

            DAL.ExecNonQuery("SP_Add_User_Data",
                SqlParam.NVar("@username", username, 255),
                SqlParam.NVar("@password", password, 255),
                SqlParam.NVar("@firstName", first, 255),
                SqlParam.NVar("@fullName", "", 255),
                SqlParam.Int("@userSchoolId", 0),
                SqlParam.Int("@roleId", roleId),
                SqlParam.Int("@class_Id", 0),
                SqlParam.Int("@gender_Id", 0),
                SqlParam.Int("@religion_Id", 0),
                SqlParam.Int("@grade_Id", 0)
            );
        }

        public void Add_User_Data(string username, string password, string firstName, string fullName,
                                 int userSchoolId, int roleId, int class_Id, int gender_Id,
                                 int religion_Id, int grade_Id, string stdCode)
        {
            DAL.ExecNonQuery("SP_Add_User_Data",
                SqlParam.NVar("@username", username, 255),
                SqlParam.NVar("@password", password, 255),
                SqlParam.NVar("@firstName", firstName, 255),
                SqlParam.NVar("@fullName", fullName, 255),
                SqlParam.Int("@userSchoolId", userSchoolId),
                SqlParam.Int("@roleId", roleId),
                SqlParam.Int("@class_Id", class_Id),
                SqlParam.Int("@gender_Id", gender_Id),
                SqlParam.Int("@religion_Id", religion_Id),
                SqlParam.Int("@grade_Id", grade_Id),
                SqlParam.NVar("@stdCode", stdCode, 50)
            );
        }
        public void Update_User_stdCode(string stdCode, int Golos)
        {
            DAL.ExecNonQuery("SP_Update_User_stdCode",
                SqlParam.NVar("@stdCode", stdCode, 50),
                SqlParam.Int("@userSchoolId", Golos)
            );
        }
        public DataTable Get_User_Table_Data()
        {
            return DAL.Query("select * from students");
        }
        // =========================
        // LESSONS
        // =========================

        public void Update_User_2025(string username, string password, string firstName,
                                    string fullName, int roleId, string osraId, string note)
        {
            waiting.Wait();

            DAL.ExecNonQuery("SP_Add_User_2025",
                SqlParam.NVar("@username", username, 20),
                SqlParam.NVar("@password", password, 255),
                SqlParam.NVar("@firstName", firstName, 50),
                SqlParam.NVar("@fullName", fullName, 255),
                SqlParam.Int("@roleId", roleId),
                SqlParam.NVar("@osraId", osraId, 50),
                SqlParam.NVar("@note", note, 250)
            );

            waiting.End_WAit();
        }

        public void Update_Student_Data(int Student_Id, int Class_Id, int Gender_Id,
                                       int Religion_Id, int Grade_Id, string std_code,
                                       string Osraa_Id, string std_name, string full_name)
        {

            DAL.ExecNonQuery("SP_Add_Students_Data",
                SqlParam.Int("@Student_Id", Student_Id),
                SqlParam.Int("@Class_Id", Class_Id),
                SqlParam.Int("@Gender_Id", Gender_Id),
                SqlParam.Int("@Religion_Id", Religion_Id),
                SqlParam.Int("@Grade_Id", Grade_Id),
                SqlParam.NVar("@std_code", std_code, 50),
                SqlParam.NVar("@Osraa_Id", Osraa_Id, 50),
                SqlParam.NVar("@std_name", std_name, 50),
                SqlParam.NVar("@full_name", full_name, 255)
            );
        }

        public void Update_Topic_Data(int TopicId, string Title, string Description,
                                     int GradeId, int SubjectId, int TermId,
                                     short Lang, short TopicSortNo)
        {

            DAL.ExecNonQuery("SP_Lessons_Add_Topic",
                SqlParam.Int("@TopicId", TopicId),
                SqlParam.NVar("@Title", Title, 255),
                SqlParam.NVar("@Description", Description, 500),
                SqlParam.Int("@GradeId", GradeId),
                SqlParam.Int("@SubjectId", SubjectId),
                SqlParam.Int("@TermId", TermId),
                SqlParam.Byte("@Lang", (byte)Lang),
                SqlParam.Byte("@TopicSortNo", (byte)TopicSortNo)
            );

        }

        public void Update_Course_Data(int courseId, int topicId, string title,
                                      string description, string courseImg,
                                      short courseSortNo, int gradeId,
                                      int subjectId, int termId)
        {

            DAL.ExecNonQuery("SP_Lessons_Add_Course",
                SqlParam.Int("@courseId", courseId),
                SqlParam.Int("@topicId", topicId),
                SqlParam.NVar("@title", title, 255),
                SqlParam.NVar("@description", description, 1000),
                SqlParam.NVar("@courseImg", courseImg, 255),
                SqlParam.Byte("@courseSortNo", (byte)courseSortNo),
                SqlParam.Int("@gradeId", gradeId),
                SqlParam.Int("@subjectId", subjectId),
                SqlParam.Int("@termId", termId)
            );

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

            DAL.ExecNonQuery("SP_Lessons_Add_SubPart",
                SqlParam.Int("@courseId", courseId),
                SqlParam.NVar("@title", title, 255),
                SqlParam.NVar("@description", description, 1000),
                SqlParam.NVar("@subpartmg", subpartmg, 255),
                SqlParam.Byte("@sound", (byte)sound),
                SqlParam.Int("@gradeId", gradeId),
                SqlParam.Int("@subjectId", subjectId),
                SqlParam.Int("@termId", termId)
            );

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
            DAL.ExecNonQuery("SP_Lessons_Add_Vocabulary",
                SqlParam.Int("@courseId", courseId),
                SqlParam.NVar("@vocabulary", vocabulary, 50),
                SqlParam.NVar("@vocabularyText", vocabularyText, 100),
                SqlParam.Short("@vocabularyKind",vocabularyKind),
                SqlParam.Short("@sound", sound),
                SqlParam.Int("@gradeId", gradeId),
                SqlParam.Int("@subjectId", subjectId),
                SqlParam.Int("@termId", termId)
            );
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

            DAL.ExecNonQuery("SP_Lessons_Add_Review",
                SqlParam.Int("@courseId", courseId),
                SqlParam.NVar("@question", question, 255),
                SqlParam.NVar("@answer", answer, 255),
                SqlParam.NVar("@questionImg", questionImg, 255),
                SqlParam.Byte("@sound", (byte)sound),
                SqlParam.Int("@gradeId", gradeId),
                SqlParam.Int("@subjectId", subjectId),
                SqlParam.Int("@termId", termId)
            );
        }

        public void Update_Quiz_Data(int quizId,
                             string quizTitle,
                             int courseId,
                             string quizDescription,
                             int gradeId,
                             int subjectId,
                             int termId,
                             short sound,
                             short quizType)
        {
            DAL.ExecNonQuery("SP_Lessons_Add_Quiz",
                SqlParam.Int("@quizId", quizId),
                SqlParam.NVar("@quizTitle", quizTitle, 1000),
                SqlParam.Int("@courseId", courseId),
                SqlParam.NVar("@quizDescription", quizDescription, 1000),
                SqlParam.Int("@gradeId", gradeId),
                SqlParam.Int("@subjectId", subjectId),
                SqlParam.Int("@termId", termId),
                SqlParam.Short("@sound", sound),
                SqlParam.Short("@quizType", quizType)
            );
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
            DAL.ExecNonQuery("SP_Lessons_Add_Question",
                SqlParam.Int("@questionId", questionId),
                SqlParam.Int("@quizId", quizId),
                SqlParam.Int("@courseId", courseId),
                SqlParam.NVar("@questionText", questionText, 500),
                SqlParam.Short("@questionType", questionType),
                SqlParam.Int("@gradeId", gradeId),
                SqlParam.Int("@subjectId", subjectId),
                SqlParam.Int("@termId", termId),
                SqlParam.Short("@lang", lang)
            );
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

            DAL.ExecNonQuery("SP_Lessons_Add_Answer",
                SqlParam.Int("@courseId", courseId),
                SqlParam.Int("@quizId", quizId),
                SqlParam.Int("@questionId", questionId),
                SqlParam.NVar("@answerText", answerText, 500),
                SqlParam.Short("@isCorrect",isCorrect),
                SqlParam.Int("@gradeId", gradeId),
                SqlParam.Int("@subjectId", subjectId),
                SqlParam.Int("@termId", termId)
            );
        }


        // =========================
        // HELPERS
        // =========================

        public HashSet<TableKey> GetTableKeys()
        {
            var result = new HashSet<TableKey>();

            var dt = DAL.Query(@"
                SELECT course_id, grade_id, subject_id, term_id 
                FROM courses");

            foreach (DataRow row in dt.Rows)
            {
                if (row.IsNull(0) || row.IsNull(1) || row.IsNull(2) || row.IsNull(3))
                    continue;

                int k1 = Convert.ToInt32(row[0]);
                int k2 = Convert.ToInt32(row[1]);
                int k3 = Convert.ToInt32(row[2]);
                int k4 = Convert.ToInt32(row[3]);

                if (k1 <= 0 || k2 <= 0 || k3 <= 0 || k4 <= 0)
                    continue;

                result.Add(new TableKey(k1, k2, k3, k4));
            }

            return result;
        }

        public bool QuizExistsInContext(int c, int g, int s, int t, int q)
        {
            return DAL.Query(@"
                SELECT TOP 1 1 FROM quizzes
                WHERE course_id=@c AND grade_id=@g AND subject_id=@s AND term_id=@t AND quiz_id=@q",
                  SqlParam.Int("@c", c),
                  SqlParam.Int("@g", g),
                  SqlParam.Int("@s", s),
                  SqlParam.Int("@t", t),
                  SqlParam.Int("@q", q)
              ).Rows.Count > 0;
        }
        public bool QuestionHasAnswers(int c, int qz, int q, int g, int s, int t)
        {
            return DAL.Query(@"
                SELECT TOP 1 1 FROM answers
                WHERE course_id=@c AND quiz_id=@qz AND question_id=@q AND grade_id=@g AND subject_id=@s AND term_id=@t",
                 SqlParam.Int("@c", c),
                 SqlParam.Int("@qz", qz),
                 SqlParam.Int("@q", q),
                 SqlParam.Int("@g", g),
                 SqlParam.Int("@s", s),
                 SqlParam.Int("@t", t)
             ).Rows.Count > 0;
        }
        public bool QuestionExistsInContext(int c, int qz, int q, int g, int s, int t)
        {
            return DAL.Query(@"
                SELECT TOP 1 1 FROM questions
                WHERE course_id=@c AND quiz_id=@qz AND question_id=@q AND grade_id=@g AND subject_id=@s AND term_id=@t",
                 SqlParam.Int("@c", c),
                 SqlParam.Int("@qz", qz),
                 SqlParam.Int("@q", q),
                 SqlParam.Int("@g", g),
                 SqlParam.Int("@s", s),
                 SqlParam.Int("@t", t)
             ).Rows.Count > 0;
        }
    }

}
