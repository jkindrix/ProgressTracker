using ProgressTracker.Domain.Entities;
using ProgressTracker.Domain.Interfaces;

namespace ProgressTracker.Data.Repositories
{
    public class ItemRepository : Repository<Item>, IItemRepository
    {
        public ItemRepository(ApplicationDbContext dbContext)
        : base(dbContext)
        {
        }

        public IQueryable<Item> GetItemsByStatus(ItemStatus status)
        {
            return _dbSet.Where(item => item.Status == status);
        }

        public override void Create(Item entity)
        {
            // Add some specialized functionality here
            base.Create(entity);
        }
    }
}
