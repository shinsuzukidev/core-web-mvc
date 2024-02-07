using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace mvc_app.Controllers
{
    public class AdminController : Controller
    {
        [HttpGet]
        [Authorize(Roles = "admin")]
        //[Authorize(Roles = "user")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
