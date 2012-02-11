using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace NewWestlink.Infrastructure
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Create(TEntity entity);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(string id);

        TEntity GetByKey(string id);
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> expression);
        IEnumerable<TEntity> All();
    }
}