using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

namespace mvc_app.Extensions
{
    public static class ServiceExtensions
    {
        /// <summary>
        /// MVCのコントローラとViewの設定
        /// </summary>
        public static void ConfigMvc(this IServiceCollection service)
        {
            service.AddControllersWithViews(options =>
            {
                // CSRF対策
                options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
            }).
            AddRazorOptions(options =>
            {
                // ビューロケーションを定義
                // options.ViewLocationFormats.Clear();
                // [0]:アクション面
                // [1]:コントローラ名
                // [2]:区分名
                //options.ViewLocationFormats.Add("/Views/{1}/{0}.cshtml");         // デフォルト定義済み
                //options.ViewLocationFormats.Add("/Views/Shared/{0}.cshtml");      // デフォルト定義済み
                options.ViewLocationFormats.Add("/Views/Shared/Layout/{0}.cshtml");
                options.ViewLocationFormats.Add("/Views/Shared/PartialView/{0}.cshtml");
            });

        }
    }
}
