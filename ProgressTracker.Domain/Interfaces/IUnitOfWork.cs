using ProgressTracker.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgressTracker.Data
{
    public interface IUnitOfWork
    {
        public IItemRepository Items { get; }

        void Commit();
    }
}
