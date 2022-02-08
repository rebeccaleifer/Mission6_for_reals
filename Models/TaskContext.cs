using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission6.Models
{
    public class TaskContext : DbContext
    {
        //Constructor
        public TaskContext(DbContextOptions<TaskContext> options) : base(options)
        {
            //Leave blank for now
        }

        public DbSet<TaskResponse> Responses { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Home" },
                new Category { CategoryId = 2, CategoryName = "School" },
                new Category { CategoryId = 3, CategoryName = "Work" },
                new Category { CategoryId = 4, CategoryName = "Church" }
            );

            mb.Entity<TaskResponse>().HasData(

                new TaskResponse
                {
                    TaskId = 1,
                    CategoryId = 4,
                    TaskDescription = "Wash the car.",
                    DueDate = new DateTime(2008, 3, 1),
                    Quadrant = 1,
                    Completed = true
                }, 
                new TaskResponse
                {
                    TaskId = 2,
                    CategoryId = 1,
                    TaskDescription = "Sleep.",
                    DueDate = new DateTime(2018, 1, 3),
                    Quadrant = 4,
                    Completed = true
                },
                new TaskResponse
                {
                    TaskId = 3,
                    CategoryId = 3,
                    TaskDescription = "Ask out Kate.",
                    DueDate = new DateTime(2022, 3, 1),
                    Quadrant = 3,
                    Completed = false
                }
            );
        }
    }
}
