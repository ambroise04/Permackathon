using Microsoft.EntityFrameworkCore;
using Permackathon.DAL.Entities;
using Permackathon.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Permackathon.DAL.Repositories
{
    public class ActivityRepository : IActivityRepository, IRepository<Activity>
    {
        private ApplicationContext Context;

        public ActivityRepository(ApplicationContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public bool Delete(int id)
        {
            if (id <= 0)
                throw new ArgumentNullException("The Id is not in a correct format.");

            var entity = Context.Set<Activity>().Find(id);
            if (entity is null)
                throw new KeyNotFoundException("The Id doesn't match any activity.");

            var tracking = Context.Set<Activity>().Remove(entity);

            return tracking.State == EntityState.Deleted;
        }

        public Activity Get(int id)
        {
            if (id <= 0)
                throw new ArgumentNullException("The Id is not in a correct format.");

            return Context.Activities
                          .Include(a => a.ActivitySites)
                          .FirstOrDefault(a => a.Id == id);
        }

        public ICollection<Activity> GetAll()
        {
            return Context.Activities
                          .Include(a => a.ActivitySites)
                          .ToList();
        }

        public Activity Insert(Activity entity)
        {
            if (entity is null)
                throw new ArgumentNullException(nameof(entity));

            if (entity.Id != 0)
                throw new ArgumentNullException("A new activity cannot have an id");

            var tracking = Context.Activities.Add(entity);
            return tracking.Entity;
        }

        public Activity Update(Activity entity)
        {
            if (entity is null)
                throw new ArgumentNullException(nameof(entity));

            if (entity.Id <= 0)
                throw new ArgumentNullException("An existing activity cannot have the supplied id. Please check the activity's id.");

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