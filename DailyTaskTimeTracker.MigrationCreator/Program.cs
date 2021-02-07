using System;

namespace DailyTaskTimeTracker.MigrationCreator
{
    class Program
    {
        static void Main(string[] args)
        {
            //This project is here purely to allow us to create EF Migrations as you cannot create them from the android project
            //Set this project as the startup project and in the PM Console select DailyTaskTimeTracker.Data as the Default Project
            //Then to create the migrations use the following command in Package Manager Console:
            // Add-Migration -context DailyTaskTimeTracker.Data.DailyTaskTimeTrackerContext <NAME OF MIGRATION> -verbose
            //so for example the initial one was:
            // Add-Migration -context DailyTaskTimeTracker.Data.DailyTaskTimeTrackerContext InitialMigration -verbose
            //Console.WriteLine("Hello World!");
        }
    }
}
