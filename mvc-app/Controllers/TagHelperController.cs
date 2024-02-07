using Microsoft.AspNetCore.Mvc;
using mvc_app.Models.TagHelper;
using Microsoft.AspNetCore.Http;
using mvc_app.Extensions;
using mvc_app.Utils;

namespace mvc_app.Controllers
{
    public class TagHelperController : Controller
    {
        public IActionResult Index()
        {
            Logger.Trace("TagHelperController - Index");
            Logger.Info("TagHelperController - Index");
            Logger.Warn("TagHelperController - Index");
            Logger.Error("TagHelperController - Index");
            Logger.Fatal("TagHelperController - Index");

            var model = new RegisterViewModel();
            return View("Index", model);
        }

        [HttpPost]
        public IActionResult MyPostMessage(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                // tempData
                TempData["TestData"] = "test-temp-data";

                // sessionを保存(jsonとして保存）
                var sessionKey = "registmodel";
                HttpContext.Session.Set<RegisterViewModel>(sessionKey, model);
                // sessionを取得
                //if (HttpContext.Session.Get<RegisterViewModel>(sessionKey) != null)
                if (HttpContext.Session.Get<RegisterViewModel>(sessionKey) != default)
                {
                    var regmodel = HttpContext.Session.Get<RegisterViewModel>(sessionKey);
                }

                HttpContext.Session.Clear();


                // 検証がOKならMyPostMessage.cshtmlを表示
                return View("MyPostMessage", model);
            }

            // 検証がNGならIndex.cshtmlを表示
            return View("Index", model);
        }
    }
}

