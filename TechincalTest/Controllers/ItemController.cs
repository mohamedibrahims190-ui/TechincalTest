using Microsoft.AspNetCore.Mvc;
using TechincalTest.Models;

namespace TechincalTest.Controllers
{
    public class ItemsController : Controller
    {
        // Simple in-memory store for demo purposes
        private static readonly List<Item> _items = new List<Item>
        {
            new Item { Id = 1, Name = "Sample Item", Description = "This is a sample." }
        };

        public IActionResult Dashboard()
        {
            return View();
        }

        // GET: /Items or /
        public IActionResult Index()
        {
            return View(_items);
        }

        // GET: /Items/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Items/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Item item)
        {
            if (!ModelState.IsValid)
            {
                return View(item);
            }

            item.Id = _items.Any() ? _items.Max(i => i.Id) + 1 : 1;
            _items.Add(item);

            return RedirectToAction(nameof(Index));
        }
    }
}
