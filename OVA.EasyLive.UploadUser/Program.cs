﻿using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json;
using System.IO;
using OVA.EasyLive;
using OVA.EasyLive.DAL;
using System.Configuration;

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

            string result = response.Content;
            List<UserModel> users = JsonConvert.DeserializeObject<List<UserModel>>(result);

            return users[0].user;

        }

        // запрос данных на сайте http://randomuser.ru/ 
        static void Main(string[] args)
        {
            //string MyDocuments = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            //string path = Path.Combine(MyDocuments, "MyData.db");  // C:\Users\ОрловВ\Documents
            //DataContext<user> db = new DataContext<user>(path);

            string path = ConfigurationManager.AppSettings["dbPathString"];
            path = Path.Combine(path, "MyData.db");
            DataContext<user> db = new DataContext<user>(path);

            for (int i = 0; i < 50; i++)
            {
                Console.WriteLine($"Запись № - {i}");
                db.Create(GetUser());
            }

            Console.WriteLine("Готово");
            Thread.Sleep(3000);
        }
    }
}

