using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Configuration;
using mvc_app.Sample.Config;

namespace mvc_app.Extensions
{
    public static class ServiceExtensions
    {
        /// <summary>
        /// MVCのコントローラとViewの設定
        /// </summary>
        public static void ConfigureMvc(this IServiceCollection service)
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

        /// <summary>
        /// 設定ファイルを読込
        /// </summary>
        public static void ConfigureSettings(this IServiceCollection services) 
        {
            // use 1
            //var config = new ConfigurationBuilder()
            //    .SetBasePath(Directory.GetCurrentDirectory())
            //    .AddJsonFile("sampleWebSettings.json", optional: false)
            //    .Build();
            // 
            //string AppName1 = config.GetValue<string>("AppName");
            //string AppName2 = config["AppName"];

            // use 2
            //var config = new ConfigurationBuilder()
            //    .SetBasePath(Directory.GetCurrentDirectory())
            //    .AddJsonFile("appWebSettings.json", optional: false)
            //    .Build();

            //// 全体を取り込み、部分的に取り込みも可能
            //// todo 全域で参照したいがどうする
            //var appWebSettings = config.Get<AppWebSettings>();

        }
    }
}
