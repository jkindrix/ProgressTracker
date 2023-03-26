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
        public Item? GetItemById(int id);
        public List<Item> GetAllItems();
        public IQueryable<Item> GetItemsByStatus(ItemStatus status);
    }
}
