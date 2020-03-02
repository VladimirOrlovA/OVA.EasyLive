using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using OVA.EasyLive.DAL;
using Newtonsoft.Json;
using System.IO;

namespace OVA.EasyLive.UploadUser
{
    class Program
    {
        public static user GetUser()
        {
            // создаем клиента
            var client = new RestClient("http://randomuser.ru/");

            // запрос к файлу api.json методом POST
            var request = new RestRequest("api.json", Method.GET);

            // выполнение запроса и получение JSON строки 
            var response = client.Execute(request);

            List<UserModel> users = JsonConvert.DeserializeObject<List<UserModel>>(response.Content);

            return users[0].user;

        }

        // запрос данных на сайте http://randomuser.ru/ 
        static void Main(string[] args)
        {
            string MyDocuments = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            string path = Path.Combine(MyDocuments, "MyData.db");

            DataContext<user> db = new DataContext<user>(path);

            for (int i = 0; i < 50; i++)
            {
                db.Create(GetUser());
            }
        }
    }
}
