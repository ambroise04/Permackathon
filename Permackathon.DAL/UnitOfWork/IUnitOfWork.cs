using Permackathon.DAL.Interfaces;

namespace Permackathon.DAL.UnitOfWork
{
    public interface IUnitOfWork
    {
        IActivityRepository ActivityRepository { get; }
        ICityRepository CityRepository { get; }
        IFinancialRepository FinancialRepository { get; }
        IIndicatorRepository IndicatorRepository { get; }
        ISiteRepository SiteRepository { get; }

        void Commit();
        void Dispose();
    }
}