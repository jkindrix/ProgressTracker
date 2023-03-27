using ProgressTracker.Domain.Entities;

namespace ProgressTracker.Web.Models
{
    public class ItemViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public Uri? Url { get; set; }
        public int ProgressMarker { get; set; }
        public int GoalMarker { get; set; }
        public ItemStatus Status { get; set; }
        public int MetricId { get; set; }
        public List<Metric>? Metrics { get; set; }
        public string MetricName { get; set; }
    }
}
