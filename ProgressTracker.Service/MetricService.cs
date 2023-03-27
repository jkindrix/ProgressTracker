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

        public Metric? GetMetricById(int id)
        {
            return _unitOfWork.Metrics.Get(x => x.Id == id).FirstOrDefault();
        }
        public List<Metric> GetAllMetrics()
        {
            return _unitOfWork.Metrics.GetAll().ToList();
        }
    }
}