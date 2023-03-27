using AutoMapper;
using ProgressTracker.Domain.Entities;
using ProgressTracker.Web.Models;

namespace ProgressTracker.Web.Profiles
{
    public class MetricProfile : Profile
    {
        public MetricProfile()
        {
            CreateMap<MetricViewModel, Metric>();
            CreateMap<Metric, MetricViewModel>();
        }
    }
}
