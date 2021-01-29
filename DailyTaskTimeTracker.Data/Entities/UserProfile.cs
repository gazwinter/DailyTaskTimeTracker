using DailyTaskTimeTracker.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DailyTaskTimeTracker.Data.Entities
{
    public class UserProfile : BaseEntity
    {
        
        [Required]
        public string Firstname { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string Email { get; set; }
        public string Hash { get; set; }
        public string Salt { get; set; }
        public string Image { get; set; }

        public ICollection<TaskHistory> TaskHistories { get; set; }
    }
}
