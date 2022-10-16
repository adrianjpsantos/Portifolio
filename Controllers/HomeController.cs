using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Portifolio.Data;
using Portifolio.Models;

namespace Portifolio.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ApplicationDbContext _context;

    public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        if (_context.Persons == null)
            return NotFound();

        var profile = new Profile();
        profile.SetPerson(_context.Persons.First());
        return View(profile);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult About()
    {
        if (_context.Persons == null)
            return NotFound();
        

        var profile = new Profile();
        profile.SetPerson(_context.Persons.First());

        ViewData["Technologies"] = _context.Technologies?.ToList();
        return View(profile);
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
