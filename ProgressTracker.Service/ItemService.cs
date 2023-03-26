using ProgressTracker.Data;
using ProgressTracker.Domain.Entities;
using ProgressTracker.Service.Interfaces;

namespace ProgressTracker.Service
{
    public class ItemService : Service<Item>, IItemService
    {
        public ItemService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}