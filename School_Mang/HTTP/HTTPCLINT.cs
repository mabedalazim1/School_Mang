
using School_Mang.BL;
using School_Mang.Models;
using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace School_Mang.HTTP
{
    public class HTTPCLINT
    {
        private static readonly HttpClient client = new HttpClient
        {
            Timeout = TimeSpan.FromSeconds(30)
        };

        private readonly string uri =
            Properties.Settings.Default.site_uri;

        private async Task SignInAsync()
        {
            if (string.IsNullOrWhiteSpace(uri))
                throw new InvalidOperationException(
                    "عنوان الموقع غير مضبوط.");

            if (client.BaseAddress == null)
                client.BaseAddress = new Uri(uri);

            var loginInfo = new Login_Info
            {
                username = "admin",
                password = "admin2026"
            };

            string login = JsonSerializer.Serialize(loginInfo);

            using (var content = new StringContent(
                login, Encoding.UTF8, "application/json"))
            using (var response = await client.PostAsync(
                "auth/signin", content))
            {
                response.EnsureSuccessStatusCode();

                var result =
                    await response.Content.ReadFromJsonAsync<log_data>();

                if (result == null ||
                    string.IsNullOrWhiteSpace(result.accessToken))
                {
                    throw new InvalidOperationException(
                        "لم يتم الحصول على رمز الدخول من الموقع.");
                }

                Globals.accessToken = result.accessToken;
            }
        }

        public async Task<bool> UploadFileAsync(
            string filePath, string address)
        {
            if (string.IsNullOrWhiteSpace(filePath) ||
                !File.Exists(filePath))
            {
                throw new FileNotFoundException(
                    "ملف الرفع غير موجود.", filePath);
            }

            if (string.IsNullOrWhiteSpace(address))
                throw new ArgumentException(
                    "مسار الرفع غير صالح.");

            if (string.IsNullOrWhiteSpace(uri))
                throw new InvalidOperationException(
                    "عنوان الموقع غير مضبوط.");

            if (string.IsNullOrWhiteSpace(Globals.accessToken))
                await SignInAsync();

            using (var formData = new MultipartFormDataContent())
            using (var fileStream = File.OpenRead(filePath))
            using (var fileContent = new StreamContent(fileStream))
            {
                fileContent.Headers.ContentType =
                    new MediaTypeHeaderValue(
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");

                formData.Add(fileContent, "file", filePath);

                using (var request = new HttpRequestMessage(
                    HttpMethod.Post, address))
                {
                    request.Headers.Accept.Add(
                        new MediaTypeWithQualityHeaderValue(
                            "application/json"));

                    request.Headers.Add(
                        "x-access-token", Globals.accessToken);

                    request.Content = formData;

                    using (var response = await client.SendAsync(request))
                    {
                        return response.IsSuccessStatusCode;
                    }
                }
            }
        }
    }
}
