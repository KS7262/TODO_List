using Microsoft.AspNetCore.Mvc;
using todoList.Entities;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace todoList.Controllers
{
    public class EnterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Registration()
        {
            return View();
        }

        public IActionResult InitRegistration(string nickname, string email, string password)
        {
            if (ModelState.IsValid)
            {
                using (TodoContext context = new TodoContext())
                {
                    var checkUser = context.Users.FirstOrDefault(u => u.NickName == nickname);
                    if (checkUser != null)
                    {
                        return View("Registration");
                    } 
                    else
                    {
                        DbActionsUser.CreateUser(new User { NickName = nickname, Email = email, Password = password});
                        Directory.CreateDirectory($"wwwroot/UsersFiles/{nickname}");
                        HomeController.user = DbActionsUser.ReadByPassword(email, password);
                        return RedirectToAction("HomePage", "Home");
                    }
                }
            }

            return View("Registration");
        }

        public IActionResult Autorization(string email, string password)
        {
            if (DbActionsUser.ReadByPassword(email, password) != null)
            {

                User user = DbActionsUser.ReadByPassword(email, password);
                HomeController.user = user;

                var claims = new List<Claim> { new Claim(ClaimTypes.Name, user.Email) };
                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Cookies");
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                return RedirectToAction("HomePage", "Home");
            }

            return View();
        }
    }
}
