using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentApp.Models;

namespace StudentApp.Controllers
{
    public class BooksController : Controller
    {
        private readonly AppDbContext _context;
        public BooksController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var lessons = await _context.Books.ToListAsync();
            return View(Books);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Books model)
        {
            if (!ModelState.IsValid) return View(model);

            _context.Lessons.Add(model);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            var Book = await _context.Lessons.FirstOrDefaultAsync(l => l.Id == id);
            if (Book == null)
            {
                return NotFound();
            }
            return View(Book);
        }

        public async Task<IActionResult> Update(int id)
        {
            var Book = await _context.Lessons.FindAsync(id);
            if (Book == null)
            {
                return NotFound();
            }
            return View(Book);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Book model)
        {
            if (!ModelState.IsValid) return View(model);

            var Book = await _context.Lessons.FindAsync(model.Id);
            if (Book == null)
            {
                return NotFound();
            }

            Book.Name = model.Name;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var Book = await _context.Books.FindAsync(id);
            if (Book == null)
            {
                return NotFound();
            }

            _context.Books.Remove(Book);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
