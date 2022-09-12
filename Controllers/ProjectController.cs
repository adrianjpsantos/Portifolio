using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(ViewsInfo info)
        {
            //TempData["ProjectInfo"] = _context.projects?.ToList().DistinctBy(p => p.idProject == info.idProject);
            Project project = new();
            project.idProject = info.idProject;
            project.title = "Projeto de teste";

            ViewData["ProjectInfo"] = project;
            return Redirect("/Project/Project");
        }


        public IActionResult Project()
        {
            Project? project = ViewData["ProjectInfo"] as Project;
            ViewData["Title"] = project?.title + project?.idProject;
            return View();
        }
    }
}