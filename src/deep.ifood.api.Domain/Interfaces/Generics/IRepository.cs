using System;
using System.Collections.Generic;
using deep.ifood.api.Domain.Entities;

namespace deep.ifood.api.Domain.Interfaces.Generics{
    public interface IRepository<T> where T : BaseEntity
    {
        T Add(T entity);
        T Update(T entity);
        T FindById(int id);
        void Delete(T entity);        
        void SaveChanges();
        IEnumerable<T> FindAll();
        IEnumerable<T> Query(Func<T,bool> predicate);
    }
}