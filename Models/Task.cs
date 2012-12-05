using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskManager45.Models
{
    public class Task
    {
        public string Description { get; set; }
        public DateTime? CompletedAt { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}