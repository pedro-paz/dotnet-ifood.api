using System;
using System.Collections.Generic;
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
        IEnumerable<T> Query(Func<T, bool> predicate);
    }
}