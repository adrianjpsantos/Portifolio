﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Portifolio.Data;
using Portifolio.Models;
using Portifolio.ViewsModels;

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
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Skills()
    {
        ViewData["Person"] = _context.persons?.ToList()[0];
        ViewData["Technologies"] = _context.technologies?.ToList();
        return View();
    }

    [HttpGet]
    public IActionResult Login()
    {
        ViewData["Person"] = _context.persons?.ToList()[0];
        ViewData["Technologies"] = _context.technologies?.ToList();
        return View();
    }

    [HttpPost]
    public IActionResult Login(Login login)
    {
        var l = login;
        l.email = "adr@adr.com";
        return View(l);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
