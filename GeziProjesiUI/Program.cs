using GeziProjesiUI.Entities;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

namespace GeziProjesiUI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();             
            builder.Services.AddDbContext<DatabaseContext>( opts =>
            {
                //App sattingden Oku Getir Demek
                opts.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
                
            });
            builder.Services
                .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(opts =>
                {
                    opts.Cookie.Name = "GeziProjesiUI";
                    opts.ExpireTimeSpan=TimeSpan.FromDays(15);//15 g�nde bir cookileri yenile
                    opts.SlidingExpiration = false;// kukie s�relerinin uzamas�n� sa�lar
                    opts.LoginPath = "/Account/Login";//Logine oto y�nlendirme
                    opts.LogoutPath = "/Account/Logout";
                    opts.AccessDeniedPath = "/Home/AccessDenied";//yetkisi olmad�g�nda gidece�i sayfa
                });
            

            
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}