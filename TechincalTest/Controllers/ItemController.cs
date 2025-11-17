using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechincalTest.Data;
using TechincalTest.Models;

namespace TechincalTest.Controllers
{
    public class ItemsController : Controller
    {
        private readonly TechincalTestDbContext _context;

        public ItemsController(TechincalTestDbContext context)
        {
            _context = context;
        }

        public IActionResult Dashboard()
        {
            return View();
        }

        public async Task<IActionResult> Index()
        {
            var items = await _context.Users.ToListAsync();
            return View(items);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Users item)
        {
            if (!ModelState.IsValid)
                return View(item);

            _context.Users.Add(item);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return BadRequest();

            var user = await _context.Users.FindAsync(id.Value);
            if (user == null)
                return NotFound();

            return View(user); // opens Views/Items/Edit.cshtml
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(Users user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }

            var existing = await _context.Users.FindAsync(user.Id);
            if (existing == null)
                return NotFound();

            existing.Name = user.Name;
            existing.Role = user.Role;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again.");
                return View(user);
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return NotFound();

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
