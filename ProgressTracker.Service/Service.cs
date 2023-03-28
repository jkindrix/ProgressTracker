using ProgressTracker.Common.Extensions;
using ProgressTracker.Data;
using ProgressTracker.Domain.Entities;
using ProgressTracker.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ProgressTracker.Service
{
    public abstract class Service<T> : IService<T> where T : class
    {
        protected readonly IUnitOfWork _unitOfWork;

        public Service(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public virtual List<T>? GetAll()
        {
            string entityTypeName = typeof(T).Name + "s";
            return _unitOfWork.TryGetProperty(entityTypeName)?.TryInvokeMethod<IQueryable<T>>("GetAll")?.ToList();
        }

        //public virtual T? GetById(int id)
        //{
        //    string entityTypeName = typeof(T).Name + "s";
        //    var idName = "Id";
        //    var idValue = id;
        //    var param = Expression.Parameter(typeof(T));
        //    var expression =
        //        Expression.Lambda<Func<T, bool>>(
        //                Expression.Equal(
        //                    Expression.Property(param, idName),
        //                    Expression.Constant(idValue, typeof(int))),
        //            param
        //        );

        //    return _unitOfWork.TryGetProperty(entityTypeName)?.TryInvokeMethod<IQueryable<T>>("GetAll")?.Where(expression).FirstOrDefault();
        //}

        public virtual T? GetOneBy<T2>(string PropertyName, T2 value)
        {
            string entityTypeName = typeof(T).Name + "s";
            var idName = PropertyName;
            T2 idValue = value;
            var param = Expression.Parameter(typeof(T));
            var expression =
                Expression.Lambda<Func<T, bool>>(
                        Expression.Equal(
                            Expression.Property(param, idName),
                            Expression.Constant(idValue, typeof(T2))),
                    param
                );
            return _unitOfWork.TryGetProperty(entityTypeName)?.TryInvokeMethod<IQueryable<T>>("GetAll")?.Where(expression).FirstOrDefault();
        }

        public virtual IList<T>? GetManyBy<T2>(string PropertyName, T2 value)
        {
            string entityTypeName = typeof(T).Name + "s";
            var idName = PropertyName;
            T2 idValue = value;
            var param = Expression.Parameter(typeof(T));
            var expression =
                Expression.Lambda<Func<T, bool>>(
                        Expression.Equal(
                            Expression.Property(param, idName),
                            Expression.Constant(idValue, typeof(T2))),
                    param
                );
            return _unitOfWork.TryGetProperty(entityTypeName)?.TryInvokeMethod<IQueryable<T>>("GetAll")?.Where(expression).ToList();
        }


        public virtual void Create(T entity)
        {
            string entityTypeName = typeof(T).Name + "s";
            _unitOfWork.TryGetProperty(entityTypeName)?.TryInvokeMethod("Create", entity);
            _unitOfWork.Commit();
        }

        public virtual void Update(T entity)
        {
            string entityTypeName = typeof(T).Name + "s";
            _unitOfWork.TryGetProperty(entityTypeName)?.TryInvokeMethod("Update", entity);
            _unitOfWork.Commit();
        }

        public virtual void Delete(T entity)
        {
            string entityTypeName = typeof(T).Name + "s";
            _unitOfWork.TryGetProperty(entityTypeName)?.TryInvokeMethod("Delete", entity);
            _unitOfWork.Commit();
        }
    }
}
