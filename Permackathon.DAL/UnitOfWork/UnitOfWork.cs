using Permackathon.DAL.Interfaces;
using Permackathon.DAL.Repositories;
using System;

namespace Permackathon.DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext Context;

        public UnitOfWork(ApplicationContext context)
        {
            Context = context;
        }

        private bool disposedValue = false;
        private ActivityRepository _activityRepository { get; set; }
        private CityRepository _cityRepository { get; set; }
        private FinancialRepository _financialRepository { get; set; }
        private IndicatorRepository _indicatorRepository { get; set; }
        private SiteRepository _siteRepository { get; set; }

        public IActivityRepository ActivityRepository => _activityRepository ?? new ActivityRepository(Context);
        public ICityRepository CityRepository => _cityRepository ?? new CityRepository(Context);
        public IFinancialRepository FinancialRepository => _financialRepository ?? new FinancialRepository(Context);
        public IIndicatorRepository IndicatorRepository => _indicatorRepository ?? new IndicatorRepository(Context);
        public ISiteRepository SiteRepository => _siteRepository ?? new SiteRepository(Context);

        public void Commit()
        {
            Context.SaveChanges();
            Dispose();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    Context.Dispose();
                }
                disposedValue = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}