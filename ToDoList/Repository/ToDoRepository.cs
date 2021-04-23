using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ToDoList.Interface;
using ToDoList.Models;

namespace ToDoList.Repository
{
    public class ToDoRepository : IToDoRepository
    {
        private readonly ToDoContext _context;

        public ToDoRepository(ToDoContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TodoList>> Get()
        {
            return await _context.ToDoList.ToListAsync();
        }

        public async Task<TodoList> GetById(int id)
        {
            return await _context.ToDoList.Where(t => t.Id == id).FirstOrDefaultAsync();
        }

        public async Task Post(TodoList todoList)
        {
            if (todoList == null)
            {
                throw new ArgumentNullException(nameof(todoList));
            }

            await _context.ToDoList.AddAsync(todoList);
            await _context.SaveChangesAsync();
        }

        public async Task Update(TodoList item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            _context.Update(item);
            await _context.SaveChangesAsync();
        }

        public async Task<TodoList> Delete(int id)
        {
            TodoList item = await _context.ToDoList.Where(t => t.Id == id).FirstOrDefaultAsync();

            _context.ToDoList.Remove(item);
            await _context.SaveChangesAsync();

            return item;
        }
    }
}
