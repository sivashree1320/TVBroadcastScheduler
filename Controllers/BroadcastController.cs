using Microsoft.AspNetCore.Mvc;
using TVBroadcastScheduler.Models;
using TVBroadcastScheduler.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;

namespace TVBroadcastScheduler.Controllers
{
    public class BroadcastController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BroadcastController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /Broadcast/Index
        public async Task<IActionResult> Index()
        {
            var broadcasts = await _context.Broadcasts
                .Where(b => b.Status == "Approved")
                .ToListAsync();
            return View(broadcasts);
        }

        // GET: /Broadcast/Add
        public IActionResult Add()
        {
            return View();
        }

        // POST: /Broadcast/Add
        [HttpPost]
        public async Task<IActionResult> Add(Broadcast model)
        {
            if (ModelState.IsValid)
            {
                // Check for time conflict
                bool hasConflict = await _context.Broadcasts
                    .AnyAsync(b =>
                        b.Status == "Approved" &&
                        ((model.StartTime >= b.StartTime && model.StartTime < b.EndTime) ||
                         (model.EndTime > b.StartTime && model.EndTime <= b.EndTime)));

                if (hasConflict)
                {
                    ModelState.AddModelError("", "Schedule overlaps with existing broadcast.");
                    return View(model);
                }

                model.Status = "Pending";
                model.CreatedBy = HttpContext.Session.GetString("Username");
                await _context.Broadcasts.AddAsync(model);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return View(model);
        }

        // GET: /Broadcast/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var item = await _context.Broadcasts.FindAsync(id);
            if (item == null)
                return NotFound();

            return View(item);
        }

        // POST: /Broadcast/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(Broadcast updated)
        {
            var item = await _context.Broadcasts.FindAsync(updated.Id);
            if (item != null)
            {
                item.Title = updated.Title;
                item.Description = updated.Description;
                item.StartTime = updated.StartTime;
                item.EndTime = updated.EndTime;
                item.Status = "Pending"; // Re-approval needed

                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }

        // POST: /Broadcast/Delete/5
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _context.Broadcasts.FindAsync(id);
            if (item != null)
            {
                _context.Broadcasts.Remove(item);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Index");
        }

        // GET: /Broadcast/Approvals
        public async Task<IActionResult> Approvals()
        {
            var pending = await _context.Broadcasts
                .Where(b => b.Status == "Pending")
                .ToListAsync();

            return View(pending);
        }

        // POST: /Broadcast/Approve
        [HttpPost]
        public async Task<IActionResult> Approve(int id, string comment)
        {
            var item = await _context.Broadcasts.FindAsync(id);
            if (item != null)
            {
                item.Status = "Approved";
                item.ApprovalComment = comment;

                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Approvals");
        }

        // POST: /Broadcast/Reject
        [HttpPost]
        public async Task<IActionResult> Reject(int id, string comment)
        {
            var item = await _context.Broadcasts.FindAsync(id);
            if (item != null)
            {
                item.Status = "Rejected";
                item.ApprovalComment = comment;

                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Approvals");
        }
    }
}
