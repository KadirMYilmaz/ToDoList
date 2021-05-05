using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoList.Models;

namespace ToDoList.Interface
{
    public interface IToDoRepository
    {
        Task<IEnumerable<TodoList>> Get();
        Task<TodoList> GetById(int id);
        Task<TodoList> Details(int? id);
        Task Post(TodoList todoList);
        Task Update(TodoList item);
        Task<TodoList> Delete(int id);
    }
}
