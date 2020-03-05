using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteDB;

namespace OVA.EasyLive.DAL
{
    public class DataContext<T> : IDisposable where T : class 
    {
        string path { get; set; }

        public DataContext(string path)
        {
            this.path = path;
        }


        public bool Create(T obj)
        {
            try
            {
                using (var ldb = new LiteDatabase(path))
                {
                    ILiteCollection<T> objects = ldb.GetCollection<T>(typeof(T).Name);
                    objects.Insert(obj);
                }
                return true;
            }
            catch
            {
                return false; 
            }
            
        }

        public IEnumerable<T> GetAll()
        {
            try
            {
                using (var ldb = new LiteDatabase(path))
                {
                    return ldb.GetCollection<T>(typeof(T).Name).FindAll().ToList();
                }
            }
            catch
            {
                return null;
            }
        }

        public T GetOne(int id)
        {
            try
            {
                using (var ldb = new LiteDatabase(path))
                {
                    return ldb.GetCollection<T>(typeof(T).Name).FindById(id);
                }
            }
            catch
            {
                return null;
            }
        }

        public bool Update(T data)
        {
            try
            {
                using (var ldb = new LiteDatabase(path))
                {
                   var objects = ldb.GetCollection<T>(typeof(T).Name);
                    objects.Update(data);
                }
                return true;
            }
            catch
            {
                return false;
            }

        }

        public bool Delete(int id)
        {
            try
            {
                using (var ldb = new LiteDatabase(path))
                {
                    ILiteCollection<T> objects = ldb.GetCollection<T>(typeof(T).Name);
                    objects.Delete(id);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void Dispose()
        {

        }

    }
}
