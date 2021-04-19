using deep.wefood.api.Domain.Entities;
using deep.wefood.api.Domain.Interfaces.Generics;
using deep.wefood.api.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace deep.wefood.api.Infrastructure.Repositories
{
    public class PostgresRepository<TEntity>
        : IDisposable, IRepository<TEntity> where TEntity : BaseEntity
    {
        public PostgresContext _context;

        public PostgresRepository(PostgresContext context)
        {
            _context = context;
        }

        public void Add(TEntity obj)
        {
            _context.Set<TEntity>().Add(obj);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public IEnumerable<TEntity> FindAll()
        {
            return _context.Set<TEntity>().ToList();
        }

        public TEntity GetSingle(int id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> predicate)
        {
            return _context.Set<TEntity>().Where(predicate).AsQueryable();
        }
        public IQueryable<T2> Select<T2>(Expression<Func<TEntity, T2>> selector)
        {
            return _context.Set<TEntity>().Select(selector).AsQueryable();
        }

        public void Delete(TEntity obj)
        {
            _context.Remove(obj);
        }

        public void Update(TEntity obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public TEntity FindById(int id)
        {
            var entity = _context.Set<TEntity>().Where(x => x.Id == id).FirstOrDefault();
            return entity;
        }


    }
}
