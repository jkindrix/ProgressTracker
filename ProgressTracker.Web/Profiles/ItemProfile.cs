using AutoMapper;
using ProgressTracker.Domain.Entities;
using ProgressTracker.Web.Models;

namespace ProgressTracker.Web.Profiles
{
    public class ItemProfile : Profile
    {
        public ItemProfile()
        {
            CreateMap<ItemCreateViewModel, Item>();
        }
    }
}
