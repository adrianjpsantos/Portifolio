
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Portifolio.Data;

namespace Portifolio.Controllers
{
    public class ProjectsController : Controller
    {

        private readonly ApplicationDbContext _context;

        public ProjectsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            if (_context.Projects == null)
                return NotFound();
            
            var projects = _context.Projects.OrderBy(p => p.IdProject).Include(p => p.Technologies).ThenInclude(t => t.Technology).ToList();
            return View(projects);
        }
    }
}