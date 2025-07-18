using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Linq;
using TVBroadcastScheduler.Data;
using TVBroadcastScheduler.Models;
using TVBroadcastScheduler.Models.ViewModel;

namespace TVBroadcastScheduler.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }

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
                var user = _context.Users.FirstOrDefault(u =>
                    u.Username == model.Username &&
                    u.Password == model.Password);

                if (user != null)
                {
                    // Save session
                    HttpContext.Session.SetString("Username", user.Username);
                    HttpContext.Session.SetString("Role", user.Role);

                    // Role-based redirect
                    if (user.Role == "Admin")
                        return RedirectToAction("Users", "Admin");

                    if (user.Role == "Scheduler")
                        return RedirectToAction("Create", "Broadcast");

                    if (user.Role == "Approver")
                        return RedirectToAction("Approvals", "Broadcast");

                    // If role is invalid/fallback
                    return RedirectToAction("Login");
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
