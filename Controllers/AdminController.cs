using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.Linq;
using TVBroadcastScheduler.Data;
using TVBroadcastScheduler.Models;

namespace TVBroadcastScheduler.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /Admin/Users - Display all users
        
         
       public IActionResult Users()
   
        {
         
           //if (HttpContext.Session.GetString("Role") != "Admin")
            //{
            //    return Unauthorized(); // Or RedirectToAction("Login", "Account");
            //}

            var users = _context.Users.ToList();
            return View(users);
        }
        
            // POST: /Admin/ChangeRole - Change user's role
            [HttpPost]
        public IActionResult ChangeRole(int userId, string newRole)
        {
            if (HttpContext.Session.GetString("Role") != "Admin")
            {
                return Unauthorized();
            }

            var user = _context.Users.FirstOrDefault(u => u.Id == userId);
            if (user != null && !string.IsNullOrEmpty(newRole))
            {
                user.Role = newRole;
                _context.SaveChanges();
            }

            return RedirectToAction("Users");
        }
        // GET: /Admin/SchedulerDashboard
        public IActionResult SchedulerDashboard()
        {
            // Only Admins can access
            if (HttpContext.Session.GetString("Role") != "Admin")
            {
                return Unauthorized(); // or RedirectToAction("Login", "Account");
            }

            var broadcasts = _context.Broadcasts.ToList();
            var dailyBroadcasts = _context.Broadcasts
                .Where(b => b.Category == "Daily")
                .ToList();

            return View(broadcasts);
        }
      

        // POST: /Admin/DeleteUser - Delete a user
        [HttpPost]
        public IActionResult DeleteUser(int userId)
        {
            if (HttpContext.Session.GetString("Role") != "Admin")
            {
                return Unauthorized();
            }

            var user = _context.Users.FirstOrDefault(u => u.Id == userId);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }

            return RedirectToAction("Users");
        }
    }
}
