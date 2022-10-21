using System.Security.Cryptography;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Portifolio.Data;
using Portifolio.Models;
using Microsoft.EntityFrameworkCore;

namespace Portifolio.Controllers
{
    public class AdminController : Controller
    {

        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;


        public AdminController(ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        [HttpGet, AllowAnonymous]
        public IActionResult Index()
        {
            if (HttpContext.User.Identity != null)
            {
                if (HttpContext.User.Identity.IsAuthenticated)
                    return RedirectToAction("Home");
            }

            return View();

        }

        [HttpPost, AllowAnonymous]
        public async Task<IActionResult> Login(User user)
        {
            if (_context.Persons == null)
                return NotFound();

            var person = _context.Persons.Where(p => p.Username.ToUpper() == user.Username.ToUpper() && p.Password == user.Password).FirstOrDefault();
            if (person == null)
            {
                TempData["Erro Login"] = "Usuario e/ou senha estão incorretos!";
                return RedirectToAction("Index", "Admin", user);
            }


            await new Services().Login(HttpContext, person);
            return RedirectToAction("Home");
        }

        [Authorize]
        public async Task<IActionResult> Logoff()
        {
            await new Services().Logoff(HttpContext);
            TempData["Logoff"] = "Voce foi deslogado com sucesso!";
            return RedirectToAction("Index");
        }


        [Authorize]
        public IActionResult Home()
        {
            ViewData["Projects"] = _context.Projects?.ToList();
            ViewData["Technologies"] = _context.Technologies?.ToList();
            ViewData["Name"] = _context.Persons?.First().Name;
            return View();
        }

        [HttpGet, Authorize]
        public IActionResult NewProject()
        {
            ViewData["Technologies"] = new SelectList(_context.Technologies, "IdTechnology", "Name");
            return View();
        }

        [HttpPost, Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NewProject([Bind("IdProject,Title,SubTitle,Description,Thumbnail,Finish,UrlSource,UrlDemo,SelectTechnologies")] Project project, IFormFile file, List<string> SelectTechnologies)
        {
            ViewData["Technologies"] = new SelectList(_context.Technologies, "IdTechnology", "Name");

            if (ModelState.IsValid && _context.Projects != null)
            {
                if (file != null)
                {
                    string wwwRootPath = _hostEnvironment.WebRootPath;
                    string fileName = project.Title + Path.GetExtension(file.FileName);
                    string uploads = Path.Combine(wwwRootPath, @"img\projects");
                    string newFile = Path.Combine(uploads, fileName);
                    using (var stream = new FileStream(newFile, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    project.Thumbnail = @"\img\projects\" + fileName;
                }
                project.Technologies = new List<ProjectTechnology>();
                foreach (var item in SelectTechnologies)
                {
                    project.Technologies.Add(
                        new ProjectTechnology
                        {
                            IdProject = project.IdProject,
                            IdTechnology = int.Parse(item)
                        }
                    );
                }

                _context.Add(project);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Home));
            }
            return View(project);
        }

        [HttpGet, Authorize]
        public IActionResult NewTechnology()
        {
            return View();
        }

        [HttpPost, Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NewTechnology([Bind("IdTechnology,Name,Icon")] Technology technology)
        {
            if (ModelState.IsValid)
            {
                _context.Add(technology);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Home));
            }

            return View(technology);
        }
        [HttpGet, Authorize]
        public async Task<IActionResult> EditTechnology(int? id)
        {
            if (id == null || _context.Technologies == null)
            {
                return NotFound();
            }
            var technology = await _context.Technologies.FindAsync(id);
            if (technology == null)
            {
                return NotFound();
            }

            return View(technology);
        }

        [HttpPost, Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditTechnology(int id, [Bind("IdTechnology,Name,Icon")] Technology technology)
        {
            if (ModelState.IsValid && _context.Technologies != null)
            {
                _context.Technologies.Update(technology);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Home));
            }

            return View(technology);
        }

        [HttpGet, Authorize]
        public async Task<IActionResult> EditProject(int? id)
        {
            if (id == null || _context.Projects == null)
            {
                return NotFound();
            }

            var project = await _context.Projects.Include(p => p.Technologies).ThenInclude(t => t.Technology).Where(p => p.IdProject == id).SingleOrDefaultAsync();

            if (project == null)
            {
                return NotFound();
            }

            ViewData["Technologies"] = new SelectList(_context.Technologies, "IdTechnology", "Name");
            return View(project);
        }

        [HttpPost, Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditProject(int id, [Bind("IdProject,Title,SubTitle,Description,Thumbnail,Finish,UrlSource,UrlDemo,SelectTechnologies")] Project project, IFormFile file, List<string> SelectTechnologies)
        {

            if (ModelState.IsValid && _context.Projects != null)
            {
                try
                {
                    if (file != null)
                    {
                        string wwwRootPath = _hostEnvironment.WebRootPath;
                        if (project.Thumbnail != null)
                        {
                            string oldFile = Path.Combine(wwwRootPath, project.Thumbnail.TrimStart('\\'));
                            if (System.IO.File.Exists(oldFile))
                            {
                                System.IO.File.Delete(oldFile);
                            }
                        }

                        string fileName = project.Title + Path.GetExtension(file.FileName);
                        string uploads = Path.Combine(wwwRootPath, @"img\projects");
                        string newFile = Path.Combine(uploads, fileName);
                        using (var stream = new FileStream(newFile, FileMode.Create))
                        {
                            file.CopyTo(stream);
                        }
                        project.Thumbnail = @"\img\projects\" + fileName;
                    }
                    if (_context.ProjectTechnologies != null)
                    {
                        project.Technologies = _context.ProjectTechnologies.Where(pt => pt.IdProject == project.IdProject).ToList();
                        _context.Projects.Update(project);
                        _context.RemoveRange(project.Technologies);
                        await _context.SaveChangesAsync();
                    }

                    project.Technologies = new List<ProjectTechnology>();
                    foreach (var item in SelectTechnologies)
                    {
                        _context.Add(
                            new ProjectTechnology
                            {
                                IdProject = project.IdProject,
                                IdTechnology = int.Parse(item)
                            }
                        );
                    }
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Home));
            }

            ViewData["Technologies"] = new SelectList(_context.Technologies, "IdTechnology", "Name");
            return View(project);
        }

        [HttpPost, Authorize]
        public async Task<IActionResult> DeleteProject(int id)
        {
            if (_context.Projects == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Projects'  is null.");
            }
            var project = await _context.Projects.FindAsync(id);

            if (project != null && _context.ProjectTechnologies != null)
            {
                project.Technologies = _context.ProjectTechnologies.Where(pt => pt.IdProject == project.IdProject).ToList();
                _context.RemoveRange(project.Technologies);
                _context.Projects.Remove(project);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Home));

        }

        [HttpPost, Authorize]
        public async Task<IActionResult> DeleteTechnology(int id)
        {
            if (_context.Technologies == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Technologies'  is null.");
            }
            var technology = await _context.Technologies.FindAsync(id);
            if (technology != null && _context.ProjectTechnologies != null)
            {
                technology.ProjectsWithTechnology = _context.ProjectTechnologies.Where(pt => pt.IdProject == technology.IdTechnology).ToList();
                _context.RemoveRange(technology.ProjectsWithTechnology);
                _context.Technologies.Remove(technology);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Home));
        }


        public IActionResult EditProfile()
        {
            if (_context.Persons == null)
                return NotFound();

            var profile = new Profile();
            profile.SetPerson(_context.Persons.First());

            return View(profile);
        }

        [HttpPost, Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditProfile(Profile profile)
        {
            if (ModelState.IsValid && _context.Persons != null)
            {
                var person = _context.Persons.FirstOrDefault();

                if (person != null && person.IdPerson == profile.Id)
                {
                    person.UpdatePerson(profile);
                    _context.Persons.Update(person);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Home));
                }
            }

            return View(profile);
        }

        [HttpGet, Authorize]
        public IActionResult EditUser()
        {
            if (_context.Persons == null)
                return NotFound();

            var person = _context.Persons.First();
            var user = new User();
            user.SetPerson(person);

            return View(user);
        }

        [HttpPost, Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditUser(User user)
        {
            if (ModelState.IsValid && _context.Persons != null)
            {
                var person = _context.Persons.First();

                if (person != null && person.IdPerson == user.Id)
                {
                    person.UpdateUser(user);
                    _context.Persons.Update(person);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Logoff");
                }
            }
            return View(user);
        }

        private bool ProjectExists(int id)
        {
            return (_context.Projects?.Any(p => p.IdProject == id)).GetValueOrDefault();
        }

        private bool TechnologyExists(int id)
        {
            return (_context.Technologies?.Any(t => t.IdTechnology == id)).GetValueOrDefault();
        }
    }
}