namespace ProgressTracker.Web.Models
{
    public class ItemCreateViewModel
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public Uri? Url { get; set; }
        public int GoalMarker { get; set; }
    }
}
