using Microsoft.EntityFrameworkCore;
using Permackathon.DAL.Interfaces;
using Permackathon.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Permackathon.DAL.Repositories
{
    public class SiteRepository : ISiteRepository, IRepository<Site>
    {
        private readonly ApplicationContext Context;

        public SiteRepository(ApplicationContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public bool Delete(int id)
        {
            if (id <= 0)
                throw new ArgumentNullException("The Id is not in a correct format.");

            var entity = Context.Set<Site>().Find(id);
            if (entity is null)
                throw new KeyNotFoundException("The Id doesn't match any site.");

            var tracking = Context.Set<Site>().Remove(entity);

            return tracking.State == EntityState.Deleted;
        }

        public Site Get(int id)
        {
            if (id <= 0)
                throw new ArgumentNullException("The Id is not in a correct format.");

            return Context.Sites.FirstOrDefault(a => a.Id == id);
        }

        public ICollection<Site> GetAll()
        {
            return Context.Sites
                          .Include(s => s.ActivitySites)
                          .ToList();
        }

        public Site Insert(Site entity)
        {
            if (entity is null)
                throw new ArgumentNullException(nameof(entity));

            if (entity.Id != 0)
                throw new ArgumentNullException("A new site cannot have an id");

            var tracking = Context.Sites.Add(entity);

            return tracking.Entity;
        }

        public Site Update(Site entity)
        {
            if (entity is null)
                throw new ArgumentNullException(nameof(entity));

            if (entity.Id <= 0)
                throw new ArgumentNullException("An existing site cannot have the supplied id. Please check the city's id.");

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