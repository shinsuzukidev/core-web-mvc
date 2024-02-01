using Microsoft.AspNetCore.Mvc;
using mvc_app.Models.MyJob.RequestModel;
using mvc_app.Models.MyJob.ViewModels;
using System.ComponentModel;

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


        [HttpGet, ActionName("InputAddressForm")]
        public IActionResult InputAddressForm()
        {
            return View("InputAddressForm");
        }

        [HttpGet, ActionName("AddressGet")]
        public IActionResult Address(string address)
        {
            System.Diagnostics.Debug.WriteLine(address);
            return View("Address", address);
        }


        [HttpPost, ActionName("AddressPost")]
        public IActionResult Address(AddressRequestModel req)
        {
            // todo biz で何らかの処理後にViewModelを作成
            // var vm = (AddressViewModel)xxxBiz(req);
            System.Diagnostics.Debug.WriteLine(req);

            return View("AddressPost", new AddressViewModel {
                City = req.City,
                State = req.State,
                PostCode = req.PostCode,
            });
        }

    }
}
