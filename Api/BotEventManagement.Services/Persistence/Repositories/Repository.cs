using EventManager.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace EventManager.Services.Persistence.Repositories
{
    //ToDo treat nested propetiers
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext _context;

        public Repository(DbContext context)
        {
            _context = context;
        }

        public virtual void Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
        }

        public virtual void AddRange(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().AddRange(entities);       
        }

        public virtual TEntity Get(int id)
        {
           var entity = Query(true);

            return ((DbSet<TEntity>)entity).Find(id); 
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return Query(true).ToList();
        }

        public virtual IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return Query(true).Where(predicate);
        }


        public virtual void Remove(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public virtual void RemoveRange(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().RemoveRange(entities);
        }

        protected virtual IQueryable<TEntity> Query(bool eager = false)
        {
            var query = _context.Set<TEntity>().AsQueryable();

            if (eager)
            {
                foreach (var property in _context.Model.FindEntityType(typeof(TEntity)).GetNavigations())
                    query = query.Include(property.Name);
            }
            return query;
        }
    }
}
