using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Interface;
using ToDoList.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ToDoList.Controllers
{
    [Controller]
    public class ToDoController : Controller
    {
        private readonly IToDoRepository _repo;

        public ToDoController(IToDoRepository repo)
        {
            _repo = repo;
        }

        // GET: /<controller>/
        public async Task<ActionResult> Index()
        {
            var items = await _repo.Get();

            return View(items);
        }
        
        // GET /todo/create
        public IActionResult Post() => View();

        // POST /todo/create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Post(TodoList item)
        {
            if (ModelState.IsValid)
            {
                await _repo.Post(item);
            }

            return View(item);

        }

        // GET /todo/edit/5
        public async Task<ActionResult> Update(int id)
        {
            // Receiving the specific item
            TodoList item = await _repo.GetById(id);

            if (item == null)
            {
                return NotFound();
            }

            return View(item);

        }

        // PUT /todo/edit/5
        [HttpPut]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Update(TodoList item)
        {
            if (ModelState.IsValid)
            {
                await _repo.Update(item);

                TempData["Success"] = "The item has been updated!";

                return RedirectToAction("Index");
            }

            return View(item);

        }

        // GET /todo/delete/5
        public async Task<ActionResult> Delete(int id)
        {
            // Receiving the specific item
            TodoList item = await _repo.Delete(id);

            if (item == null)
            {
                TempData["Error"] = "The item does not exist!";
            }
            else
            {
                TempData["Success"] = "The item has been deleted!";
            }

            return RedirectToAction("Index");
        }
    }
}
