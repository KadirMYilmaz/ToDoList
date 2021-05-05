using System;
using Microsoft.EntityFrameworkCore;
using ToDoList.Models;

namespace ToDoList
{
    public class ToDoContext : DbContext
    {
        public ToDoContext(DbContextOptions<ToDoContext> options)
            :base(options)
        {
        }

        public DbSet<TodoList> ToDoList { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<TodoList>()
                .Property(p => p.Priority)
                .HasConversion(
                v => v.ToString(),
                v => (PriorityLevel)Enum.Parse(typeof(PriorityLevel), v));
        }
    }
}
