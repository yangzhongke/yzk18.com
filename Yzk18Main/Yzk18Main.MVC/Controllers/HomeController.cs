using Articles.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Yzk18Main.MVC.Models;

namespace Yzk18Main.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IArticleRepository repository;

        public HomeController(ILogger<HomeController> logger, IArticleRepository repository)
        {
            _logger = logger;
            this.repository = repository;
        }

        public async Task<IActionResult> Index()
        {
            var items = await repository.FindPagedAsync(0, 20);
            return View(items);
        }

        public async Task<IActionResult> Article(Guid id)
        {
            var article = await repository.FindByIdAsync(id);
            if (article == null)
            {
                return NotFound($"{id} not found");
            }
            return View(article);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}