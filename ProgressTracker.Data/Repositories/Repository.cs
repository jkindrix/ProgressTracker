using Microsoft.EntityFrameworkCore;
using ProgressTracker.Domain.Interfaces;
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
        private readonly ApplicationDbContext _dbContext;
        private readonly DbSet<T> _dbSet;

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
            TrySetProperty(entity, "CreatedAt", timestamp);
            TrySetProperty(entity, "UpdatedAt", timestamp);
            _dbSet.Add(entity);
        }

        public virtual void Update(T entity)
        {
            TrySetProperty(entity, "UpdatedAt", DateTime.Now);
            _dbSet.Update(entity);
        }

        public virtual void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        private static bool TrySetProperty(object obj, string property, object value)
        {
            var prop = obj.GetType().GetProperty(property, BindingFlags.Public | BindingFlags.Instance);
            if (prop != null && prop.CanWrite)
            {
                prop.SetValue(obj, value, null);
                return true;
            }
            return false;
        }
    }
}
