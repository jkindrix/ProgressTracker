using ProgressTracker.Data;
using ProgressTracker.Domain.Entities;
using ProgressTracker.Service.Interfaces;

namespace ProgressTracker.Service
{
    public class MetricService : Service<Metric>, IMetricService
    {
        public MetricService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}