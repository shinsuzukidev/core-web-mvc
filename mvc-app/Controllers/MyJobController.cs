using Microsoft.AspNetCore.Mvc;

namespace mvc_app.Controllers
{
    public class MyJobController : Controller
    {
        public IActionResult Index()
        {
            // ビューに渡せる。ViewDataも同様
            ViewBag.Name = "sato";
            ViewData["Message"] = "hello world!";

            // 名前を付けるとViews/{controller}/{名前}.cshatml
            // 名前を付けないとViews/{controller}/{action}.cshtml
            return View("Index");   
        }
    }
}
