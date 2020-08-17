using System;
namespace Tasks.Models
{
    public class Task
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Notes { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime DueTime { get; set; }
        public bool HasCompleted { get; set; }
        public bool HasDeadline => DueTime != null || DueTime != null;
    }
}
