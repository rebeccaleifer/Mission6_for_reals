using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mission6.Models
{
    public class TaskResponse
    {
        [Key]
        [Required]
        public int TaskId { get; set; }

        [Required(ErrorMessage = "Task Description is required")]
        public string TaskDescription { get; set; }

        public DateTime DueDate { get; set; }

        [Required(ErrorMessage = "Quadrant is required")]
        public string Quadrant { get; set; }

        public bool Completed { get; set; }


        //Build Foreign Key Relationship
        public int CategoryId { get; set; }

        public Category Category { get; set; }
    }
}
