using ProgressTracker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgressTracker.Service.Interfaces
{
    public interface IService<T> where T : class
    {
        public List<T> GetAll();
        //public T GetById(int id);
        public T? GetOneBy<T2>(string PropertyName, T2 value);
        public IList<T>? GetManyBy<T2>(string PropertyName, T2 value);
        public void Create(T entity);
        public void Update(T entity);
        public void Delete(T entity);
    }
}
