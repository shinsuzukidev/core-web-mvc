using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
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
            });

        }
    }
}
