using ProgressTracker.Common.Extensions;
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

        public IQueryable<Item> GetItemsByStatus(ItemStatus status)
        {
            return _unitOfWork.Items.Get(x => x.Status == status);
        }

        public override void Update(Item entity)
        {
            entity.Status = GetStatus(entity);
            base.Update(entity);
        }

        private static ItemStatus GetStatus(Item entity)
        {
            // If unchanged for 7 days, mark as Idle
            if ((entity.UpdatedAt - DateTime.Now).TotalDays > 7)
            {
                return ItemStatus.Idle;
            }
            // If Progress is at the Goal, mark as Complete
            else if (entity.ProgressMarker == entity.GoalMarker)
            {
                return ItemStatus.Completed;
            }
            // If progress exists, mark as Started
            else if (entity.ProgressMarker > 0)
            {
                return ItemStatus.Started;
            }
            // If no progress, mark as New
            else if (entity.ProgressMarker == 0)
            {
                return ItemStatus.New;
            }
            return entity.Status;
        }
    }
}