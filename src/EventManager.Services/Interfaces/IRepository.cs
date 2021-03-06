﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using EventManager.Services.Model.Entities;

namespace EventManager.Services.Interfaces
{
    public interface IRepository<TEntity>
    {
        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
     
        void Add(TEntity element);
        void AddRange(IEnumerable<TEntity> element);

        void Remove(TEntity element);
        void RemoveRange(IEnumerable<TEntity> element);
        void Update(int id, TEntity element);
    }
}
