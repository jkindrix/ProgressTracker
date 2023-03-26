using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProgressTracker.Domain.Entities;

namespace ProgressTracker.Domain.Interfaces
{
    public interface IItemRepository : IRepository<Item>
    {
        Task<IEnumerable<Item>> GetTasksByStatus(string orderName);
    }
}
