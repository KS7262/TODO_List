using Microsoft.AspNetCore.Mvc;

namespace todoList.Controllers
{
    public class TodoDetailsController : Controller
    {
        public IActionResult TodoDetails()
        {
            return View();
        }
    }
}
