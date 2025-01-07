using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Renci.SshNet;
using Renci.SshNet.Common;
using Renci.SshNet.Sftp;


namespace School_Mang.PL.MAIN
{
    // Mohamed Nora
    class CLS_FUNCATIONS
    {
        String Host = Properties.Settings.Default.Server_Name;
        int Port = 22;
        String Username = "kpsftp";
        String Password = "kps2020";


        BL.MSG msg = new BL.MSG();
        BL.Waiting waiting = new BL.Waiting();

        public string ToArabic(long num)
        {
            const string _arabicDigits = "۰۱۲۳٤٥٦۷۸۹";
            try
            {

                return new string(num.ToString().Select(c => _arabicDigits[c - '0']).ToArray());
            }
            catch (Exception e)
            {
                msg.ErrorMesg(e.Message);
                return num.ToString();
            }

        }

        // Get Year Desc
        public string Year_Desc()
        {
            string desc = " العام الدراسى ";
            if (BL.Globals.Current_Year_Data || BL.Globals.Details_Std)
            {
                desc += ToArabic(
                    Properties.Settings.Default.MyYear - 1) + " - " +
                    ToArabic(Properties.Settings.Default.MyYear);
                return desc;
            }
            else
            {
                desc += ToArabic(
                     Properties.Settings.Default.MyYear) + " - " +
                     ToArabic(Properties.Settings.Default.MyYear + 1);
                return desc;
            }

        }

        public void DowanloadDataBase(string LocalDestinationFilename, string RemoteFileName)
        {
            try
            {
                waiting.Wait();
                using (SftpClient sftp = new SftpClient(Host, Port, Username, Password))
                {
                    sftp.Connect();

                    using (Stream file = File.Create(LocalDestinationFilename))
                    {
                        sftp.DownloadFile(RemoteFileName, file);
                    }

                    sftp.Disconnect();
                    waiting.End_WAit();
                }
            }
            catch (Exception e)
            {
                waiting.End_WAit();
                msg.ErrorMesg(e.Message + " error");
            }
        }

        public void UploadDataBase(string LocalDestinationFilename, string RemoteFileName)
        {
            try
            {
                waiting.Wait();
                SftpClient sftp = new SftpClient(Host, Port, Username, Password);

                sftp.Connect();

                FileStream file = new FileStream(LocalDestinationFilename, FileMode.Open);
                if (file != null)
                {
                    sftp.UploadFile(file, RemoteFileName, true, null);
                }

                sftp.Disconnect();
                waiting.End_WAit();
            }
            catch (Exception e)
            {
                msg.ErrorMesg(e.Message);
                waiting.End_WAit();
            }
        }
    }
}
