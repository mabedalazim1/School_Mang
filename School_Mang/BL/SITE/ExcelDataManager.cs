using School_Mang.BL.ExcelUtils;
using System;
using System.Collections.Generic;
using System.Data;
using School_Mang.BL.Common.Extensions;
using System.Linq;

namespace School_Mang.BL.SITE
{
    public class ExcelDataManager
    {
        private readonly CLS_READ_EXCEL Read_Excel;
        private readonly CLS_MANGE_SITE Mange_Site;
        private readonly ExcelValidator Validator;

        public ExcelDataManager(CLS_READ_EXCEL readExcel, CLS_MANGE_SITE mangeSite)
        {
            Read_Excel = readExcel;
            Mange_Site = mangeSite;
            Validator = new ExcelValidator(readExcel, mangeSite);
        }

        public class ImportResult
        {
            public bool Success { get; set; }
            public List<string> Errors { get; set; } = new List<string>();
            public int ProcessedRows { get; set; }
            public DataTable Data { get; set; }
        }

        public class AnswerModel
        {
            public string Text { get; set; }
            public byte IsCorrect { get; set; }
        }

          
        private ImportResult ImportData(
            string file,
            string type,
            ExcelColumn[] columns,
            Action<DataRow> handler,
            Action<string> showError,
            Action start,
            Action end,
            string table)
        {
            var result = new ImportResult();

            start?.Invoke();

            try
            {
                var validation = Validator.ValidateExcel(file, type, columns, table);

                if (validation == null)
                {
                    result.Errors.Add("❌ Validation returned null");
                    return result;
                }

                if (validation.Errors != null && validation.Errors.Count > 0)
                {
                    result.Errors.AddRange(validation.Errors);
                    result.Errors.Add("⛔ تم إيقاف الحفظ بسبب وجود أخطاء في الملف");
                    return result;
                }

                if (validation.Data == null || validation.Data.Rows.Count == 0)
                {
                    result.Errors.Add("❌ No data found in Excel");
                    return result;
                }

                result.Data = validation.Data;

                try
                {
                    Mange_Site.RunInTransaction(() =>
                    {
                        foreach (DataRow row in validation.Data.Rows)
                        {
                            handler(row);
                            result.ProcessedRows++;
                        }
                    });

                    result.Success = true;
                }
                catch (Exception ex)
                {
                    int rowIndex = result.ProcessedRows + 1;
                    result.Errors.Add($"❌ فشل الحفظ عند الصف {rowIndex}: {ex.Message}");
                }

                try
                {
                    if (!string.IsNullOrWhiteSpace(table))
                        LookupCache.Refresh(Mange_Site);
                }
                catch (Exception ex)
                {
                    result.Errors.Add("⚠️ Cache error: " + ex.Message);
                }
            }
            catch (Exception ex)
            {
                result.Errors.Add(ex.Message);
            }
            finally
            {
                end?.Invoke();
            }

            return result;
        }

        // ========================= COLUMN FACTORY HELPERS
        private static ExcelColumn Col(string name, Type type, int index, bool allowNull = false)
            => new ExcelColumn { Name = name, DataType = type, Index = index, AllowNull = allowNull };


        // استيراد الموضوعات
        public ImportResult ImportTopics(string excelFile,
                                         string fileType,
                                         Action<string> showError,
                                         Action waitStart,
                                         Action waitEnd,
                                         string tableName)
        {
            var columns = new ExcelColumn[]
            {
        new ExcelColumn { Name = "topic_id", DataType = typeof(int), Index = 1 },
        new ExcelColumn { Name = "title", DataType = typeof(string), Index = 2 },
        new ExcelColumn { Name = "description", DataType = typeof(string), Index = 3 ,AllowNull =true, AllowWhitespace= true },
        new ExcelColumn { Name = "grade_id", DataType = typeof(int), Index = 4 },
        new ExcelColumn { Name = "subject_id", DataType = typeof(int), Index = 5 },
        new ExcelColumn { Name = "term_id", DataType = typeof(int), Index = 6 },
        new ExcelColumn { Name = "lang", DataType = typeof(short), Index = 7  },
        new ExcelColumn { Name = "topic_sort_no", DataType = typeof(short), Index = 8 ,AllowNull =true, AllowWhitespace= true},
            };

            return ImportData(excelFile, fileType, columns,
                row => Mange_Site.Update_Topic_Data(
                    row.GetInt("topic_id"),
                    row.GetString("title"),
                    row.GetString("description", true) ?? "",
                    row.GetInt("grade_id"),
                    row.GetInt("subject_id"),
                    row.GetInt("term_id"),
                    row.GetShort("lang"),
                    row.GetShort("topic_sort_no")
                ),
                showError, waitStart, waitEnd, tableName
            );
        }

        // استيراد الدروس
        public ImportResult ImportCourses(string excelFile,
                                         string fileType,
                                         Action<string> showError,
                                         Action waitStart,
                                         Action waitEnd,
                                         string tableName)
        {
            var columns = new ExcelColumn[]
            {
        new ExcelColumn { Name = "course_id", DataType = typeof(int), Index = 1 },
        new ExcelColumn { Name = "topic_id", DataType = typeof(int), Index = 2 },
        new ExcelColumn { Name = "title", DataType = typeof(string), Index = 3 },
        new ExcelColumn { Name = "description", DataType = typeof(string), Index = 4 ,AllowNull =true, AllowWhitespace= true },
        new ExcelColumn { Name = "course_img", DataType = typeof(string), Index = 8 ,AllowNull =true, AllowWhitespace= true},
        new ExcelColumn { Name = "course_sort_no", DataType = typeof(int), Index = 9  ,AllowNull =true, AllowWhitespace= true},
        new ExcelColumn { Name = "grade_id", DataType = typeof(int), Index = 5 },
        new ExcelColumn { Name = "subject_id", DataType = typeof(int), Index = 6 },
        new ExcelColumn { Name = "term_id", DataType = typeof(int), Index = 7 },
            };

            return ImportData(excelFile, fileType, columns,
                row => Mange_Site.Update_Course_Data(
                    row.GetInt("course_id"),
                    row.GetInt("topic_id"),
                    row.GetString("title"),
                    row.GetString("description",true) ?? "",
                    row.GetString("course_img",true) ?? "",
                    row.GetShort("course_sort_no"),
                    row.GetInt("grade_id"),
                    row.GetInt("subject_id"),
                    row.GetInt("term_id")
                ),
                showError, waitStart, waitEnd, tableName
            );
        }

        // استيرادالموضوعات الفرعية
        public ImportResult ImportSubParts(string excelFile,
                                         string fileType,
                                         Action<string> showError,
                                         Action waitStart,
                                         Action waitEnd,
                                         string tableName)
        {
            var columns = new ExcelColumn[]
            {
        new ExcelColumn { Name = "course_id", DataType = typeof(int), Index = 1 },
        new ExcelColumn { Name = "title", DataType = typeof(string), Index = 2 },
        new ExcelColumn { Name = "description", DataType = typeof(string), Index = 3 ,AllowNull =true, AllowWhitespace= true},
        new ExcelColumn { Name = "subpart_img", DataType = typeof(string), Index = 7,AllowNull =true, AllowWhitespace= true },
        new ExcelColumn { Name = "sound", DataType = typeof(int), Index = 8 },
        new ExcelColumn { Name = "grade_id", DataType = typeof(int), Index = 4 },
        new ExcelColumn { Name = "subject_id", DataType = typeof(int), Index = 5 },
        new ExcelColumn { Name = "term_id", DataType = typeof(int), Index = 6 },
            };

            return ImportData(excelFile, fileType, columns,
                row => Mange_Site.Update_SubPart_Data(
                    row.GetInt("course_id"),
                    row.GetString("title"),
                    row.GetString("description", true) ?? "",
                    row.GetString("subpart_img", true) ?? "",
                    row.GetShort("sound"),
                    row.GetInt("grade_id"),
                    row.GetInt("subject_id"),
                    row.GetInt("term_id")
                ),
                showError, waitStart, waitEnd, tableName
            );
        }
        // استيراد المفردات
        public ImportResult ImportVocabularies(string excelFile,
                                         string fileType,
                                         Action<string> showError,
                                         Action waitStart,
                                         Action waitEnd,
                                         string tableName)
        {
            var columns = new ExcelColumn[]
            {
        new ExcelColumn { Name = "course_id", DataType = typeof(int), Index = 1 },
        new ExcelColumn { Name = "vocabulary", DataType = typeof(string), Index = 2 },
        new ExcelColumn { Name = "vocabulary_text", DataType = typeof(string), Index = 3 },
        new ExcelColumn { Name = "vocabulary_kind", DataType = typeof(string), Index = 4 },
        new ExcelColumn { Name = "sound", DataType = typeof(int), Index = 8 ,AllowNull =true, AllowWhitespace= true},
        new ExcelColumn { Name = "grade_id", DataType = typeof(int), Index = 5 },
        new ExcelColumn { Name = "subject_id", DataType = typeof(int), Index = 6 },
        new ExcelColumn { Name = "term_id", DataType = typeof(int), Index = 7 },
            };

            return ImportData(excelFile, fileType, columns,
                row => Mange_Site.Update_Vocabulary_Data(
                    row.GetInt("course_id"),
                    row.GetString("vocabulary"),
                    row.GetString("vocabulary_text"),
                    row.GetShort("vocabulary_kind"),
                    row.GetShort("sound"),
                    row.GetInt("grade_id"),
                    row.GetInt("subject_id"),
                    row.GetInt("term_id")
                ),
                showError, waitStart, waitEnd, tableName
            );
        }

        // استيراد الأسئلة المجابة
        public ImportResult ImportReviews(string excelFile,
                                         string fileType,
                                         Action<string> showError,
                                         Action waitStart,
                                         Action waitEnd,
                                         string tableName)
        {
            var columns = new ExcelColumn[]
            {
        new ExcelColumn { Name = "course_id", DataType = typeof(int), Index = 1 },
        new ExcelColumn { Name = "question", DataType = typeof(string), Index = 2 },
        new ExcelColumn { Name = "answer", DataType = typeof(string), Index = 3 },
        new ExcelColumn { Name = "question_img", DataType = typeof(string), Index = 7,AllowNull =true, AllowWhitespace= true },
        new ExcelColumn { Name = "sound", DataType = typeof(int), Index = 8 ,AllowNull =true, AllowWhitespace= true},
        new ExcelColumn { Name = "grade_id", DataType = typeof(int), Index = 4 },
        new ExcelColumn { Name = "subject_id", DataType = typeof(int), Index = 5 },
        new ExcelColumn { Name = "term_id", DataType = typeof(int), Index = 6 },
            };

            return ImportData(excelFile, fileType, columns,
                row => Mange_Site.Update_Review_Data(
                    row.GetInt("course_id"),
                    row.GetString("question"),
                    row.GetString("answer"),
                    row.GetString("question_img", true) ?? "",
                    row.GetShort("sound"),
                    row.GetInt("grade_id"),
                    row.GetInt("subject_id"),
                    row.GetInt("term_id")
                ),
                showError, waitStart, waitEnd, tableName
            );
        }
        // استيراد الإختبارات
        public ImportResult ImportQuizes(string excelFile,
                                         string fileType,
                                         Action<string> showError,
                                         Action waitStart,
                                         Action waitEnd,
                                         string tableName)
        {
            var columns = new ExcelColumn[]
            {
        new ExcelColumn { Name = "quiz_id", DataType = typeof(int), Index = 3 },
        new ExcelColumn { Name = "course_id", DataType = typeof(int), Index = 2 },
        new ExcelColumn { Name = "quiz_title", DataType = typeof(string), Index = 1 },
        new ExcelColumn { Name = "quiz_description", DataType = typeof(string), Index = 4 ,AllowNull =true, AllowWhitespace= true},
        new ExcelColumn { Name = "quizType", DataType = typeof(short), Index = 5 },
        new ExcelColumn { Name = "sound", DataType = typeof(short), Index = 9 ,AllowNull =true, AllowWhitespace= true},
        new ExcelColumn { Name = "grade_id", DataType = typeof(int), Index = 6 },
        new ExcelColumn { Name = "subject_id", DataType = typeof(int), Index = 7 },
        new ExcelColumn { Name = "term_id", DataType = typeof(int), Index = 8 }
            };

            return ImportData(excelFile, fileType, columns,
                row => Mange_Site.Update_Quiz_Data(
                    row.GetInt("quiz_id"),
                    row.GetString("quiz_title"),
                    row.GetInt("course_id"),
                    row.GetString("quiz_description", true) ?? "",
                    row.GetInt("grade_id"),
                    row.GetInt("subject_id"),
                    row.GetInt("term_id"),
                    row.GetShort("sound"),
                    row.GetShort("quizType")
                ),
                showError, waitStart, waitEnd,tableName
            );
        }
        // استيراد الأسئلة
        public ImportResult ImportQuestions(string excelFile,
                                    string fileType,
                                    Action<string> showError,
                                    Action waitStart,
                                    Action waitEnd,
                                    string tableName)
        {
            var columns = new ExcelColumn[]
            {
                new ExcelColumn { Name = "question_id", DataType = typeof(int), Index = 3 },
                new ExcelColumn { Name = "quiz_id", DataType = typeof(int), Index = 2 },
                new ExcelColumn { Name = "course_id", DataType = typeof(int), Index = 1 },
                new ExcelColumn { Name = "question_text", DataType = typeof(string), Index = 4 },
                new ExcelColumn { Name = "question_type", DataType = typeof(byte), Index = 5 },
                new ExcelColumn { Name = "grade_id", DataType = typeof(int), Index = 6 },
                new ExcelColumn { Name = "subject_id", DataType = typeof(int), Index = 7 },
                new ExcelColumn { Name = "term_id", DataType = typeof(int), Index = 8 },
                new ExcelColumn { Name = "lang", DataType = typeof(short), Index = 9 }
            };

            return ImportData(excelFile, fileType, columns,
                row => Mange_Site.Update_Question_Data(
                    row.GetInt("question_id"),
                    row.GetInt("quiz_id"),
                    row.GetInt("course_id"),
                    row.GetString("question_text"),
                    row.GetShort("question_type"),
                    row.GetInt("grade_id"),
                    row.GetInt("subject_id"),
                    row.GetInt("term_id"),
                    row.GetShort("lang")
                ),
                showError, waitStart, waitEnd, tableName
            );
        }

        // استيراد الإجابات
        public ImportResult ImportAnswers(string excelFile,
                                          string fileType,
                                          Action<string> showError,
                                          Action waitStart,
                                          Action waitEnd,
                                          string tableName)
        {
            var columns = new ExcelColumn[]
            {
                new ExcelColumn { Name = "course_id", DataType = typeof(int), Index = 1 },
                new ExcelColumn { Name = "quiz_id", DataType = typeof(int), Index = 2 },
                new ExcelColumn { Name = "question_id", DataType = typeof(int), Index = 3 },
                new ExcelColumn { Name = "answer_text", DataType = typeof(string), Index = 4 },
                new ExcelColumn { Name = "is_correct", DataType = typeof(byte), Index = 5 },
                new ExcelColumn { Name = "grade_id", DataType = typeof(int), Index = 6 },
                new ExcelColumn { Name = "subject_id", DataType = typeof(int), Index = 7 },
                new ExcelColumn { Name = "term_id", DataType = typeof(int), Index = 8 }
            };

            return ImportData(excelFile, fileType, columns,
                row => Mange_Site.Update_Answer_Data(
                    row.GetInt("course_id"),
                    row.GetInt("quiz_id"),
                    row.GetInt("question_id"),
                    row.GetString("answer_text"),
                    row.GetByte("is_correct"),
                    row.GetInt("grade_id"),
                    row.GetInt("subject_id"),
                    row.GetInt("term_id")
                ),
                showError, waitStart, waitEnd, tableName
            );
        }
        // استيراد الأسئلة بالإجابات
        public ImportResult ImportQuestionsWithAnswers(
                                                     string excelFile,
                                                     string fileType,
                                                     Action<string> showError,
                                                     Action waitStart,
                                                     Action waitEnd,
                                                     string tableName)
        {
            var columns = new ExcelColumn[]
            {
        new ExcelColumn { Name = "course_id", DataType = typeof(int), Index = 1 },
        new ExcelColumn { Name = "grade_id", DataType = typeof(int), Index = 2 },
        new ExcelColumn { Name = "subject_id", DataType = typeof(int), Index = 3 },
        new ExcelColumn { Name = "term_id", DataType = typeof(int), Index = 4 },
        new ExcelColumn { Name = "lang", DataType = typeof(short), Index = 5 },
        new ExcelColumn { Name = "quiz_id", DataType = typeof(int), Index = 6 },

        new ExcelColumn { Name = "question_id", DataType = typeof(int), Index = 7 },
        new ExcelColumn { Name = "question_text", DataType = typeof(string), Index = 8 },
        new ExcelColumn { Name = "question_type", DataType = typeof(short), Index = 9 },

        new ExcelColumn { Name = "a1", DataType = typeof(string), Index = 10, AllowNull = true },
        new ExcelColumn { Name = "t1", DataType = typeof(byte), Index = 21, AllowNull = true },

        new ExcelColumn { Name = "a2", DataType = typeof(string), Index = 12, AllowNull = true },
        new ExcelColumn { Name = "t2", DataType = typeof(byte), Index = 22, AllowNull = true },

        new ExcelColumn { Name = "a3", DataType = typeof(string), Index = 14, AllowNull = true },
        new ExcelColumn { Name = "t3", DataType = typeof(byte), Index = 23, AllowNull = true },

        new ExcelColumn { Name = "a4", DataType = typeof(string), Index = 16, AllowNull = true },
        new ExcelColumn { Name = "t4", DataType = typeof(byte), Index = 24, AllowNull = true },
            };

            waitStart?.Invoke();

            try
            {
                var validation = Validator.ValidateExcel(
                    excelFile,
                    fileType,
                    columns,
                    tableName,
                    row =>
                    {
                        var answers = new List<AnswerModel>();

                        AddAnswer(answers, row, "a1", "t1");
                        AddAnswer(answers, row, "a2", "t2");
                        AddAnswer(answers, row, "a3", "t3");
                        AddAnswer(answers, row, "a4", "t4");

                        if (!answers.Any())
                            return $"السؤال {row.GetInt("question_id")} لا يحتوي على إجابات";

                        if (!answers.Any(a => a.IsCorrect == 1))
                            return $"السؤال {row.GetInt("question_id")} يجب أن يحتوي على إجابة صحيحة";

                        if (Mange_Site.QuestionHasAnswers(
                            row.GetInt("course_id"),
                            row.GetInt("quiz_id"),
                            row.GetInt("question_id"),
                            row.GetInt("grade_id"),
                            row.GetInt("subject_id"),
                            row.GetInt("term_id")))
                        {
                            return $"السؤال {row.GetInt("question_id")} له إجابات بالفعل";
                        }

                        return null;
                    });

                // =========================
                // COLLECT ALL ERRORS
                // =========================
                var errors = new List<string>();

                if (validation == null)
                {
                    errors.Add("❌ Validation returned null");
                }
                else
                {
                    if (validation.Errors != null && validation.Errors.Count > 0)
                        errors.AddRange(validation.Errors);

                    if (validation.Data != null)
                    {
                        var duplicates = validation.Data
                            .AsEnumerable()
                            .GroupBy(r => new
                            {
                                CourseId = Convert.ToInt32(r["course_id"]),
                                QuizId = Convert.ToInt32(r["quiz_id"]),
                                QuestionId = Convert.ToInt32(r["question_id"])
                            })
                            .Where(g => g.Count() > 1)
                            .ToList();

                        if (duplicates.Any())
                        {
                            errors.AddRange(duplicates.Select(d =>
                                $"❌ تكرار السؤال {d.Key.QuestionId} داخل الكويز {d.Key.QuizId} (الكورس {d.Key.CourseId})"));
                        }
                    }
                    else
                    {
                        errors.Add("❌ No data found in Excel");
                    }
                }

                // =========================
                // STOP IF ERRORS EXIST
                // =========================
                if (errors.Any())
                {
                    return new ImportResult
                    {
                        Success = false,
                        Errors = errors
                    };
                }

                // =========================
                // SAVE
                // =========================
                return ImportData(
                    excelFile,
                    fileType,
                    columns,
                    row =>
                    {
                        int courseId = row.GetInt("course_id");
                        int quizId = row.GetInt("quiz_id");
                        int questionId = row.GetInt("question_id");
                        int gradeId = row.GetInt("grade_id");
                        int subjectId = row.GetInt("subject_id");
                        int termId = row.GetInt("term_id");

                        if (questionId <= 0)
                            return;

                        Mange_Site.Update_Question_Data(
                            questionId,
                            quizId,
                            courseId,
                            row.GetString("question_text"),
                            row.GetShort("question_type"),
                            gradeId,
                            subjectId,
                            termId,
                            row.GetShort("lang")
                        );

                        var answers = new List<AnswerModel>();

                        AddAnswer(answers, row, "a1", "t1");
                        AddAnswer(answers, row, "a2", "t2");
                        AddAnswer(answers, row, "a3", "t3");
                        AddAnswer(answers, row, "a4", "t4");

                        foreach (var ans in answers)
                        {
                            if (string.IsNullOrWhiteSpace(ans.Text))
                                continue;

                            Mange_Site.Update_Answer_Data(
                                courseId,
                                quizId,
                                questionId,
                                ans.Text,
                                ans.IsCorrect,
                                gradeId,
                                subjectId,
                                termId
                            );
                        }
                    },
                    showError,
                    waitStart,
                    waitEnd,
                    tableName
                );
            }
            finally
            {
                waitEnd?.Invoke();
            }
        }

        private void AddAnswer(List<AnswerModel> list, DataRow row, string aCol, string tCol)
        {
            string text = row[aCol]?.ToString();

            if (string.IsNullOrWhiteSpace(text))
                return;

            byte isCorrect = 0;

            var val = row[tCol];
            byte.TryParse(val?.ToString(), out isCorrect);

            list.Add(new AnswerModel
            {
                Text = text,
                IsCorrect = isCorrect
            });
        }
    }
}