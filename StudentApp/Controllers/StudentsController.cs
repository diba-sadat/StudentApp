using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentApp.Models;

namespace StudentApp.Controllers
{
    public class StudentsController : Controller
    {
        private readonly AppDbContext _context;
        public StudentsController(AppDbContext context)
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

        public IActionResult NotFound()
        {
            return View();
        }

        public async Task<IActionResult> Details(int id)
        {
            var student = await _context.Set<Students>().FirstOrDefaultAsync(s => s.Id == id);
            if (student == null)
            {
                return RedirectToAction(nameof(NotFound));
            }
            return View(student);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var student = await _context.Set<Students>().FirstOrDefaultAsync(s => s.Id == id);
            if (student == null)
            {
                return RedirectToAction(nameof(NotFound));
            }

            _context.Remove(student);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(List));
        }

        public async Task<IActionResult> List()
        {
            var students = await _context.Set<Students>().ToListAsync();
            return View(students);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Students model)
        {
            if (!ModelState.IsValid) return View(model);

            _context.Add(model);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
