using Microsoft.AspNetCore.Mvc;
using Portifolio.Data;
using Portifolio.Models;

namespace Portifolio.Controllers
{
    public class ProjectController : Controller
    {

        private readonly ApplicationDbContext _context;

        public ProjectController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Project(int id)
        {
            
            Project project = new();
            project.idProject = id;
            project.title = "Projeto de teste";
            return View(project);
        }
    }
}