using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using deep.wefood.api.Domain.Entities;

namespace deep.wefood.api.Domain.Interfaces.Generics
{
    public interface IRepository<T> where T : BaseEntity
    {
        void Add(T entity);
        void Update(T entity);
        T FindById(int id);
        void Delete(T entity);
        void SaveChanges();
        IEnumerable<T> FindAll();
        IQueryable<T> Query(Expression<Func<T, bool>> predicate);
        IQueryable<T2> Select<T2>(Expression<System.Func<T, T2>> selector);
    }

}