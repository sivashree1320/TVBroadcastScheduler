using Microsoft.AspNetCore.Mvc;
using TVBroadcastScheduler.Models;
using System.Collections.Generic;
using System.Linq;

namespace TVBroadcastScheduler.Controllers
{
    public class AdminController : Controller
    {
        //  Same mock user list from AccountController
        private static List<User> users = new List<User>
        {
            new User { Id = 1, Username = "admin", Password = "admin123", Role = "Admin" },
            new User { Id = 2, Username = "scheduler", Password = "sched123", Role = "Scheduler" },
            new User { Id = 3, Username = "approver", Password = "approve123", Role = "Approver" }
        };

        // GET: /Admin/Users
        public IActionResult Users()
        {
            return View(users);
        }

        // POST: /Admin/ChangeRole
        [HttpPost]
        public IActionResult ChangeRole(int userId, string newRole)
        {
            var user = users.FirstOrDefault(u => u.Id == userId);
            if (user != null && !string.IsNullOrEmpty(newRole))
            {
                user.Role = newRole;
            }
            return RedirectToAction("Users");
        }

        // POST: /Admin/DeleteUser
        [HttpPost]
        public IActionResult DeleteUser(int userId)
        {
            var user = users.FirstOrDefault(u => u.Id == userId);
            if (user != null)
                users.Remove(user);

            return RedirectToAction("Users");
        }
    }
}
//using Microsoft.AspNetCore.Mvc;
//using TVBroadcastScheduler.Models;
//using TVBroadcastScheduler.Data;  // Add this
//using System.Linq;

//namespace TVBroadcastScheduler.Controllers
//{
//    public class AdminController : Controller
//    {
//        private readonly ApplicationDbContext _context;

//        public AdminController(ApplicationDbContext context)
//        {
//            _context = context;
//        }


//        // POST: /Admin/ChangeRole
//        [HttpPost]
//        public IActionResult ChangeRole(int userId, string newRole)
//        {
//            var user = _context.Users.FirstOrDefault(u => u.Id == userId);
//            if (user != null && !string.IsNullOrEmpty(newRole))
//            {
//                user.Role = newRole;
//                _context.SaveChanges();
//            }
//            return RedirectToAction("Users");
//        }

//        // POST: /Admin/DeleteUser
//        [HttpPost]
//        public IActionResult DeleteUser(int userId)
//        {
//            var user = _context.Users.FirstOrDefault(u => u.Id == userId);
//            if (user != null)
//            {
//                _context.Users.Remove(user);
//                _context.SaveChanges();
//            }
//            return RedirectToAction("Users");
//        }
//    }
//}
