using DailyTaskTimeTracker.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DailyTaskTimeTracker.Data.Entities
{
    public class TaskBreak : BaseEntity
    {
        
        [ForeignKey("History")]
        public int TaskHistoryId { get; set; }
        public TaskHistory History { get; set; }
        public DateTime BreakStart { get; set; }
        public DateTime? BreakFinish { get; set; }
        public TimeSpan TotalBreakTime { get; set; }
    }
}
