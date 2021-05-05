using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ToDoList.Models
{
    public partial class TodoList
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [StringLength(500)]
        public string Description { get; set; }

        public bool IsComplete { get; set; }

        public PriorityLevel Priority { get; set; }
    }

    public enum PriorityLevel {
        None = 0,
        Low = 1,
        Medium = 2,
        High = 3
    }
}
