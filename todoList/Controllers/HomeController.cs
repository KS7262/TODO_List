using Microsoft.AspNetCore.Mvc;

namespace todoList.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult HomePage()
        {
            return View("HomePage");
        }
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult SetNewTodo(string title, List<string> tasks)
        {
            foreach (var task in tasks)
            {
                Console.WriteLine(task);
            }
            return View("HomePage");
        }
    }
}
