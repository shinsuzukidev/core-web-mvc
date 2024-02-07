using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using mvc_app.Models.Account;
using mvc_app.Utils;
using System.Security.Claims;

namespace mvc_app.Controllers
{
    public class AccountController : Controller
    {
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login()
        {
            TempData["ReturnUrl"] = Request.Query["ReturnUrl"].ToString();
            return View(viewName: "LoginDisplay");
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(AccountModel model)
        {
            // モデルのチェック
            if (!ModelState.IsValid)
            {
                return View("LoginDisplay");
            }

            // サーバー側で独自にエラーをチェック、結果を返す場合
            if (model.UserId == "ngngng")
            {
                // キーを指定すると関連する場所に表示される
                ModelState.AddModelError("UserID", "UserID is False.");
                ModelState.AddModelError("Password", "Password False.");
                // キーを指定しない場合は validation-summaryに表示される
                ModelState.AddModelError("", "cutrom error!");
                return View("LoginDisplay");
            }

            // 認証作成
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, model.UserId!));
            //claims.Add(new Claim(ClaimTypes.Role, "admin"));
            claims.Add(new Claim(ClaimTypes.Role, "user"));
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);
            // 暗号化された認証cookieをレスポンスに追加
            await HttpContext?.SignInAsync(principal)!;


            // ReturnUrlの有無でリダイレクト先を変更
            var ReturnUrl = TempData["ReturnUrl"]?.ToString() ?? string.Empty;
            if (string.IsNullOrEmpty(ReturnUrl))
            {
                return RedirectToAction("Index", "Home");
            }

            return Redirect(ReturnUrl);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            // 認証Cookieをレスポンスから削除
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }

        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
