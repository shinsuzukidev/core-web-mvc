using Microsoft.AspNetCore.Mvc;
using mvc_app.Models.MyJob.RequestModel;
using mvc_app.Models.MyJob.ViewModels;
using System.ComponentModel;
using System.Net;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace mvc_app.Controllers
{
    [Route("[controller]/[action]")]
    public class MyJobController : Controller
    {
        [NonAction]
        public string NoIndex()
        {
            // NonAction属性によりアクションから無視される 
            return "hello world!";
        }

        [HttpGet]
        [Route("/[controller]")]
        [ActionName("Index")]
        public IActionResult Index()
        {
            // ビューに渡せる。ViewDataも同様
            ViewBag.Name = "sato";
            ViewData["Message"] = "hello world!";

            // 名前を付けるとViews/{controller}/{名前}.cshatml
            // 名前を付けないとViews/{controller}/{action}.cshtml
            return View("Index");   
        }

        [HttpGet]
        [ActionName("InputAddressForm")]
        public IActionResult InputAddressForm()
        {
            return View("InputAddressForm");
        }

        [HttpGet]
        [ActionName("AddressGet")]
        public IActionResult Address(string address)
        {
            System.Diagnostics.Debug.WriteLine(address);
            return View("Address", address);
        }


        [HttpPost]
        [ActionName("AddressPost")]
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

        [HttpGet]
        [ActionName("FakeApi")]
        public IActionResult FakeApi()
        {
            // mvc画面からjsonを返す
            return new JsonResult(
                new 
                {
                    Name = "sato",
                    Age= 30
                },
                new JsonSerializerOptions
                {
                    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
# if DEBUG
                    WriteIndented = true,
# endif
                });
        }

        [HttpGet]
        [ActionName("ReturnOk")]
        public IActionResult ReturnOk()
        {
            return Ok("return ok!");
        }

        [HttpGet]
        [ActionName("ReturnBadRequest")]
        public IActionResult ReturnBadRequest()
        {
            return BadRequest("return 404 error!");
        }

        [HttpGet]
        [ActionName("RedirectHomeIndex")]
        public RedirectToActionResult RedirectHomeIndex()
        {
            return RedirectToAction(actionName:"Index", controllerName:"Home");
        }

        [HttpGet]
        [ActionName("RedirectMyjobIndex")]
        public RedirectToActionResult RedirectMyjobIndex()
        {
            return RedirectToAction("Index");
        }
    }
}
