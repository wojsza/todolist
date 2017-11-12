using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace TodoCommonLogic.Repository.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();

        IEnumerable<TEntity> GetBy(Expression<Func<TEntity, bool>> filter);

        TEntity Add(TEntity entity);

        void Delete(TEntity entity);

        TEntity Edit(TEntity entity);
    }
}
