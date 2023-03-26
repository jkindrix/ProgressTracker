using Microsoft.EntityFrameworkCore;
using ProgressTracker.Domain.Interfaces;
using ProgressTracker.Common.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ProgressTracker.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _dbContext;
        protected readonly DbSet<T> _dbSet;

        public Repository(ApplicationDbContext context)
        {
            _dbContext = context;
            _dbSet = _dbContext.Set<T>();
        }

        public IQueryable<T> FindAll()
        {
            return _dbSet.AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return _dbSet
                .Where(expression).AsNoTracking();
        }

        public virtual void Create(T entity)
        {
            DateTime timestamp = DateTime.Now;
            entity.TrySetProperty("CreatedAt", timestamp);
            entity.TrySetProperty("UpdatedAt", timestamp);
            _dbSet.Add(entity);
        }

        public virtual void Update(T entity)
        {
            entity.TrySetProperty("UpdatedAt", DateTime.Now);
            _dbSet.Update(entity);
        }

        public virtual void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }
    }
}
