using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using WAD_01.Models;

namespace WAD_01.Reponsitory
{
    public class Responsitory<T> : IResponsitory<T> where T : class, new()
    {
        private readonly ApplicationDbContext cnn;

        private readonly DbSet<T> tbl;
        public Responsitory()
        {
            cnn = new ApplicationDbContext();
            tbl = cnn.Set<T>();

        }
        public bool Delete(object id)
        {
            try
            {
                var entity = Get(id);
                if (entity == null)
                {
                    return false;
                }
                tbl.Remove(entity);
                cnn.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(T entity)
        {
            try
            {
                tbl.Remove(entity);
                cnn.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IEnumerable<T> Get()
        {
            return tbl.AsEnumerable();
        }

        public IEnumerable<T> Get(Expression<Func<T, bool>> predicate)
        {
            return tbl.Where(predicate).AsEnumerable();
        }

        public T Get(object id)
        {
            return tbl.Find(id);
        }
    }
}