# Adding Entities to the project

## Method 1: Using a script

...Coming soon

## Method 2: Manual

1. Add the new *entity class* in **Domain.Entities**

```csharp
namespace ProgressTracker.Domain.Entities;
public class Item
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public Uri? Url { get; set; }
    public int ProgressMarker { get; set; }
    public int GoalMarker { get; set; }
    public ItemStatus Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime LastUpdatedAt { get; set; }
}
```

1. Create a new *repository interface* for the entity in **Domain.Interfaces**

```csharp
using ProgressTracker.Domain.Entities;

namespace ProgressTracker.Domain.Interfaces
{
    public interface IItemRepository : IRepository<Item>
    {
        Task<IEnumerable<Item>> GetTasksByStatus(string orderName);
    }
}
```

1. Create a new *repository implementation class* for the entity in **Data.Repositories**

```csharp
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

        public Task<IEnumerable<Item>> GetTasksByStatus(string orderName)
        {
            throw new NotImplementedException();
        }
    }
}
```

1. Add a reference to the new *repository interface* in the `UnitOfWork` class

```csharp
using ProgressTracker.Data.Repositories;
using ProgressTracker.Domain.Interfaces;

namespace ProgressTracker.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private IItemRepository _items;

        public IItemRepository Items
        {
            get
            {
                return _items ??= new ItemRepository(_context);
            }
        }
    // ...lines omitted
}
```
