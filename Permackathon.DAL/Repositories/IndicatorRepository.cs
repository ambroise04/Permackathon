using Microsoft.EntityFrameworkCore;
using Permackathon.Common.Interfaces;
using Permackathon.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Permackathon.DAL.Repositories
{
    public class IndicatorRepository : IIndicatorRepository, IRepository<Indicator>
    {
        private readonly ApplicationContext Context;

        public IndicatorRepository(ApplicationContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public bool Delete(int id)
        {
            if (id <= 0)
                throw new ArgumentNullException("The Id is not in a correct format.");

            var entity = Context.Set<Indicator>().Find(id);
            if (entity is null)
                throw new KeyNotFoundException("The Id doesn't match any indicator.");

            var tracking = Context.Set<Indicator>().Remove(entity);

            return tracking.State == EntityState.Deleted;
        }

        public Indicator Get(int id)
        {
            if (id <= 0)
                throw new ArgumentNullException("The Id is not in a correct format.");

            return Context.Indicators.FirstOrDefault(a => a.Id == id);
        }

        public ICollection<Indicator> GetAll()
        {
            return Context.Indicators.ToList();
        }

        public Indicator Insert(Indicator entity)
        {
            if (entity is null)
                throw new ArgumentNullException(nameof(entity));

            if (entity.Id != 0)
                throw new ArgumentNullException("A new indicator cannot have an id");

            var tracking = Context.Indicators.Add(entity);

            return tracking.Entity;
        }

        public Indicator Update(Indicator entity)
        {
            if (entity is null)
                throw new ArgumentNullException(nameof(entity));

            if (entity.Id <= 0)
                throw new ArgumentNullException("An existing indicator cannot have the supplied id. Please check the city's id.");

            try
            {
                Context.Attach(entity).State = EntityState.Modified;
                return entity;
            }
            catch
            {
                throw;
            }
        }
    }
}