using School_Mang.BL.ExcelUtils;
using School_Mang.BL.SITE;
using System;
using System.Collections.Generic;
using System.Data;

namespace School_Mang.BL.ExcelUtils
{
    public class ExcelValidator
    {
        private readonly CLS_READ_EXCEL Read_Excel;
        private readonly CLS_MANGE_SITE Mange_Site;

        public ExcelValidator(CLS_READ_EXCEL r, CLS_MANGE_SITE m)
        {
            Read_Excel = r;
            Mange_Site = m;
        }

        // =========================
        public class ExcelValidationResult
        {
            public DataTable Data { get; set; }
            public List<string> Errors { get; set; } = new List<string>();
            public bool IsValid => Errors.Count == 0;
        }

        // =========================
        public class ColumnRule
        {
            public int? Min;
            public int? Max;
            public HashSet<int> AllowedValues;
        }

        private static readonly Dictionary<string, ColumnRule> ColumnRules =
            new Dictionary<string, ColumnRule>(StringComparer.OrdinalIgnoreCase)
            {
                { "grade_id", new ColumnRule { Min = 1, Max = 11 } },
                { "term_id", new ColumnRule { AllowedValues = new HashSet<int>{1,2} } },
                { "lang", new ColumnRule { AllowedValues = new HashSet<int>{0,1} } },
                { "sound", new ColumnRule { AllowedValues = new HashSet<int>{0,1} } },
            };

        // =========================
        private bool TryGetValue(object value, Type type, string col, int rowNumber, bool allowNull, List<string> errors, out object result)
        {
            result = null;

            if (value == null || value == DBNull.Value || string.IsNullOrWhiteSpace(value.ToString()))
            {
                if (allowNull)
                    return true;

                errors.Add($"❌ صف {rowNumber} - العمود [{col}] قيمة فارغة");
                return false;
            }

            try
            {
                if (type == typeof(int))
                    result = Convert.ToInt32(value);
                else if (type == typeof(string))
                    result = value.ToString().Trim();
                else
                    result = value;

                return true;
            }
            catch
            {
                errors.Add($"❌ صف {rowNumber} - العمود [{col}] قيمة غير صالحة [{value}]");
                return false;
            }
        }

        // =========================
        private bool ValidateColumnRule(string name, int value, int rowNumber, List<string> errors)
        {
            if (!ColumnRules.TryGetValue(name, out var rule))
                return true;

            if (value == 0 && rule.AllowedValues != null)
            {
                errors.Add($"❌ صف {rowNumber} - [{name}] قيمة غير صالحة");
                return false;
            }

            if (rule.AllowedValues != null && !rule.AllowedValues.Contains(value))
            {
                errors.Add($"❌ صف {rowNumber} - [{name}] قيمة غير مسموحة");
                return false;
            }

            if (rule.Min.HasValue && value < rule.Min.Value)
            {
                errors.Add($"❌ صف {rowNumber} - [{name}] أقل من المسموح");
                return false;
            }

            if (rule.Max.HasValue && value > rule.Max.Value)
            {
                errors.Add($"❌ صف {rowNumber} - [{name}] أكبر من المسموح");
                return false;
            }

            return true;
        }

        // =========================
        private bool ValidateKey(string tableName, DataRow row, int rowNumber, List<string> errors)
        {
            int course = row["course_id"] == DBNull.Value ? 0 : Convert.ToInt32(row["course_id"]);
            int grade = row["grade_id"] == DBNull.Value ? 0 : Convert.ToInt32(row["grade_id"]);
            int subject = row["subject_id"] == DBNull.Value ? 0 : Convert.ToInt32(row["subject_id"]);
            int term = row["term_id"] == DBNull.Value ? 0 : Convert.ToInt32(row["term_id"]);

            if (course == 0 || grade == 0 || subject == 0 || term == 0)
            {
                errors.Add($"❌ صف {rowNumber} - بيانات الكورس غير مكتملة");
                return false;
            }

            var key = new TableKey(course, grade, subject, term);

            // ✅ 1. تحقق من الكورس
            if (!LookupCache.IsValidCourse(key))
            {
                errors.Add($"❌ صف {rowNumber} - الكورس غير موجود");
                return false;
            }

            // ✅ 2. Questions
            if (tableName == "questions")
            {
                int quizId = row["quiz_id"] == DBNull.Value ? 0 : Convert.ToInt32(row["quiz_id"]);

                if (quizId == 0)
                {
                    errors.Add($"❌ صف {rowNumber} - quiz_id غير موجود");
                    return false;
                }

                if (!Mange_Site.QuizExistsInContext(course, grade, subject, term, quizId))
                {
                    errors.Add($"❌ صف {rowNumber} - الكويز غير موجود");
                    return false;
                }
            }

            // ✅ 3. Answers
            if (tableName == "answers")
            {
                int quizId = row["quiz_id"] == DBNull.Value ? 0 : Convert.ToInt32(row["quiz_id"]);
                int questionId = row["question_id"] == DBNull.Value ? 0 : Convert.ToInt32(row["question_id"]);

                if (quizId == 0 || questionId == 0)
                {
                    errors.Add($"❌ صف {rowNumber} - بيانات السؤال غير مكتملة");
                    return false;
                }

                if (!Mange_Site.QuestionExistsInContext(course, quizId, questionId, grade, subject, term))
                {
                    errors.Add($"❌ صف {rowNumber} - السؤال غير موجود");
                    return false;
                }
            }

            return true;
        }

        // =========================
        public ExcelValidationResult ValidateExcel(
            string file,
            string type,
            ExcelColumn[] cols,
            Action<string> showError,
            string tableName)
        {
            var result = new ExcelValidationResult();

            try
            {
                LookupCache.Load(Mange_Site);

                var data = Read_Excel.ReadExcelData(
                    file, cols, type, Mange_Site, showError, null, null);

                if (data == null || data.Rows.Count == 0)
                    return result;

                result.Data = data;

                for (int i = 0; i < data.Rows.Count; i++)
                {
                    var row = data.Rows[i];
                    int rowNumber = 4 + i;

                    bool rowValid = true;

                    foreach (var col in cols)
                    {
                        if (!TryGetValue(
                                row[col.Name],
                                col.DataType,
                                col.Name,
                                rowNumber,
                                col.AllowNull,
                                result.Errors,
                                out object valueObj))
                        {
                            rowValid = false;
                            continue;
                        }

                        if (valueObj != null && col.DataType == typeof(int))
                        {
                            if (!ValidateColumnRule(col.Name, Convert.ToInt32(valueObj), rowNumber, result.Errors))
                                rowValid = false;
                        }

                        row[col.Name] = valueObj ?? DBNull.Value;
                    }

                    if (!rowValid)
                        continue;

                    if (!ValidateKey(tableName, row, rowNumber, result.Errors))
                        continue;
                }

                if (result.Errors.Count > 0)
                    result.Errors.Add("⛔ تم إلغاء العملية");
            }
            catch (Exception ex)
            {
                result.Errors.Add("❌ System Error: " + ex.Message);
            }

            return result;
        }
    }
}