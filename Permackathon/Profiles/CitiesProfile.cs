using AutoMapper;
using Permackathon.Common.TO;
using Permackathon.DAL.Entities;

namespace Permackathon.Client.Profiles
{
    public class CitiesProfile : Profile
    {
        public CitiesProfile()
        {
            CreateMap<City, CityTO>();
        }
    }
}