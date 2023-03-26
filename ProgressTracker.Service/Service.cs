using ProgressTracker.Common.Extensions;
using ProgressTracker.Data;
using ProgressTracker.Domain.Entities;
using ProgressTracker.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgressTracker.Service
{
    public abstract class Service<T> : IService<T> where T : class
    {
        public readonly IUnitOfWork _unitOfWork;

        public Service(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Create(T entity)
        {
            string entityTypeName = typeof(T).Name + "s";
            _unitOfWork.TryGetProperty(entityTypeName)?.TryInvokeMethod("Create", entity);
            _unitOfWork.Commit();
        }

        public void Update(T entity)
        {
            string entityTypeName = typeof(T).Name + "s";
            _unitOfWork.TryGetProperty(entityTypeName)?.TryInvokeMethod("Update", entity);
            _unitOfWork.Commit();
        }

        public void Delete(T entity)
        {
            string entityTypeName = typeof(T).Name + "s";
            _unitOfWork.TryGetProperty(entityTypeName)?.TryInvokeMethod("Delete", entity);
            _unitOfWork.Commit();
        }
    }
}
