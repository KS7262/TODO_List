using Microsoft.AspNetCore.Mvc;

namespace todoList.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult HomePage()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
    }
}
