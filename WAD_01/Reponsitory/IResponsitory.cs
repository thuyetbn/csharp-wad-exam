using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace WAD_01.Reponsitory
{
    public interface IResponsitory<T> where T : class, new()
    {
        IEnumerable<T> Get();
        IEnumerable<T> Get(Expression<Func<T, bool>> predicate);
        T Get(object id);
        bool Delete(object id);
        bool Delete(T entity);
    }
}
