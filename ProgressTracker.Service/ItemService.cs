using ProgressTracker.Data;
using ProgressTracker.Domain.Entities;

namespace ProgressTracker.Service
{
    public interface IItemService
    {
        public void CreateItem(Item item);
    }

    public class ItemService : IItemService
    {
        public readonly IUnitOfWork _unitOfWork;

        public ItemService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void CreateItem(Item item)
        {
            _unitOfWork.Items.Create(item);
            _unitOfWork.Commit();
        }
    }
}