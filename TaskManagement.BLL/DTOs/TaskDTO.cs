﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.BLL.DTOs
{
    public class TaskDTO
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? Deadline { get; set; }

        public bool IsCompleted { get; set; }

        public string UserId { get; set; }

        public string CategoryId { get; set; }
    }
}
