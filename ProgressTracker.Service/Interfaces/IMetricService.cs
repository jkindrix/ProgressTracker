using ProgressTracker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgressTracker.Service.Interfaces
{
    public interface IMetricService : IService<Metric>
    {
        public Metric? GetMetricById(int id);
        public List<Metric> GetAllMetrics();
    }
}
