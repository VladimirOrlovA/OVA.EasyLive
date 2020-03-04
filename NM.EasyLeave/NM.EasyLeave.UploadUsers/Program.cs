using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json;
using NM.EasyLeave.DAL;
using System.IO;

namespace NM.EasyLeave.UploadUsers
{
    class Program
    {
        public static user GetUser()
        {
            var client = new RestClient("http://randomuser.ru");
            var request = new RestRequest("api.json", Method.GET);
            var response = client.Execute(request);
            string result = response.Content;
            List<UserModel> users =
                JsonConvert.DeserializeObject<List<UserModel>>(result);
            return users[0].user;
        }
        static void Main(string[] args)
        {
            string MyDocuments = System.Environment.GetFolderPath
                (Environment.SpecialFolder.MyDocuments);

            string path = Path.Combine(MyDocuments, "MyData.db");

            DataContext<user> db = new DataContext<user>(path);
            for(int i = 0; i<50; i++)
            {
                db.Add(GetUser());
            }
        }
    }
}
