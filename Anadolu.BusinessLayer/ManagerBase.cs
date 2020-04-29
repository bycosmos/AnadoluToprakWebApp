using Anadolu.Core.DataAccess;
using Anadolu.DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Anadolu.BusinessLayer
{
   public class ManagerBase<T> : IDataAccess<T> where T:class
    {
        private Repository<T> repo = new Repository<T>();
        public int Delete(T obj)
        {

            return repo.Delete(obj);
        }

        public T Find(Expression<Func<T, bool>> where)
        {   
            return repo.Find(where);
        }

        public int Insert(T obj)
        {
            return repo.Insert(obj);
        }

        public List<T> List()
        {
           return repo.List();
        }

        public List<T> List(Expression<Func<T, bool>> where)
        {
            return repo.List(where);
        }

        public int Save()
        {
           return repo.Save();
        }

        public int Update(T obj)
        {
            return repo.Update(obj);
        }



        //public virtual IQueryable<T> ListQueryable()
        //{
        //    return repo.ListQueryable();
        //}
    }
}
