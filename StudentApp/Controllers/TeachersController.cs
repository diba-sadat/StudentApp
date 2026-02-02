using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentApp.Models;

namespace StudentApp.Controllers
{
    public class TeachersController : Controller
    {
        private readonly AppDbContext _context;
        public TeachersController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Update()
        {
            return View();
        }

        public IActionResult CustomNotFound()
        {
            return View();
        }

        public async Task<IActionResult> Details(int id)
        {
            var teacher = await _context.Set<Teachers>().FirstOrDefaultAsync(s => s.Id == id);
            if (teacher == null)
            {
                return RedirectToAction(nameof(NotFound));
            }
            return View(teacher);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var teacher = await _context.Set<Teachers>().FirstOrDefaultAsync(s => s.Id == id);
            if (teacher == null)
            {
                return RedirectToAction(nameof(NotFound));
            }
            _context.Remove(teacher);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(List));
        }

        public async Task<IActionResult> List()
        {
            var teachers = await _context.Set<Teachers>().ToListAsync();
            return View(teachers);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Teachers teacher)
        {
            if (ModelState.IsValid)
            {
                _context.Add(teacher);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(List));
            }
            return View(teacher);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Teachers teacher)
        {
            if (ModelState.IsValid)
            {
                _context.Update(teacher);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(List));
            }
            return View(teacher);
        }

    }
}
