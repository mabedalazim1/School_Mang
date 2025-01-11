using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using School_Mang.Models;

namespace School_Mang.HTTP
{
    public class HTTPCLINT
    {
        BL.MSG msg = new BL.MSG();
        BL.Waiting waiting = new BL.Waiting();

        private static readonly HttpClient client = new HttpClient();

        string uri = Properties.Settings.Default.site_uri;

        private async Task SignIn()
        {
            try
            {
                client.BaseAddress = new Uri(uri);
                client.Timeout = new TimeSpan(0, 0, 30);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                var login_info = new Login_Info
                {
                    username = "admin",
                    password = "admin123",
                };
                var login = JsonSerializer.Serialize(login_info);

                var content = new StringContent(login, Encoding.UTF8, "application/json");

                var response = await client.PostAsync("auth/signin", content);

                if (response.Content != null)
                {
                    log_data log = new log_data();
                    log = await response.Content.ReadFromJsonAsync<log_data>();
                    BL.Globals.accessToken = log.accessToken;
                }
                else
                {
                    msg.MyMesg("Ther Is No respones From Site ... !");
                }
            }
            catch (Exception e)
            {
                msg.ErrorMesg(e.Message);
            }
        }

        public async Task UplodFile(string filePath, string addrs)
        {
            try
            {
                msg.MyExclamationMsg(uri);
                waiting.Wait();

                if (BL.Globals.accessToken == null) await SignIn();
                HttpClient client = new HttpClient();

                client.BaseAddress = new Uri(uri);
                client.Timeout = new TimeSpan(0, 0, 30);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("x-access-token", BL.Globals.accessToken);

                var formData = new MultipartFormDataContent();



                HttpContent content = new StreamContent(File.OpenRead(filePath));
                content.Headers.ContentType = new MediaTypeHeaderValue("application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");

                formData.Add(content, "file", filePath);

                var response = client.PostAsync(uri + addrs, formData).Result;
               
                if (response.IsSuccessStatusCode)
                {  
                    msg.MyMesg("تم رفع الملف بنجاح");
                }
                else
                {
                    msg.ErrorMesg("لم يتم رفع الملف .. يرجى مراجعة البيانات ... !");
                    msg.ErrorMesg("تم إلغاء العملية");
                }
            }
            catch (Exception e)
            {
                msg.ErrorMesg(e.Message);
                waiting.End_WAit();
            }
            waiting.End_WAit();
        }

        public async Task GetDataFromSite(string path)
        {
            try
            {
                waiting.Wait();

                if (BL.Globals.accessToken == null) await SignIn();

                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("x-access-token", BL.Globals.accessToken);
                HttpResponseMessage response = await client.GetAsync(uri + path);
                if (response.IsSuccessStatusCode)
                {
                    BL.Globals.Http_Content = response.Content;
                }
                else
                {
                    BL.Globals.Http_Content = null;
                }

            }
            catch (Exception e)
            {
                waiting.End_WAit();
                msg.ErrorMesg(e.Message);

            }
            finally
            {
                waiting.End_WAit();
            }
        }

    }
}