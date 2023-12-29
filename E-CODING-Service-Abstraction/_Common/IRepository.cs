using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;

namespace E_CODING_Service_Abstraction
{
    public interface IRepositoryBase<T>
    {
        IQueryable<T> FindAll();
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
