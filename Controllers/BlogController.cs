using Microsoft.AspNetCore.Mvc;

namespace Portifolio.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}