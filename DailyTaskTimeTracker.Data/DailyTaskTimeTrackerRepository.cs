using DailyTaskTimeTracker.Data.Entities;
using DailyTaskTimeTracker.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DailyTaskTimeTracker.Data
{
    public class DailyTaskTimeTrackerRepository : IDailyTaskTimeTrackerRepository
    {
        internal DailyTaskTimeTrackerContext _dailyTimeTrackerContext { get; set; }
        private Dictionary<Type, object> ObjectSets { get; }
        

        public DailyTaskTimeTrackerRepository(IDailyTaskTimeTrackerContext dailyTaskTimeTrackerContext)
        {
            _dailyTimeTrackerContext = dailyTaskTimeTrackerContext as DailyTaskTimeTrackerContext;
            ObjectSets = new Dictionary<Type, object>();
        }

        private DbSet<T> GetObjectSet<T>() where T : class
        {
            var type = typeof(T);

            lock (ObjectSets)
            {
                if (ObjectSets.ContainsKey(type))
                    return ObjectSets[type] as DbSet<T>;

                var objectSet = _dailyTimeTrackerContext.Set<T>();

                ObjectSets[type] = objectSet;

                return objectSet;
            }
        }

        public IQueryable<T> All<T>() where T : class
        {
            return GetObjectSet<T>();
        }

        public async Task<bool> AnyAsync<T>(Expression<Func<T, bool>> expression) where T : class
        {
            return await GetObjectSet<T>().AnyAsync(expression);
        }

        public async Task<int> CommitChangesAsync()
        {
            try
            {
                return await _dailyTimeTrackerContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }

        public async Task<int> CountAsync<T>() where T : class
        {
            return await GetObjectSet<T>().CountAsync();
        }

        public async Task<int> CountAsync<T>(Expression<Func<T, bool>> expression) where T : class
        {
            return await GetObjectSet<T>().CountAsync(expression);
        }

        public void Delete<T>(T entity) where T : class
        {
            GetObjectSet<T>().Remove(entity);
        }

        public void Detach<T>(T entity) where T : class
        {
            var entry = _dailyTimeTrackerContext.Entry(entity);

            if (entry != null)
                entry.State = EntityState.Detached;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_dailyTimeTrackerContext != null)
                {
                    _dailyTimeTrackerContext.Dispose();
                }

                ObjectSets.Clear();
            }
        }

        public async ValueTask<T> FindAsync<T>(params object[] keyValues) where T : class
        {
            return await GetObjectSet<T>().FindAsync(keyValues);
        }

        public async Task<T> FirstAsync<T>(Expression<Func<T, bool>> expression) where T : class
        {
            return await GetObjectSet<T>().FirstAsync(expression);
        }

        public async Task<T> FirstOrDefaultAsync<T>(Expression<Func<T, bool>> expression) where T : class
        {
            return await GetObjectSet<T>().FirstOrDefaultAsync(expression);
        }

        public bool HasPendingChanges()
        {
            var changedStates = new[] { EntityState.Added, EntityState.Modified, EntityState.Deleted };

            return _dailyTimeTrackerContext.ChangeTracker.Entries().Any(entity => changedStates.Contains(entity.State));
        }

        public async Task LoadAsync<T, TProp>(T entity, Expression<Func<T, TProp>> property)
            where T : class
            where TProp : class
        {
            EntityEntry<T> entry = null;
            if (entity != null)
            {
                entry = _dailyTimeTrackerContext.Entry(entity);
            }

            if (entry == null || entry.Entity == null)
                throw new ArgumentNullException(nameof(entity), "repository exception - entry is null");

            ReferenceEntry<T, TProp> reference;

            try
            {
                reference = entry.Reference(property);
            }
            catch (Exception)
            {
                reference = null;
            }

            if (reference == null)
                throw new ArgumentNullException(nameof(entity), "repository exception - reference is null");

            await reference.LoadAsync();
        }


        public async Task ReloadAsync<T>(T entity) where T : class
        {
            var entry = _dailyTimeTrackerContext.Entry(entity);

            await entry.ReloadAsync();
        }

        public async Task SaveAsync<T>(T entity) where T : class
        {
            var set = GetObjectSet<T>();

            // get the entity state
            EntityEntry<T> entry = null;
            try
            {
                entry = _dailyTimeTrackerContext.Entry(entity);
            }
            catch (InvalidOperationException)
            {
                // This will cause entry to be null and throw the not supported exception
            }

            // do we have an entry? - we better do!
            if (entry != null)
            {

                // get the entity key
                var entityKey = _dailyTimeTrackerContext.GetEntityKey(entity);

                // is this a new instance (e.g. we need to insert it)
                if (entityKey == 0)
                {
                    await set.AddAsync(entity);
                    return;
                }

                // is tHis an existing instance (e.g. we need to update it)
                if (entry.State == EntityState.Detached)
                {
                    set.Attach(entity);
                    _dailyTimeTrackerContext.Entry(entity).State = EntityState.Modified;
                    return;
                }

                // we know it's added, modified or deleted (cos it's being tracked) so carry on
                return;
            }

            // dunno who or what you are, so we don't support you
            throw new NotSupportedException($"Object type {entity.GetType().FullName} not support by repository");
        }

        public async Task<T> SingleAsync<T>(Expression<Func<T, bool>> expression) where T : class
        {
            return await GetObjectSet<T>().SingleAsync(expression);
        }

        public async Task<T> SingleOrDefaultAsync<T>(Expression<Func<T, bool>> expression) where T : class
        {
            return await GetObjectSet<T>().SingleOrDefaultAsync(expression);
        }

        public IQueryable<T> Where<T>(Expression<Func<T, bool>> expression) where T : class
        {
            return GetObjectSet<T>().Where(expression);
        }
    }
}
