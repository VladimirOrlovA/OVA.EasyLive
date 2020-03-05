using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OVA.EasyLive.DAL
{
    public static class UserSettings
    {
        private static string path { get; set; }

        static UserSettings()
        {
            path = ConfigurationManager.AppSettings["ConnectionString"];
        }

        public static bool AuthUser(ref user user, string email,  string pass, out string message)
        {
            message = "";

            path = ConfigurationManager.AppSettings["ConnectionString"];

            using (DataContext<user> db = new DataContext<user>(path))
            {
               List<user> users = db.GetAll().ToList();
               // email = "silverapple98@example.com"  password = "BxCtbdXsJOE"

                if (!db.GetAll().Any(u => u.email == email))
                {
                    message = "Пользователь не найден";
                    return false;
                }
               
                user = db.GetAll()
                    .FirstOrDefault(f => f.email == email && f.password == pass);
            }

            if (user != null)
                return true;
            else
            {
                message = "Вы ввели неправильный пароль";
                return false;
            }
        }
    }
}
