﻿using Microsoft.AspNetCore.Mvc;
using todoList.Entities;

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
                        return RedirectToAction("HomePage", "Home");
                    }
                }
            }

            return View("Registration");
        }

        public IActionResult Autorization()
        {
            return View();
        }
    }
}
