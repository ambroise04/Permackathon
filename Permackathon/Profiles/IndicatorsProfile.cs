using AutoMapper;
using Permackathon.Common.TO;
using Permackathon.DAL.Entities;

namespace Permackathon.Client.Profiles
{
    public class IndicatorsProfile : Profile
    {
        public IndicatorsProfile()
        {
            CreateMap<Indicator, IndicatorTO>();
        }
    }
}