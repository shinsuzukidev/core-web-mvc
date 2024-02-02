using Microsoft.AspNetCore.Mvc;
using mvc_app.Models.MyJob.RequestModel;
using mvc_app.Models.MyJob.ViewModels;
using System.ComponentModel;
using System.Net;
using System.Text.Json.Serialization;
using System.Text.Json;
using mvc_app.Sample.Utils;
using mvc_app.Sample.Config;
using Microsoft.CodeAnalysis.Options;
using Microsoft.Extensions.Options;
using System.Configuration;
using mvc_app.Sample.Other;

namespace mvc_app.Controllers
{

    // コントローラに属性ルーティングを設定すると、規則ルーティングより優先されるみたい？
    // https://learn.microsoft.com/ja-jp/aspnet/core/mvc/controllers/routing?view=aspnetcore-6.0#mixed-routing-attribute-routing-vs-conventional-routing 
    [Route("[controller]")]
    public class MyJobController : Controller
    {
        IDateTime _dateTime;
        IConfiguration _configuration;


        public MyJobController(IDateTime datetime, IConfiguration configuration)
        {
            _dateTime = datetime;
            _configuration = configuration;
        }


        [NonAction]
        public string NoIndex()
        {
            // NonAction属性によりアクションから無視される 
            return "hello world!";
        }

        [HttpGet]
        [Route("/[controller]")]
        [Route("[action]")]
        public IActionResult Index()
        {
            // ビューに渡せる。ViewDataも同様
            ViewBag.Name = "sato";
            ViewData["Message"] = "hello world!";

            // コントローラからのDI
            System.Diagnostics.Debug.WriteLine($"Index:{_dateTime.Now}");

            // appsettings.json より取得、初期処理はデフォルトで実行されている
            // todo 全域で使いたいがどうする
            System.Diagnostics.Debug.WriteLine("cn: " + _configuration.GetConnectionString("mvc_appContext"));
            System.Diagnostics.Debug.WriteLine("name: " + _configuration.GetValue<string>("UserSettings:DefaultUser:Name"));
            System.Diagnostics.Debug.WriteLine("name: " + _configuration["UserSettings:DefaultUser:Name"]);

            // todo DIの調査が必要
            var p = new Person("sato", _configuration);

            // 名前を付けるとViews/{controller}/{名前}.cshatml
            // 名前を付けないとViews/{controller}/{action}.cshtml
            return View("Index");   
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult InputAddressForm([FromServices] IDateTime datetime)
        {
            // di
            System.Diagnostics.Debug.WriteLine($"InputAddressForm:{_dateTime.Now}");

            return View("InputAddressForm");
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult Address(string address)
        {
            System.Diagnostics.Debug.WriteLine(address);
            return View("Address", address);
        }


        [HttpPost]
        [Route("[action]")]
        public IActionResult AddressPost(AddressRequestModel req)
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
        [Route("[action]")]
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
        [Route("[action]")]
        public IActionResult ReturnOk()
        {
            return Ok("return ok!");
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult ReturnBadRequest()
        {
            return BadRequest("return 404 error!");
        }

        [HttpGet]
        [Route("[action]")]
        public RedirectToActionResult RedirectHomeIndex()
        {
            return RedirectToAction(actionName:"Index", controllerName:"Home");
        }

        [HttpGet]
        [Route("[action]")]
        public RedirectToActionResult RedirectMyjobIndex()
        {
            return RedirectToAction("Index");
        }
    }
}
