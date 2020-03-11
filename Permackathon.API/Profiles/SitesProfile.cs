using AutoMapper;
using Permackathon.Common.TO;
using Permackathon.DAL.Entities;
using System.Linq;

namespace Permackathon.API.Profiles
{
    public class SitesProfile : Profile
    {
        public SitesProfile()
        {
            CreateMap<Site, SiteTO>().ForMember(
                dest => dest.Activities,
                opt => opt.MapFrom(src => src.ActivitySites.Select(a => a.Activity)));
        }
    }
}