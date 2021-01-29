using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DailyTaskTimeTracker.Data.Entities
{
    public class TaskHistory : BaseEntity
    {        
        
        
        [ForeignKey("User")]
        public int UserProfileId { get; set; }
        public UserProfile User { get; set; }
        public string TaskName { get; set; }
        public bool Repeatable { get; set; }
        public DateTime Started { get; set; }
        public DateTime Ended { get; set; }
        public DateTime DateStarted { get; set; }
        public TimeSpan TotalTime { get; set; }        

        public ICollection<TaskBreak> Breaks { get; set; } 
    }
}
