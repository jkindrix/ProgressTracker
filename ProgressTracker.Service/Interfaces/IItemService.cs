using ProgressTracker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgressTracker.Service.Interfaces
{
    public interface IItemService : IService<Item>
    {
        public IQueryable<Item> GetItemsByStatus(ItemStatus status);
    }
}
