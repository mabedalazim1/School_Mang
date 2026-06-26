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

        // ✅ نفس الدالة القديمة (بدون كسر)
        public ValidationResult ValidateExcel(
            string file,
            string type,
            ExcelColumn[] cols,
            string tableName)
        {
            return ValidateExcel(file, type, cols, tableName, null);
        }

        // ✅ النسخة الجديدة (Business Validation)
        public ValidationResult ValidateExcel(
            string file,
            string type,
            ExcelColumn[] cols,
            string tableName,
            Func<DataRow, string> businessValidator)
        {

            ValidationResult result = new ValidationResult();

            DataTable data = Read_Excel.ReadExcelData(
                file, cols, type, Mange_Site, null, null, null);

            if (data == null || data.Rows.Count == 0)
                return result;

            result.Data = data;

            LookupCache.Refresh(Mange_Site);

            List<string> errors;

            // 1- VALUES
            errors = ValidateValues(data, cols);
            if (errors.Count > 0)
                return Fail(result, errors);

            // 2-  KEYS
            if (!string.IsNullOrWhiteSpace(tableName))
            {
                errors = ValidateKeys(data, tableName);

                if (errors.Count > 0)
                    return Fail(result, errors);
            }

            // 3- BUSINESS 🔥
            if (businessValidator != null)
            {
                errors = ValidateBusiness(data, businessValidator);
                if (errors.Count > 0)
                    return Fail(result, errors);
            }

            return result;
        }

        private List<string> ValidateBusiness(DataTable data, Func<DataRow, string> validator)
        {
            List<string> errors = new List<string>();

            for (int i = 0; i < data.Rows.Count; i++)
            {
                var row = data.Rows[i];
                int rowNumber = 4 + i;

                var error = validator(row);

                if (!string.IsNullOrEmpty(error))
                {
                    errors.Add("❌ صف " + rowNumber + " - " + error);
                }
            }

            return errors;
        }

        private List<string> ValidateValues(DataTable data, ExcelColumn[] cols)
        {
            List<string> errors = new List<string>();

            for (int i = 0; i < data.Rows.Count; i++)
            {
                DataRow row = data.Rows[i];
                int rowNumber = 4 + i;

                for (int c = 0; c < cols.Length; c++)
                {
                    ExcelColumn col = cols[c];
                    object value = row[col.Name];

                    if (!col.AllowNull &&
                        (value == null || value == DBNull.Value || string.IsNullOrWhiteSpace(value.ToString())))
                    {
                        errors.Add("❌ صف " + rowNumber + " - [" + col.Name + "] قيمة فارغة");
                        continue;
                    }

                    if (value == null || value == DBNull.Value)
                        continue;

                    if (col.DataType == typeof(int))
                    {
                        int val;
                        if (!int.TryParse(value.ToString(), out val))
                        {
                            errors.Add("❌ صف " + rowNumber + " - [" + col.Name + "] قيمة غير صالحة");
                            continue;
                        }

                        ColumnRule rule;
                        if (ColumnRules.TryGetValue(col.Name, out rule))
                        {
                            if (rule.AllowedValues != null && !rule.AllowedValues.Contains(val))
                                errors.Add("❌ صف " + rowNumber + " - [" + col.Name + "] غير مسموح");

                            if (rule.Min.HasValue && val < rule.Min.Value)
                                errors.Add("❌ صف " + rowNumber + " - [" + col.Name + "] أقل من المسموح");

                            if (rule.Max.HasValue && val > rule.Max.Value)
                                errors.Add("❌ صف " + rowNumber + " - [" + col.Name + "] أكبر من المسموح");
                        }
                    }
                }
            }

            return errors;
        }

        private List<string> ValidateKeys(DataTable data, string tableName)
        {
            List<string> errors = new List<string>();

            if (string.IsNullOrWhiteSpace(tableName))
                return errors;

            for (int i = 0; i < data.Rows.Count; i++)
            {
                DataRow row = data.Rows[i];
                int rowNumber = 4 + i;

                int course = GetInt(row["course_id"]);
                int grade = GetInt(row["grade_id"]);
                int subject = GetInt(row["subject_id"]);
                int term = GetInt(row["term_id"]);

                if (course == 0 || grade == 0 || subject == 0 || term == 0)
                {
                    errors.Add("❌ صف " + rowNumber + " - بيانات الكورس غير مكتملة");
                    continue;
                }

                TableKey key = new TableKey(course, grade, subject, term);

                if (!LookupCache.IsValidCourse(key))
                {
                    errors.Add("❌ صف " + rowNumber + " - الكورس غير موجود");
                    continue;
                }

                if (tableName == "questions")
                {
                    int quizId = GetInt(row["quiz_id"]);

                    if (quizId == 0)
                    {
                        errors.Add("❌ صف " + rowNumber + " - quiz_id غير موجود");
                        continue;
                    }

                    if (!Mange_Site.QuizExistsInContext(course, grade, subject, term, quizId))
                    {
                        errors.Add("❌ صف " + rowNumber + " - الكويز غير موجود");
                    }
                }
                else if (tableName == "answers")
                {
                    int quizId = GetInt(row["quiz_id"]);
                    int questionId = GetInt(row["question_id"]);

                    if (quizId == 0 || questionId == 0)
                    {
                        errors.Add("❌ صف " + rowNumber + " - بيانات السؤال غير مكتملة");
                        continue;
                    }

                    if (!Mange_Site.QuestionExistsInContext(course, quizId, questionId, grade, subject, term))
                    {
                        errors.Add("❌ صف " + rowNumber + " - السؤال غير موجود");
                    }
                }
            }

            return errors;
        }

        private int GetInt(object value)
        {
            if (value == null || value == DBNull.Value)
                return 0;

            int r;
            return int.TryParse(value.ToString(), out r) ? r : 0;
        }

        private ValidationResult Fail(ValidationResult result, List<string> errors)
        {
            result.Errors.AddRange(errors);
            result.Errors.Add("⛔ تم إلغاء العملية بسبب وجود أخطاء");
            return result;
        }
    }
}