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
            var books = await _context.Books.ToListAsync();
            return View(books);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Book model)
        {
            if (!ModelState.IsValid) return View(model);

            _context.Books.Add(model);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            var book = await _context.Books.FirstOrDefaultAsync(l => l.Id == id);

            if (book is null)
            {
                return NotFound();
                //return BadRequest();
            }

            return View(book);
        }

        public async Task<IActionResult> Update(int id)
        {
            var book = await _context.Books.FindAsync(id);

            if (book is null)
            {
                return NotFound();
            }

            return View(book);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Book model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var book = await _context.Books.FindAsync(model.Id);

            if (book == null)
            {
                return NotFound();
            }

            book.Name = model.Name;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
