using AutoMapper;
using Permackathon.Common.TO;
using Permackathon.DAL.Entities;

namespace Permackathon.API.Profiles
{
    public class CitiesProfile : Profile
    {
        public CitiesProfile()
        {
            CreateMap<City, CityTO>();
        }
    }
}