using School_Mang.BL;
using School_Mang.BL.Common.Helper;
using School_Mang.BL.Services;
using School_Mang.PL.MAIN;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace School_Mang.PL.NATIGA.HOME
{
    public partial class FRM_MANG_SITE : Form
    {
        HTTP.HTTPCLINT HTTP = new HTTP.HTTPCLINT(); 
        BL.NATEG.cls_NATAG_FUNCTIONS natag_func = new BL.NATEG.cls_NATAG_FUNCTIONS();

        // Form Closed
        private static FRM_MANG_SITE frm_Mang_Site;
        static void frm_Form_Closed(object sender, FormClosedEventArgs e)
        {
            frm_Mang_Site = null;
        }
        public static FRM_MANG_SITE Get_Frm_Mang_Site
        {
            get
            {
                if (frm_Mang_Site == null)
                {
                    frm_Mang_Site = new FRM_MANG_SITE();
                    frm_Mang_Site.FormClosed += new FormClosedEventHandler(frm_Form_Closed);
                }
                return frm_Mang_Site;
            }
        }

        public FRM_MANG_SITE()
        {
            InitializeComponent();

            if (frm_Mang_Site == null)
            {
                frm_Mang_Site = this;
            }
        }




        // Upload File

        private async Task UploadFile(string path)
        {
            if (openFileDialog1.ShowDialog() != DialogResult.OK)
            {
                MSG.ErrorMesg("تم إلغاء الإجراء ..!");
                Globals.Dir_Path = "D://Rasd";
                return;
            }

            if (!await InternetFlow.EnsureAsync())
                return;

            try
            {
                Waiting.Start();

                bool result = await HTTP.UploadFileAsync(
                    openFileDialog1.FileName, path);

                if (result)
                    MSG.MyMesg("تم رفع الملف بنجاح");
                else
                    MSG.ErrorMesg("لم يتم رفع الملف .. يرجى مراجعة البيانات ... !");
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


        // Open Assessment Form
        private async Task open_Assessment_Form(FRM_ADD_ASSESSMENT_DATA frm)
        {
            if (!await InternetFlow.EnsureAsync())
                return;

            frm.ShowDialog();
        }

        private void lbl_back_Click(object sender, EventArgs e)
        {
            natag_func.changePages(FRM_NATEG.Get_Frm_Nateg.pn_home, "التقييمات");
        }

        private void pic_back_Click(object sender, EventArgs e)
        {
            lbl_back_Click(sender,e);
        }

        private async void lbl_upload_a_Click(object sender, EventArgs e)
        {
            await UploadFile("upload/degree");
        }

        private void pic_upload_a_Click(object sender, EventArgs e)
        {
            lbl_upload_a_Click(sender, e);
        }

        private async void lbl_upload_test_Click(object sender, EventArgs e)
        {
            await UploadFile("upload/mark");
        }

        private void pic_upload_test_Click(object sender, EventArgs e)
        {
            lbl_upload_test_Click(sender, e);
        }

        private async void lbl_degree_Click(object sender, EventArgs e)
        {
            if (!await InternetFlow.EnsureAsync())
                return;

            FRM_CHOSE_NATAG.Get_Frm_Chose_Natag.ShowDialog();
        }

        private void pic_degree_Click(object sender, EventArgs e)
        {
            lbl_degree_Click(sender, e);
        }

        private async void lbl_del_data_from_site_Click(object sender, EventArgs e)
        {
            if (!await InternetFlow.EnsureAsync())
                return;

            FRM_DELETE_SITE_DATA.Get_Frm_Delete_Data.ShowDialog();
        }

        private void pic_del_data_from_site_Click(object sender, EventArgs e)
        {
            lbl_del_data_from_site_Click(sender, e);
        }

        
        private async void lbl_upload_assessment_Click(object sender, EventArgs e)
        {
           // BL.Globals.Del_Assessment_Data = false;

            var frm = FRM_ADD_ASSESSMENT_DATA.Get_Frm_Add_Assessment;
            var context = new NavigationContext();
            context.Natiga.DelAssessmentData = false;
            frm.SetNavigation(context);

           await open_Assessment_Form(frm);

        }

        private void pic_upload_assessment_Click(object sender, EventArgs e)
        {
            lbl_upload_assessment_Click(sender, e);
        }

        private async void lbl_del_assessment_Click(object sender, EventArgs e)
        {
            //BL.Globals.Del_Assessment_Data = true;

            var frm = FRM_ADD_ASSESSMENT_DATA.Get_Frm_Add_Assessment;

            var context = new NavigationContext();
            context.Natiga.DelAssessmentData = true;

            frm.SetNavigation(context);

            await open_Assessment_Form(frm);
        }

        private void pic_del_assessment_Click(object sender, EventArgs e)
        {
            lbl_del_assessment_Click(sender, e);
        }
    }
}
