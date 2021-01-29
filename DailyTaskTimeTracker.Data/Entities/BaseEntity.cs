using DailyTaskTimeTracker.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DailyTaskTimeTracker.Data.Entities
{
    public class BaseEntity : IBaseEntity
    {
        public int Id { get; set; }
        public bool Archived { get; set; }
        public DateTime ArchivedDate { get; set; }
    }
}
