using AutoMapper;
using Permackathon.Common.TO;
using Permackathon.DAL.Entities;

namespace Permackathon.Client.Profiles
{
    public class FinancialsProfile : Profile
    {
        public FinancialsProfile()
        {
            CreateMap<Financial, FinancialTO>();
        }
    }
}