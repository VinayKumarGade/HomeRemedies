using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Remedies.DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T: class
    {
        T Get(int id);
        IEnumerable<T> GetAll(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = null //used for eager loading when we have foriegn refereces 
            );

        T GetFirstOrDefault(
            Expression<Func<T, bool>> filter = null,
            string includeProperties = null //used for eager loading when we have foriegn refereces 
            );
        void Add(T entity);
        void Remove(int id);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entity);
    }
}
