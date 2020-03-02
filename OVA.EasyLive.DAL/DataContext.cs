using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteDB;

namespace OVA.EasyLive.DAL
{
    public class DataContext<T> where T : class
    {
        string path { get; set; }

        public DataContext(string path)
        {
            this.path = path;
        }


        public bool addUser(T obj)
        {
            try
            {
                using (var ldb = new LiteDatabase(path))
                {
                    ILiteCollection<T> objects = ldb.GetCollection<T>(typeof(T).Name);
                    objects.Insert(obj);
                    return true;
                }
            }
            catch
            {
                return false; 
            }
            
        }
    }
}
