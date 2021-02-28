using System;
using System.Collections.Generic;
using System.Linq;
using deep.ifood.api.Domain.Entities;
using deep.ifood.api.Domain.Interfaces.Generics;

namespace deep.ifood.api.Services
{
    public abstract class ServiceBase<T> where T : BaseEntity
    {
        protected IRepository<T> _repository;
        public ServiceBase(IRepository<T> repository)
        {
            _repository = repository;
        }

        public T Add(T entity)
        {
            _repository.Add(entity);
            _repository.SaveChanges();
            return entity;
        }

        public T FindById(int id)
        {
            return _repository.Query(x => x.Id == id).FirstOrDefault();
        }

        public T Update(T entity)
        {
            _repository.Update(entity);
            _repository.SaveChanges();
            return entity;
        }

        public void Delete(T entity)
        {
            _repository.Delete(entity);
            _repository.SaveChanges();
        }

        public IEnumerable<T> Query(Func<T, bool> predicate)
        {
            return _repository.Query(predicate);
        }

        public IEnumerable<T> FindAll()
        {
            return _repository.FindAll();
        }

        public void SaveChanges()
        {
            _repository.SaveChanges();
        }

        
    }
}