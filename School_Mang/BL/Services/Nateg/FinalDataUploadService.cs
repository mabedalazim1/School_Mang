    using School_Mang.BL.NATEG;
    using School_Mang.BL.Common.Helper;
    using System;
    using System.Data;

    namespace School_Mang.BL.Services.Nateg
    {
        public class FinalDataUploadService
        {
            private readonly CLS_NATEG _nateg;
            private readonly ExcelImportService _excelImport;

            public FinalDataUploadService()
            {
                _nateg = new CLS_NATEG();
                _excelImport = new ExcelImportService();
            }

            public FinalDataUploadInfo GetUploadInfo(string filePath)
            {
                if (string.IsNullOrWhiteSpace(filePath))
                    return FinalDataUploadInfo.Failed("لم يتم تحديد الملف.");

                DataTable information = _excelImport.GetInformationData(filePath);

                if (information == null)
                    return FinalDataUploadInfo.Failed(
                        "تعذر قراءة بيانات الملف.");

                if (information.Columns.Count < 8 ||
                    information.Rows.Count == 0)
                    return FinalDataUploadInfo.Failed(
                        "بيانات الملف غير مكتملة.");

                DataRow row = information.Rows[0];

                string fileKind = row[0].ToString();

                if (string.IsNullOrWhiteSpace(fileKind))
                    return FinalDataUploadInfo.Failed(
                        "الملف غير صالح، يرجى التأكد من الملف المطلوب.");

                string fileData = row[7].ToString();

                if (string.IsNullOrWhiteSpace(fileData) || fileData == "0")
                    return FinalDataUploadInfo.Failed(
                        "يرجى التأكد من الدرجات.");

                byte testKind;
                byte testGrade;
                byte termId;

                if (!byte.TryParse(row[4].ToString(), out testKind) ||
                    !byte.TryParse(row[5].ToString(), out testGrade) ||
                    !byte.TryParse(row[6].ToString(), out termId))
                {
                    return FinalDataUploadInfo.Failed(
                        "بيانات نوع التقييم أو الصف أو الفصل الدراسي غير صالحة.");
                }

                return new FinalDataUploadInfo
                {
                    IsValid = true,
                    FileKind = fileKind,
                    FileDescription = row[1].ToString(),
                    GradeDescription = row[2].ToString(),
                    TermDescription = row[3].ToString(),
                    TestKind = testKind,
                    TestGrade = testGrade,
                    TermId = termId
                };
            }


            private void ValidateDegreeData(DataTable dtDegree, int expectedColumns)
            {
                if (dtDegree == null)
                    throw new InvalidOperationException(
                        "فشل قراءة درجات الملف، يرجى مراجعة محتويات ملف Excel.");

                if (dtDegree.Rows.Count == 0)
                    throw new InvalidOperationException(
                        "لا توجد درجات لرفعها في الملف المحدد.");

                if (dtDegree.Columns.Count < expectedColumns)
                    throw new InvalidOperationException(
                        "عدد أعمدة الدرجات في الملف غير مكتمل.");

            foreach (DataRow row in dtDegree.Rows)
            {
                int golos;

                if (row[0] == DBNull.Value ||
                    string.IsNullOrWhiteSpace(row[0].ToString()) ||
                    !int.TryParse(row[0].ToString(), out golos) ||
                    golos <= 0)
                {
                    throw new InvalidOperationException(
                        "رقم الجلوس غير صحيح أو فارغ في البيانات: [" +
                        (row[0] == DBNull.Value ? "فارغ" : row[0].ToString()) +
                        "]. يجب أن يكون رقمًا صحيحًا.");
                }

                row[0] = golos;
            }
        }

            public void UploadGrades(string filePath, FinalDataUploadInfo info)
            {
                if (info == null || !info.IsValid)
                    throw new ArgumentException("بيانات الملف غير صالحة.");

                if (info.TermId != 1 && info.TermId != 2)
                    throw new InvalidOperationException("الفصل الدراسي غير مدعوم.");

                byte year = Convert.ToByte(Properties.Settings.Default.year_cod);

                if (info.TestGrade == 10 || info.TestGrade == 11)
                    throw new InvalidOperationException("لا يمكن رفع درجات هذا الصف ..!");

                if (info.TestGrade >= 1 && info.TestGrade <= 3 &&
                    year <= 3)
                    throw new InvalidOperationException("لا يمكن رفع درجات هذا الصف ..!");

                DataTable dtDegree;

                if (info.TestKind == 1)
                {
                    switch (info.TestGrade)
                    {
                        case 1:
                        case 2:
                            dtDegree = _excelImport.Read_Amal_1_2(filePath);

                            ValidateDegreeData(dtDegree, 9);

                            foreach (DataRow row in dtDegree.Rows)
                            {
                                int golos = Convert.ToInt32(row[0]);

                                decimal[] marks = new decimal[8];
                                for (int i = 0; i < marks.Length; i++)
                                    marks[i] = Convert.ToDecimal(row[i + 1]);

                                if (info.TermId == 1)
                                    _nateg.Add_Amal_A_1_2(golos, marks[0], marks[1],
                                        marks[2], marks[3], marks[4], marks[5],
                                        marks[6], marks[7]);
                                else if (info.TermId == 2)
                                    _nateg.Add_Amal_B_1_2(golos, marks[0], marks[1],
                                        marks[2], marks[3], marks[4], marks[5],
                                        marks[6], marks[7]);
                            }
                            break;

                        case 3:
                            dtDegree = _excelImport.Read_Amal_3(filePath);

                            ValidateDegreeData(dtDegree, 7);

                            foreach (DataRow row in dtDegree.Rows)
                            {
                                int golos = Convert.ToInt32(row[0]);

                                decimal[] marks = new decimal[6];
                                for (int i = 0; i < marks.Length; i++)
                                    marks[i] = Convert.ToDecimal(row[i + 1]);

                                if (info.TermId == 1)
                                    _nateg.Add_Amal_A_3(golos, marks[0], marks[1],
                                        marks[2], marks[3], marks[4], marks[5]);
                                else if (info.TermId == 2)
                                    _nateg.Add_Amal_B_3(golos, marks[0], marks[1],
                                        marks[2], marks[3], marks[4], marks[5]);
                            }
                            break;

                        case 4:
                        case 5:
                        case 6:
                            dtDegree = _excelImport.Read_Amal_4_5_6(filePath);

                            ValidateDegreeData(dtDegree, 9);

                            foreach (DataRow row in dtDegree.Rows)
                            {
                                int golos = Convert.ToInt32(row[0]);

                                decimal[] marks = new decimal[8];
                                for (int i = 0; i < marks.Length; i++)
                                    marks[i] = Convert.ToDecimal(row[i + 1]);

                                if (info.TermId == 1)
                                    _nateg.Add_Amal_A_4_5_6(golos, marks[0], marks[1],
                                        marks[2], marks[3], marks[4], marks[5],
                                        marks[6], marks[7]);
                                else if (info.TermId == 2)
                                    _nateg.Add_Amal_B_4_5_6(golos, marks[0], marks[1],
                                        marks[2], marks[3], marks[4], marks[5],
                                        marks[6], marks[7]);
                            }
                            break;

                        case 7:
                        case 8:
                        case 9:
                            dtDegree = _excelImport.Read_Amal_7_8_9(filePath);

                            ValidateDegreeData(dtDegree, 13);

                            foreach (DataRow row in dtDegree.Rows)
                            {
                                int golos = Convert.ToInt32(row[0]);

                                decimal[] marks = new decimal[12];
                                for (int i = 0; i < marks.Length; i++)
                                    marks[i] = Convert.ToDecimal(row[i + 1]);

                                if (info.TermId == 1)
                                    _nateg.Add_Amal_A_7_8_9(golos, marks[0], marks[1],
                                        marks[2], marks[3], marks[4], marks[5],
                                        marks[6], marks[7], marks[8], marks[9],
                                        marks[10], marks[11]);
                                else if (info.TermId == 2)
                                    _nateg.Add_Amal_B_7_8_9(golos, marks[0], marks[1],
                                        marks[2], marks[3], marks[4], marks[5],
                                        marks[6], marks[7], marks[8], marks[9],
                                        marks[10], marks[11]);
                            }
                            break;

                        default:
                            throw new InvalidOperationException("الصف غير مدعوم.");
                    }
                }
                else if (info.TestKind == 2)
                {
                    if (info.TestGrade == 3)
                        dtDegree = _excelImport.Read_Test(filePath, 0);
                    else if (info.TestGrade >= 4 && info.TestGrade <= 6)
                        dtDegree = _excelImport.Read_Test(filePath);
                    else if (info.TestGrade >= 7 && info.TestGrade <= 9)
                        dtDegree = _excelImport.Read_Test(filePath, 2);
                    else
                        throw new InvalidOperationException("الصف غير مدعوم.");

                    ValidateDegreeData(dtDegree, 9);

                    foreach (DataRow row in dtDegree.Rows)
                    {
                        int golos = Convert.ToInt32(row[0]);

                        decimal[] marks = new decimal[8];
                        for (int i = 0; i < marks.Length; i++)
                            marks[i] = Convert.ToDecimal(row[i + 1]);

                        if (info.TermId == 1)
                            _nateg.Add_Test_A(golos, marks[0], marks[1], marks[2],
                                marks[3], marks[4], marks[5], marks[6], marks[7]);
                        else if (info.TermId == 2)
                            _nateg.Add_Test_B(golos, marks[0], marks[1], marks[2],
                                marks[3], marks[4], marks[5], marks[6], marks[7]);
                    }
                }
                else
                {
                    throw new InvalidOperationException("نوع التقييم غير مدعوم.");
                }
            }



        }


        public class FinalDataUploadInfo
        {
            public bool IsValid { get; set; }

            public string ErrorMessage { get; set; }

            public string FileKind { get; set; }

            public string FileDescription { get; set; }

            public string GradeDescription { get; set; }

            public string TermDescription { get; set; }

            public byte TestKind { get; set; }

            public byte TestGrade { get; set; }

            public byte TermId { get; set; }

            public static FinalDataUploadInfo Failed(string message)
            {
                return new FinalDataUploadInfo
                {
                    IsValid = false,
                    ErrorMessage = message
                };
            }
        }
    }
