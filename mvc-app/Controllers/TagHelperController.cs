using Microsoft.AspNetCore.Mvc;
using mvc_app.Models.TagHelper;

namespace mvc_app.Controllers
{
    public class TagHelperController : Controller
    {
        public IActionResult Index()
        {
            var model = new RegisterViewModel();
            return View("Index", model);
        }

        [HttpPost]
        public IActionResult MyPostMessage(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                TempData["TestData"] = "test-temp-data";

                // 検証がOKならMyPostMessage.cshtmlを表示
                return View("MyPostMessage", model);
            }

            // 検証がNGならIndex.cshtmlを表示
            return View("Index", model);
        }
    }
}
