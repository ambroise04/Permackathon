using AutoMapper;
using Permackathon.Common.TO;
using Permackathon.DAL.Entities;

namespace Permackathon.API.Profiles
{
    public class FinancialsProfile : Profile
    {
        public FinancialsProfile()
        {
            CreateMap<Financial, FinancialTO>();
        }
    }
}