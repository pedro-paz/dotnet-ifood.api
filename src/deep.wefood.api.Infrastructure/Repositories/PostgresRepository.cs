﻿using deep.wefood.api.Domain.Entities;
using deep.wefood.api.Domain.Interfaces.Generics;
using deep.wefood.api.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace deep.wefood.api.Infrastructure.Repositories
{
    public class PostgresRepository<TEntity>
        : IDisposable, IRepository<TEntity> where TEntity : BaseEntity
    {
        public PostgresContext Db = new PostgresContext();

        public void Add(TEntity obj)
        {
            Db.Set<TEntity>().Add(obj);
        }

        public void Dispose()
        {
            Db.Dispose();
        }

        public IEnumerable<TEntity> FindAll()
        {
            return Db.Set<TEntity>().ToList();
        }

        public TEntity GetSingle(int id)
        {
            return Db.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> Query(Func<TEntity, bool> predicate)
        {
            return Db.Set<TEntity>().Where(predicate);
        }

        public void Delete(TEntity obj)
        {
            Db.Remove(obj);
        }

        public void Update(TEntity obj)
        {
            Db.Entry(obj).State = EntityState.Modified;
        }

        public void SaveChanges()
        {
            Db.SaveChanges();
        }

        public TEntity FindById(int id)
        {
            var entity = Db.Set<TEntity>().Where(x => x.Id == id).FirstOrDefault();
            return entity;
        }

    }
}
