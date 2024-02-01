using mvc_app.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using mvc_app.Data;
using mvc_app.Models;

namespace mvc_app
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            //----------------------------------------
            // 
            builder.Services.AddDbContext<mvc_appContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("mvc_appContext") ?? throw new InvalidOperationException("Connection string 'mvc_appContext' not found.")));

            builder.Services.ConfigMvc();   // mvcの設定





            var app = builder.Build();

            // db初期化
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                SeedData.Initialize(services);
            }


            // Configure the HTTP request pipeline.
            //----------------------------------------
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}