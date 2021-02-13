using DailyTaskTimeTracker.Data.Entities;
using DailyTaskTimeTracker.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DailyTaskTimeTracker.Tests
{
    public class DailyTaskTimeTrackerTestContext : DbContext, IDailyTaskTimeTrackerContext
    {
        private const string databaseName = "DailyTaskTimeTracker.db";
        public DailyTaskTimeTrackerTestContext()
        {
            //Database.Migrate();
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            String databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), databaseName);
            optionsBuilder.UseSqlite($"Filename={databasePath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<TaskHistory> TaskHistories { get; set; }
        public DbSet<TaskBreak> TaskBreaks { get; set; }

        internal int GetEntityKey<T>(T entity) where T : class
        {
            var baseEntity = entity as BaseEntity;

            if (baseEntity != null)
            {
                return baseEntity.Id;
            }

            return 0;
        }

    }
}
