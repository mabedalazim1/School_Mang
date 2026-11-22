using School_Mang.DAL;

namespace School_Mang.BL.Services.Nateg
{
    public class AssessmentService
    {
        private readonly SiteAccessLayer _siteAccess =
            new SiteAccessLayer();

        public void DeleteAssessmentFromSite(
            int yearId,
            int termId,
            int gradeId,
            string spName)
        {
            _siteAccess.ExecNonQuery(
                "SP_Delete_From_" + spName,
                SqlParam.Int("@year_Id", yearId),
                SqlParam.Int("@term_Id", termId),
                SqlParam.Int("@grade_Id", gradeId)
            );
        }
    }
}