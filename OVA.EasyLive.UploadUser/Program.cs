using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using OVA.EasyLive.DAL;
using Newtonsoft.Json;

namespace OVA.EasyLive.UploadUser
{
    class Program
    {
        static void Main(string[] args)
        {
            // создаем клиента
            var client = new RestClient("http://randomuser.ru/");

            // запрос к файлу api.json методом POST
            var request = new RestRequest("api.json", Method.GET);

            // выполнение запроса
            var response = client.Execute(request);

            List<UserModel> users = JsonConvert.DeserializeObject<List<UserModel>>(response.Content);
        }
    }
}
