﻿using ProgressTracker.Domain.Entities;
using ProgressTracker.Domain.Interfaces;

namespace ProgressTracker.Data.Repositories
{
    public class ItemRepository : Repository<Item>, IItemRepository
    {
        public ItemRepository(ApplicationDbContext dbContext)
        : base(dbContext)
        {
        }

        public Task<IEnumerable<Item>> GetTasksByStatus(string orderName)
        {
            throw new NotImplementedException();
        }

        public override void Create(Item entity)
        {
            // Add some specialized functionality here
            base.Create(entity);
        }
    }
}
