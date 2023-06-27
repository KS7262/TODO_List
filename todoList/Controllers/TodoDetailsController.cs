using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using todoList.Entities;

namespace todoList.Controllers
{
    [Authorize]
    public class TodoDetailsController : Controller
    {
        private static Todo todo { get; set; }
        public IActionResult TodoDetails(string title)
        {
            List<string> list = new List<string>();
            ViewBag.Title = title;

            todo = DbActionsTodoes.ReadTodoByTitle(title);

            using (StreamReader reader = new StreamReader(todo.Src))
            {
                string line;
                
                while (!reader.EndOfStream)
                {
                    list.Add(line = reader.ReadLine());
                }

            }

            return View(list);
        }
        public IActionResult DeleteTodo()
        {
            System.IO.File.Delete(todo.Src);
            DbActionsTodoes.DeleteTodo(todo);
            return RedirectToAction("HomePage", "Home");
        }
    }
}
