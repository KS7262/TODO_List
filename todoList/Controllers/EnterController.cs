using Microsoft.AspNetCore.Mvc;

namespace todoList.Controllers
{
    public class EnterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Autorization()
        {
            return View();
        }
        public IActionResult Registration()
        {
            return View();
        }
    }
}
