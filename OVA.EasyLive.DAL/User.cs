using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OVA.EasyLive.DAL
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
        string large { get; set; }
        string medium { get; set; }
        string thumbnail { get; set; }
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


    //"[{\"user\":{\"gender\":\"male\",\"name\":{\"first\":\"Валерий\",\"last\":\"Горбачёв\",\"middle\":\"Григорьевич\"}

    //,\"location\":{\"building\":15,\"street\":\"Вокзальная\",\"city\":\"Новгород\",\"state\":\"Республика Тыва\",\"zip\":24930},

    // NO \"username\":\"hotuser\",\"email\":\"hotuser40@example.com\",\"password\":\"14o7-TGi0-Y\",\"salt\":\"kcvKVsbx5LA\",
    //\"md5\":\"e9a2b3280301e2c3ba9edde7263be1d6\",\"sha1\":\"dee813a90d710958dde4a9890c320c1d6cd12a08\",\"sha256\":
    //\"45b0c2408d9e17be54f8f547ff41272fd3888bcd2d110b9a757cb7b1ed187dff\",\"registered\":873631364,\"dob\":34045146,\"phone
    //\":\"7-495-921-74-70\",\"cell\":\"7-916-708-96-65\",\"picture\":{\"large\":\"http://randomuser.ru/images/men/33.jpg\",
    //\"medium\":\"http://randomuser.ru/images/men/med/33.jpg\",\"thumbnail\":\"http://randomuser.ru/images/men/thumb/33.jpg\"}}}]"

