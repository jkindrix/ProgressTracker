using ProgressTracker.Domain.Entities;
using ProgressTracker.Domain.Interfaces;

namespace ProgressTracker.Data.Repositories
{
    public class MetricRepository : Repository<Metric>, IMetricRepository
    {
        public MetricRepository(ApplicationDbContext dbContext)
        : base(dbContext)
        {
        }

        public override void Create(Metric entity)
        {
            // Add some specialized functionality here
            base.Create(entity);
        }
    }
}
