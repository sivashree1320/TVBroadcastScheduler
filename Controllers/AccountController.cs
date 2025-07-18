using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using TVBroadcastScheduler.Models;
using System.Collections.Generic;
using System.Linq;
using TVBroadcastScheduler.Models.ViewModel;

namespace TVBroadcastScheduler.Controllers
{
    public class AccountController : Controller
    {
        //  Hardcoded mock users (temporary)
        private static List<User> users = new List<User>
        {
            new User { Id = 1, Username = "admin", Password = "admin123", Role = "Admin" },
            new User { Id = 2, Username = "scheduler", Password = "sched123", Role = "Scheduler" },
            new User { Id = 3, Username = "approver", Password = "approve123", Role = "Approver" }
        };

        // GET: /Account/Login
        public IActionResult Login()
        {
            return View();
        }

        // POST: /Account/Login
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = users.FirstOrDefault(u =>
                    u.Username == model.Username &&
                    u.Password == model.Password);

                if (user != null)
                {
                    // Save user info in session
                    HttpContext.Session.SetString("Username", user.Username);
                    HttpContext.Session.SetString("Role", user.Role);

                    // Redirect based on role
                    return user.Role switch
                    {
                        "Admin" => RedirectToAction("Users", "Admin"),
                        "Scheduler" => RedirectToAction("Index", "Broadcast"),
                        "Approver" => RedirectToAction("Approvals", "Broadcast"),
                        _ => RedirectToAction("Login")
                    };
                }

                ViewBag.Error = "Invalid username or password.";
            }

            return View(model);
        }
        


        // GET: /Account/Logout
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
