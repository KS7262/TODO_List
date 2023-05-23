using Microsoft.AspNetCore.Mvc;
using todoList.Entities;
using System.IO;

namespace todoList.Controllers
{
    public class HomeController : Controller
    {
        public static User user { private get; set; }
        public IActionResult HomePage()
        {
            List<string> titles = new List<string>();
            using (TodoContext context = new TodoContext())
            {
                foreach (var item in context.Todoes.Where(u => u.User == user))
                {
                    titles.Add(item.Title);
                }
            }

            return View("HomePage", titles);
        }
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult SetNewTodo(string title, List<string> tasks)
        {

            DbActionsTodoes.CreateTodo(new Todo { Title = title, UserId = user.Id, Src = $"wwwroot/UsersFiles/{user.NickName}/{title}.txt"});
            WriteTodoTasks(title, tasks);
            return View("HomePage");
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
