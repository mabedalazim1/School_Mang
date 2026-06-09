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
using School_Mang.BL;

namespace School_Mang.PL.MAIN
{
    // Mohamed Nora
    class CLS_FUNCATIONS
    {
        String Host = Properties.Settings.Default.Server_Name;
        int Port = 22;
        String Username = "kps";
        String Password = "kps2020";

        public void DowanloadDataBase(string LocalDestinationFilename, string RemoteFileName)
        {
            try
            {
                string folder = Path.GetDirectoryName(LocalDestinationFilename);

                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }

                Waiting.Start();
                using (SftpClient sftp = new SftpClient(Host, Port, Username, Password))
                {
                    sftp.Connect();

                    using (Stream file = File.Create(LocalDestinationFilename))
                    {
                        sftp.DownloadFile(RemoteFileName, file);
                    }

                    sftp.Disconnect();
                    Waiting.Stop();
                }
            }
            catch (Exception e)
            {
                Waiting.Stop();
                MSG.ErrorMesg(e.Message + " error");
            }
        }

        public void UploadDataBase(string LocalDestinationFilename, string RemoteFileName)
        {
            try
            {
                Waiting.Start();
                SftpClient sftp = new SftpClient(Host, Port, Username, Password);

                sftp.Connect();

                FileStream file = new FileStream(LocalDestinationFilename, FileMode.Open);
                if (file != null)
                {
                    sftp.UploadFile(file, RemoteFileName, true, null);
                }

                sftp.Disconnect();
                Waiting.Stop();
            }
            catch (Exception e)
            {
                MSG.ErrorMesg(e.Message);
                Waiting.Stop();
            }
        }
    }
}
