using School_Mang.BL;
using School_Mang.BL.Common.Helper;
using School_Mang.BL.SITE;
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;


namespace School_Mang.PL.SITE
{
    public partial class FRM_EDIT_DATA : Form
    {
        SiteExcelUtlity Excel = new SiteExcelUtlity();
        BL.NATEG.cls_NATAG_FUNCTIONS natag_func = new BL.NATEG.cls_NATAG_FUNCTIONS();
        CLS_MANGE_SITE Mange_Site = new CLS_MANGE_SITE();
        CLS_READ_EXCEL Read_Excel = new CLS_READ_EXCEL();
        private readonly ExcelDataManager _manager;
        private readonly ExcelExportService _exportService;


        private readonly byte _type;
        private string excel_file_name;

        private Action<string> _error;
        private Action _start;
        private Action _end;

        public FRM_EDIT_DATA(string title, byte type)
        {
            InitializeComponent();

            lbl_title.Text = title;
            _type = type;

            _exportService = new ExcelExportService();
            _manager = new ExcelDataManager(Read_Excel, Mange_Site);
            _error = MSG.ErrorMesg;
            _start = Waiting.Start;
            _end = Waiting.Stop;
        }

        private void HandleImportResult(ImportResult result)
        {
            if (result == null)
            {
                _error("حدث خطأ غير متوقع");
                return;
            }

            if (!result.Success)
            {
                foreach (var err in result.Errors)
                    _error(err);
                return;
            }

            MSG.MyMesg($"تم بنجاح ✅ عدد الصفوف: {result.ProcessedRows}");
        }

        private void Save_Data_TO_Excel(string worksheetName)
        {
            var info = _exportService.GetExportInfo(worksheetName, _type);
            string saveAsLocation;

            Directory.CreateDirectory(info.DefaultFolder);

            folderBrowserDialog1.SelectedPath = info.DefaultFolder;

            // Show the FolderBrowserDialog.  
            DialogResult result = folderBrowserDialog1.ShowDialog();

            if (result != DialogResult.OK)
            {
                MSG.ErrorMesg("يرجى اختيار مسار الحفظ .. !");
                return;
            }

            saveAsLocation = Path.Combine(folderBrowserDialog1.SelectedPath,
                                          info.FileName);

            if (File.Exists(saveAsLocation))
            {
                if (MSG.DialogeErrMsg("الصف المحدد تم تصديره سابقاً .. سوف يتم حذف الملف  .. هل تريد المتابعة ؟") == DialogResult.No)
                {
                    MSG.ErrorMesg("تم إلغاء الإجراء ..!");
                    return;
                }
            }

            Waiting.Start();

            try
            {

                if (_exportService.Export(worksheetName, saveAsLocation, info))
                {
                    MSG.MyMesg("تم إعداد الملف بنجاح !");
                    MSG.MyMesg(saveAsLocation + "  مسار الملف هو  ");
                }
            }
            catch (Exception ex)
            {
                MSG.ErrorMesg(ex.Message);
            }
            finally
            {
                Waiting.Stop();
            }
        }
        private async void ReadData()
        {
            if (!await InternetFlow.EnsureAsync())
                return;

            try
            {
                excel_file_name = natag_func.OpenDialoge(openFileDialog1);

                if (excel_file_name == null)
                {
                    MSG.ErrorMesg("تم إلغاء الإجراء..!");
                    Globals.Dir_Path = "D://Lessons";
                    return;
                }

                switch (_type)
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
                MSG.ErrorMesg(e.Message);
            }

        }


        private void ReadStudents()
        {

            DataTable data = Excel.ReadStudentsDataFromExcel(excel_file_name);

            if (data == null)
            {
                _error("لا توجد بيانات..!");
                Globals.Dir_Path = "D://Users";
                return;
            }

            var result = _manager.ImportStudents(
                excel_file_name,
                _error,
                _start,
                _end
            );

            HandleImportResult(result);
        }

        private void ReadUsers()
        {
            DataTable data = Excel.ReadUsersDataFromExcel(excel_file_name);

            if (data == null)
            {
                _error("لا توجد بيانات..!");
                Globals.Dir_Path = "D://Users";
                return;
            }
            var result = _manager.ImportUsers(
                excel_file_name,
                _error,
                _start,
                _end
            );

            HandleImportResult(result);
        }

        private void ReadTopic()
        {
            var result = _manager.ImportTopics(
                excel_file_name,
                "topic",
                _error,
                _start,
                _end,
                null
            );

            HandleImportResult(result);
        }

        private void ReadCourse()
        {
            var result = _manager.ImportCourses(
                excel_file_name,
                "course",
                _error,
                _start,
                _end,
                null
            );

            HandleImportResult(result);
        }


        private void ReadSubPart()
        {
            var result = _manager.ImportSubParts(
                excel_file_name,
                "subpart",
               _error,
                _start,
                _end,
                "subparts"
            );

            HandleImportResult(result);
        }

        private void ReadVocabulary()
        {
            var result = _manager.ImportVocabularies(
                excel_file_name,
                "vocabulary",
               _error,
                _start,
                _end,
                "vocabularies"
            );

            HandleImportResult(result);
        }

        private void ReadReview()
        {
            var result = _manager.ImportReviews(
                excel_file_name,
                "review",
               _error,
                _start,
                _end,
                "reviews"
            );

            HandleImportResult(result);
        }

        private void ReadQuiz()
        {
            var result = _manager.ImportQuizes(
                excel_file_name,
                "quiz",
                _error,
                _start,
                _end,
                "quizzes"
            );

            HandleImportResult(result);
        }

        private void ReadQuestion()
        {
            var result = _manager.ImportQuestions(
            excel_file_name,
            "question",
            _error,
            _start,
            _end,
            "questions");


            HandleImportResult(result);
        }

        private void ReadAnswer()
        {
            var result = _manager.ImportAnswers(
            excel_file_name,
            "answer",
            _error,
            _start,
            _end,
            "answers");

            HandleImportResult(result);
        }

        private void ReadQusestionsByAnswer()
        {
            var result = _manager.ImportQuestionsWithAnswers(
            excel_file_name,
            "mlutiquestion",
            _error,
            _start,
            _end,
            "questions");

            HandleImportResult(result);
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
            switch (_type)
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
            if (_type == 3)
            {
                MSG.MyExclamationMsg("تحديث الفقرات يعتمد على عنوان الفقرة ..!");
            }
            if (_type == 4)
            {
                MSG.MyExclamationMsg("تحديث الفقرات يعتمد على المفردة  ..!");
                MSG.MyExclamationMsg("في حالة تغيير المفردة سيتم إضافة مفردة جديدة ..!");
            }
            if (_type == 8)
            {
                MSG.MyExclamationMsg("سوف يتم إضافة جميع الإجابات ..!");
                if (MSG.DialogeErrMsg("هل تريد إضافة جميع الإجابات ... ؟") == DialogResult.No)
                {
                    return;
                }
            }
            // Chang Void By Names
            ReadData();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            label1_Click(sender, e);
        }
    }
}
