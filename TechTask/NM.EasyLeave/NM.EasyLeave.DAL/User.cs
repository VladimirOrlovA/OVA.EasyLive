using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NM.EasyLeave.DAL
{
    public class name
    {
        public string first { get; set; }
        public string last { get; set; }
        public string middle { get; set; }

    }

    public class location
    {
        public string building { get; set; }
        public string street { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zip { get; set; }
    }

    public class picture
    {
        public string large { get; set; }
        public string medium { get; set; }
        public string thumbnail { get; set; }
    }

    public class user
    {
        public string gender { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public name name { get; set; }
        public location location { get; set; }
        public picture picture { get; set; }
        public string dob { get; set; }
        public string phone { get; set; }
        public string cell { get; set; }
        public string registered { get; set; }
    }

    public class UserModel
    {
        public user user { get; set; }
    }
}
