using ProgressTracker.Domain.Entities;

namespace ProgressTracker.Web.Models
{
    public class MetricViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
    }
}
