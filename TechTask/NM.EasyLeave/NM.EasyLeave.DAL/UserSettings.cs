using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NM.EasyLeave.DAL
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

            using (DataContext<user> db = new DataContext<user>(path))
            {
              

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
