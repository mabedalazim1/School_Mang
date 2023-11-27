using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace School_Mang.Models
{

    public class Login_Info
    {
        public string username { get; set; }
        public string password { get; set; }
    }
    public class log_data
    {
        public int id { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public List<string> roles { get; set; }
        public string accessToken { get; set; }
        public string firstName { get; set; }
        public string userSchoolId { get; set; }
        public string stdGrade { get; set; }
        public string stdGender { get; set; }
        public string stdClass { get; set; }
    }

    public class UplodFile
    {
        string message { get; set; }
    }
}


//private async void GetImageCatogeries()
//{

//    await HTTP.GetDataFromSite("https://www.alkwtherps.com/api/imgcatogery");

//    if (BL.Globals.Http_Content != null)
//    {
//        List<ImageCatogeries> data = new List<ImageCatogeries>();
//        data = await BL.Globals.Http_Content.ReadFromJsonAsync<List<ImageCatogeries>>();

//        dataGridView1.DataSource = data.Select(myClaas => new
//        {
//            myClaas.id,
//            myClaas.title,
//            myClaas.catDesc,
//            myClaas.createdAt,
//            myClaas.imageSectionId
//        }).ToList();
//        dataGridView1.Refresh();
//    }
//    else
//    {
//        msg.MyMesg("NO Connection..!");
//    }
//}