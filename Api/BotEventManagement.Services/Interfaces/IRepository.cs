using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace EventManager.Services.Interfaces
{
    public interface IRepository<TIn, TOut, TEntity>
    {
        void Create(TIn element);
        IEnumerable<TOut> Select(Expression<Func<TEntity, bool>> query);

        //ToDo find a better way to delete element
        void Delete(TIn element);
        void Update(TIn element);
    }
}
