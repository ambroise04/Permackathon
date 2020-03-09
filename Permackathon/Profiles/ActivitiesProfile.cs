using AutoMapper;
using Permackathon.Common.TO;
using Permackathon.DAL.Entities;
using System.Linq;

namespace Permackathon.Client.Profiles
{
    public class ActivitiesProfile : Profile
    {
        public ActivitiesProfile()
        {
            CreateMap<Activity, ActivityTO>().ForMember(
                dest => dest.Sites, 
                opt => opt.MapFrom(src => src.ActivitySites.Select(a => a.Site)));
        }
    }
}