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

        public Item? GetItemById(int id)
        {
            return _unitOfWork.Items.Get(x => x.Id == id).FirstOrDefault();
        }
        public IQueryable<Item> GetAllItems()
        {
            return _unitOfWork.Items.GetAll();
        }

        public IQueryable<Item> GetItemsByStatus(ItemStatus status)
        {
            return _unitOfWork.Items.Get(x => x.Status ==status);
        }
    }
}