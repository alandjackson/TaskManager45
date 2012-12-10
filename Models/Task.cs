using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskManager45.Models
{
    public class Task
    {
        public int TaskId { get; set; }
        public string Description { get; set; }
        public DateTime? CompletedAt { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string Details { get; set; }
        public string TaskType { get; set; }
        public string TaskContext { get; set; }
    }
}