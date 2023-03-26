using ProgressTracker.Data;
using ProgressTracker.Domain.Entities;
using ProgressTracker.Service.Interfaces;

namespace ProgressTracker.Service
{
    public class ItemService : Service<Item>, IItemService
    {
        public ItemService(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        //public void CreateItem(Item item)
        //{
        //    _unitOfWork.Items.Create(item);
        //    _unitOfWork.Commit();
        //}

        //public void UpdateItem(Item item)
        //{
        //    _unitOfWork.Items.Update(item);
        //    _unitOfWork.Commit();
        //}

        //public void DeleteItem(Item item)
        //{
        //    _unitOfWork.Items.Delete(item);
        //    _unitOfWork.Commit();
        //}

    }
}