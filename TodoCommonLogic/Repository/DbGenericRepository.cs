using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using TodoCommonLogic.Repository.Interfaces;
using TodoDataAccess;

namespace TodoCommonLogic.Repository
{
    public class DbGenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly TodoDbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public DbGenericRepository(TodoDbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _dbSet.ToList();
        }

        public IEnumerable<TEntity> GetBy(Expression<Func<TEntity, bool>> filter)
        {
            if (filter == null)
            {
                throw new ArgumentNullException(nameof(filter), @"Predicate cannot be null");
            }

            return _dbSet.Where(filter).ToList();
        }

        public TEntity Add(TEntity entity)
        {
            _dbSet.Add(entity);
            return entity;
        }

        public void Delete(TEntity entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Deleted;
        }
        
        public TEntity Edit(TEntity entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;

            return entity;
        }
    }
}
