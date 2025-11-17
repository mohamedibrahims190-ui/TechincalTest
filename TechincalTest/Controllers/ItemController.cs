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
    }
}
