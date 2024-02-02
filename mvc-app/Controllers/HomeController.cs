using Microsoft.AspNetCore.Mvc;
using mvc_app.Models;
using System.Diagnostics;

namespace mvc_app.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // note:
        // "/" または "~/" で始まるアクションに適用されるルート テンプレートは、
        // コントローラーに適用されるルート テンプレートと結合されません。

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
