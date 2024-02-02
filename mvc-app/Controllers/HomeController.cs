using Microsoft.AspNetCore.Mvc;
using mvc_app.Models;
using System.Diagnostics;

namespace mvc_app.Controllers
{
    //[Route("[controller]/[action]")]
    [Route("[controller]/[action]")]
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
        [Route("~/")]
        [Route("/[controller]")]
        [HttpGet]
        [ActionName("Index")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [ActionName("Privacy")]
        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        [ActionName("Error")]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
