using DailyTaskTimeTracker.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DailyTaskTimeTracker.Data.Interfaces
{
    public interface IDailyTaskTimeTrackerRepository
    {
        IQueryable<T> All<T>() where T : class;
        Task<bool> AnyAsync<T>(Expression<Func<T, bool>> expression) where T : class;
        Task<int> CommitChangesAsync();
        Task<int> CountAsync<T>() where T : class;
        Task<int> CountAsync<T>(Expression<Func<T, bool>> expression) where T : class;
        void Delete<T>(T entity) where T : class;
        void Detach<T>(T entity) where T : class;
        ValueTask<T> FindAsync<T>(params object[] keyValues) where T : class;
        Task<T> FirstAsync<T>(Expression<Func<T, bool>> expression) where T : class;
        Task<T> FirstOrDefaultAsync<T>(Expression<Func<T, bool>> expression) where T : class;
        Task LoadAsync<T, TProp>(T entity, Expression<Func<T, TProp>> property) where T : class where TProp : class;
        Task ReloadAsync<T>(T entity) where T : class;
        Task SaveAsync<T>(T entity) where T : class;
        Task<T> SingleAsync<T>(Expression<Func<T, bool>> expression) where T : class;
        Task<T> SingleOrDefaultAsync<T>(Expression<Func<T, bool>> expression) where T : class;
        IQueryable<T> Where<T>(Expression<Func<T, bool>> expression) where T : class;

    }
}
