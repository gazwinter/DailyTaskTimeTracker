using DailyTaskTimeTracker.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using Xamarin.Forms;
using System.IO;
using DailyTaskTimeTracker.Data.Interfaces;

namespace DailyTaskTimeTracker.Data
{
    public class DailyTaskTimeTrackerContext : DbContext, IDailyTaskTimeTrackerContext
    {
        private const string databaseName = "DailyTaskTimeTracker.db";
        protected DailyTaskTimeTrackerContext()
        {
        }

        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            String databasePath = "";
            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    SQLitePCL.Batteries_V2.Init();
                    databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "..", "Library", databaseName); ;
                    break;
                case Device.Android:
                    databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), databaseName);
                    break;
                default:
                    throw new NotImplementedException("Platform not supported");
            }
            // Specify that we will use sqlite and the path of the database here
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

            if(baseEntity != null)
            {
                return baseEntity.Id;
            }

            return 0;
        }

    }
}
