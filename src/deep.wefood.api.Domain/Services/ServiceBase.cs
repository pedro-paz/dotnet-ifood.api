using System;
using System.Collections.Generic;
using System.Linq;
using deep.wefood.api.Domain.Entities;
using deep.wefood.api.Domain.Interfaces.Generics;

namespace deep.wefood.api.Services
{
    public abstract class ServiceBase<T> where T : BaseEntity
    {
        protected IRepository<T> _repository;
        public ServiceBase(IRepository<T> repository)
        {
            _repository = repository;
        }

        public virtual void Add(T entity)
        {
            _repository.Add(entity);
        }

        public virtual T FindById(int id)
        {
            return _repository.Query(x => x.Id == id).FirstOrDefault();
        }

        public virtual void Update(T entity)
        {
            _repository.Update(entity);
        }

        public virtual void Delete(T entity)
        {
            _repository.Delete(entity);
        }

        public virtual IEnumerable<T> Query(Func<T, bool> predicate)
        {
            return _repository.Query(predicate);
        }

        public virtual IEnumerable<T> FindAll()
        {
            return _repository.FindAll();
        }

        public void SaveChanges()
        {
            _repository.SaveChanges();
        }


    }
}