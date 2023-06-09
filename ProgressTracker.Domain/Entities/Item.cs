﻿namespace ProgressTracker.Domain.Entities;
public class Item
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public Uri? Url { get; set; }
    public int ProgressMarker { get; set; }
    public int GoalMarker { get; set; }
    public int MetricId { get; set; }
    public Metric? Metric { get; set; }
    public ItemStatus Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
