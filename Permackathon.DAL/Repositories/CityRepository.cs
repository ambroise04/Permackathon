using Microsoft.EntityFrameworkCore;
using Permackathon.Common.Interfaces;
using Permackathon.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Permackathon.DAL.Repositories
{
    public class CityRepository : ICityRepository, IRepository<City>
    {
        private readonly ApplicationContext Context;

        public CityRepository(ApplicationContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public bool Delete(int id)
        {
            if (id <= 0)
                throw new ArgumentNullException("The Id is not in a correct format.");

            var entity = Context.Set<City>().Find(id);
            if (entity is null)
                throw new KeyNotFoundException("The Id doesn't match any city.");

            var tracking = Context.Set<City>().Remove(entity);

            return tracking.State == EntityState.Deleted;
        }

        public City Get(int id)
        {
            if (id <= 0)
                throw new ArgumentNullException("The Id is not in a correct format.");

            return Context.Cities
                          .FirstOrDefault(a => a.Id == id);
        }

        public ICollection<City> GetAll()
        {
            return Context.Cities
                          .ToList();
        }

        public City Insert(City entity)
        {
            if (entity is null)
                throw new ArgumentNullException(nameof(entity));

            if (entity.Id != 0)
                throw new ArgumentNullException("A new city cannot have an id");

            var tracking = Context.Cities.Add(entity);

            return tracking.Entity;
        }

        public City Update(City entity)
        {
            if (entity is null)
                throw new ArgumentNullException(nameof(entity));

            if (entity.Id <= 0)
                throw new ArgumentNullException("An existing city cannot have the supplied id. Please check the city's id.");

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