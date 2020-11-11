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
    }
}
