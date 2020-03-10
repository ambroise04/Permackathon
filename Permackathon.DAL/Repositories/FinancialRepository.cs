using Microsoft.EntityFrameworkCore;
using Permackathon.DAL.Interfaces;
using Permackathon.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Permackathon.DAL.Repositories
{
    public class FinancialRepository : IFinancialRepository, IRepository<Financial>
    {
        private readonly ApplicationContext Context;

        public FinancialRepository(ApplicationContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public bool Delete(int id)
        {
            if (id <= 0)
                throw new ArgumentNullException("The Id is not in a correct format.");

            var entity = Context.Set<Financial>().Find(id);
            if (entity is null)
                throw new KeyNotFoundException("The Id doesn't match any financial.");

            var tracking = Context.Set<Financial>().Remove(entity);

            return tracking.State == EntityState.Deleted;
        }

        public Financial Get(int id)
        {
            if (id <= 0)
                throw new ArgumentNullException("The Id is not in a correct format.");

            return Context.Financials.FirstOrDefault(a => a.Id == id);
        }

        public ICollection<Financial> GetAll()
        {
            return Context.Financials.Include(f => f.Activity).ToList();
        }

        public Financial Insert(Financial entity)
        {
            if (entity is null)
                throw new ArgumentNullException(nameof(entity));

            if (entity.Id != 0)
                throw new ArgumentNullException("A new financial cannot have an id");

            var tracking = Context.Financials.Add(entity);

            return tracking.Entity;
        }

        public Financial Update(Financial entity)
        {
            if (entity is null)
                throw new ArgumentNullException(nameof(entity));

            if (entity.Id <= 0)
                throw new ArgumentNullException("An existing financial cannot have the supplied id. Please check the city's id.");

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