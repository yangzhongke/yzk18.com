using Articles.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Yzk18Main.MVC.Models;
using Zack.ASPNETCore;

namespace Yzk18Main.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IArticleRepository repository;
        private readonly IMemoryCacheHelper cacheHelper;

        public HomeController(ILogger<HomeController> logger, IArticleRepository repository, IMemoryCacheHelper cacheHelper)
        {
            _logger = logger;
            this.repository = repository;
            this.cacheHelper = cacheHelper;
        }

        public async Task<IActionResult> Index()
        {
            var items = await cacheHelper.GetOrCreateAsync("Home_Index", async e => await repository.FindPagedAsync(0, 20));
            return View(items);
        }

        public async Task<IActionResult> Article(Guid id)
        {
            var article = await cacheHelper.GetOrCreateAsync("Home_Article_" + id,
                async e=>await repository.FindByIdAsync(id));
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