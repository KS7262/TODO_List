using Microsoft.AspNetCore.Mvc;
using todoList.Entities;
using System.IO;
using Microsoft.AspNetCore.Authorization;

namespace todoList.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public static User user { private get; set; }
        public IActionResult HomePage()
        { 
            return View("HomePage", DbActionsTodoes.GetTodoes(user));
        }
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult SetNewTodo(string title, List<string> tasks)
        {

            DbActionsTodoes.CreateTodo(new Todo { Title = title, UserId = user.Id, Src = $"wwwroot/UsersFiles/{user.NickName}/{title}.txt"});
            WriteTodoTasks(title, tasks);
            return View("HomePage", DbActionsTodoes.GetTodoes(user));
        }

        private async Task WriteTodoTasks(string title, List<string> tasks)
        {
            System.IO.File.Create($"wwwroot/UsersFiles/{user.NickName}/{title}.txt").Close();

            using (StreamWriter writer = new StreamWriter($"wwwroot/UsersFiles/{user.NickName}/{title}.txt"))
            {
                foreach (var task in tasks)
                {
                    await writer.WriteLineAsync(task);
                }
            }
        }

        
    }
}
