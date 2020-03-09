using Permackathon.Common.Interfaces;
using Permackathon.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

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
        private IActivityRepository _activityRepository { get; set; }
        private ICityRepository _cityRepository { get; set; }
        private IFinancialRepository _financialRepository { get; set; }
        private IIndicatorRepository _indicatorRepository { get; set; }
        private ISiteRepository _siteRepository { get; set; }

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