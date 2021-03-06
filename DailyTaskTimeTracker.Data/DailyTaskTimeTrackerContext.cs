﻿using DailyTaskTimeTracker.Data.Entities;
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
        public DailyTaskTimeTrackerContext()
        {
            Database.Migrate();
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
