using EventManager.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace EventManager.Services.Persistence.Repositories
{
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
            //For include navigations related, is necessary transform an Entity to an IQueryable
            //otherwise is not possible to get properties to include them
            var list = new List<TEntity>();
            list.Add(_context.Set<TEntity>().Find(id));

            return Include(list.AsQueryable()).First();
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return QueryEager().ToList();
        }

        public virtual IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return QueryEager().Where(predicate);
        }

        public virtual void Remove(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public virtual void RemoveRange(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().RemoveRange(entities);
        }

        public virtual void Update(int id, TEntity newElement)
        {
            var element = Get(id);

            var properties = typeof(TEntity).GetProperties();

            //Get all properties by reflection e update them            
            foreach (var prop in properties)
            {
                var value = prop.GetValue(newElement);

                if (!IsEmpty(value))
                {
                    var field = properties.Where(x => x.Name == prop.Name).First();
                    field.SetValue(element, value);
                }
            }
        }

        protected virtual IQueryable<TEntity> QueryEager()
        {
            var query = _context.Set<TEntity>().AsQueryable();

            return Include(query);
        }

        protected virtual IQueryable<TEntity> Include(IQueryable<TEntity> entities)
        {
            foreach (var property in _context.Model.FindEntityType(typeof(TEntity)).GetNavigations())
            {
                entities = entities.Include(property.Name);
            }

            return entities;
        }

        private bool IsEmpty(object field)
        {
            if (field == null || string.IsNullOrEmpty(field.ToString()))
                return true;
            if (int.TryParse(field.ToString(), out int result) && result <= 0)
                return true;

            return false;
        }
    }
}
