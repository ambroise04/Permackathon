using AutoMapper;
using Permackathon.Common.TO;
using Permackathon.DAL.Entities;

namespace Permackathon.API.Profiles
{
    public class IndicatorsProfile : Profile
    {
        public IndicatorsProfile()
        {
            CreateMap<Indicator, IndicatorTO>();
        }
    }
}