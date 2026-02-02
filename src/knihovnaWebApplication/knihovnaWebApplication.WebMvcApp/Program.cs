using Microsoft.AspNetCore.Authentication.Cookies;

namespace knihovnaWebApplication.WebMvcApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // 1. èást -> konfigování pøihlašování pomocí cookies!!!!
            builder.Services
                .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options => {
                    options.LoginPath = "/Auth/Login";
                    //options.LogoutPath = "/Auth/Logout";
                    //options.AccessDeniedPath = "/Auth/Denied";

                    options.Cookie.HttpOnly = true; //dùležitý -> cookie se nedá èíst v js
                    options.Cookie.SameSite = SameSiteMode.Lax; //cookie funguje jenom ve stejný stránce, v rámci domény (?)
                });


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            //2. èást - zapnutí autentizace - dùležité poøadí
            app.UseAuthentication();    //kdo jsme?, tímhle to "zapnu", zkontroluje jestli jsem pøihlášená a zkontroluje jestli jsou nìjaký parametry pro pøihlášení 
            app.UseAuthorization();     //èím jsme? (jaké role?)

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
