using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using School_Mang.BL;
using CrystalDecisions.CrystalReports.Engine;

namespace School_Mang.RPT
{
    class REPORT_CONNECTION
    {
        Waiting Waiting = new Waiting();
        MSG msg = new MSG();
        string[] sen = { };

        public void OpenReport(ReportDocument rpt, string frm_caption,string frm_text )
                               
        {
            Waiting.Wait();

            string server = Properties.Settings.Default.Server_Name;
            string dataBase = Properties.Settings.Default.DataBasee_name;
            string user = Properties.Settings.Default.DataBasee_User;
            string pass = Properties.Settings.Default.DataBasee_Pass;
            try
            {
                rpt.DataSourceConnections[0].IntegratedSecurity = false;
                rpt.DataSourceConnections[0].SetConnection(server, dataBase, user, pass);
                FRM_REPORTS.Get_Frm_report.lbl_caption.Text = frm_caption;
                FRM_REPORTS.Get_Frm_report.Text = frm_text;
                FRM_REPORTS.Get_Frm_report.crystalReportViewer1.ReportSource = rpt;
                Waiting.End_WAit();
                FRM_REPORTS.Get_Frm_report.ShowDialog();
            }
            catch(Exception e)
            {
                msg.ErrorMesg(e.Message);
                Waiting.End_WAit();
            }
            Waiting.End_WAit();

        }
        public void OpenElthakReport(string std_code, string std_name, string nat , int sana)
        {
            rpt_Eltehak myReport = new rpt_Eltehak();
            HESAB_SEN hesab_sen = new HESAB_SEN();

            sen = hesab_sen.Nat_HesabSen(nat, sana);
            string octber_date = sen[0] + " يوم - " + sen[1] + " شهر - " + sen[2] + " سنة";
           

            myReport.SetParameterValue("@std_code", std_code);
            myReport.SetParameterValue(1, octber_date);

            OpenReport(myReport, "طلب إلتحاق  " + std_name, "طلب إلتحاق");
        }

    }
}
