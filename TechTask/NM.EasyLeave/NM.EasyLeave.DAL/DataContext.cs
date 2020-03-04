using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteDB;

namespace NM.EasyLeave.DAL
{
   public class DataContext <T>: IDisposable where T:class 
    {
        string path { get; set; }
        public DataContext(string path)
        {
            this.path = path;
        }
        public bool Add(T data)
        {
            try
            {
                using (var db = new LiteDatabase(path))
                {
                    var users = db.GetCollection<T>(typeof(T).Name);
                    users.Insert(data);
                    return true;
                }
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public bool Update(T record)
        {
            try
            {
                using (var db = new LiteDatabase(path))
                {
                    var data = db.GetCollection<T>(typeof(T).Name);
                    data.Update(record);
                    return true;
                }
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
                using (var db = new LiteDatabase(path))
                {
                    var data = db.GetCollection<T>(typeof(T).Name);
                    data.Delete(id);
                    return true;
                }
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
                using (var db = new LiteDatabase(path))
                {
                    return db.GetCollection<T>(typeof(T).Name).FindAll().ToList();
                }
            }
            catch
            {
                return null;
            }
        }
        
        public T GetById(int id)
        {
            try
            {
                using (var db = new LiteDatabase(path))
                {
                    return db.GetCollection<T>(typeof(T).Name).FindById(id);
                }
            }
            catch
            {
                return null;
            }
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }
    }
}
