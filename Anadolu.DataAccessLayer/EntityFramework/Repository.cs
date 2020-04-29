﻿using Anadolu.Core.DataAccess;
using Anadolu.DataAccessLayer;
using Anadolu.Entitiess;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Anadolu.DataAccessLayer.EntityFramework
{
    public class Repository<T> :  IDataAccess<T> where T:class
    {
        DataBaseContext context =  new DataBaseContext();

        private DbSet<T> _objectSet;
        public Repository()
        {
           
            _objectSet = context.Set<T>();
           


        }
        public List<T> List()
        {

          
            return _objectSet.ToList();

        }
        public List<T> List(Expression<Func<T,bool>> where)
        {
            return _objectSet.Where(where).ToList() ;
        }
        
        public int Insert(T obj)
        { 
            _objectSet.Add(obj);
            return Save();
        }
        public int Save()
        {
            
            return context.SaveChanges();
        }
        public int Update(T obj)
        { 
            return Save();
        }
        public int Delete(T obj)
        {
            _objectSet.Remove(obj);
            return Save();
        }
        public T Find(Expression<Func<T, bool>> where)
        {

          return context.Set<T>().SingleOrDefault(where);
        }

       

    }
}
