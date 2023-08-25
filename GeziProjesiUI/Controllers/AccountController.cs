using GeziProjesiUI.Entities;
using GeziProjesiUI.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NETCore.Encrypt.Extensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace GeziProjesiUI.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly DatabaseContext _databaseContext; // her yerden çağırabilmek için privite olarak kullanılıyor 
        private readonly IConfiguration _configuration;

        public AccountController(DatabaseContext databaseContext, IConfiguration configuration)
        {
            _databaseContext = databaseContext;
            _configuration = configuration;
        }
        [AllowAnonymous]//authorize oldugu için sayfada bu etiketle açık alanları belirledim
        public IActionResult Login()
        {
            return View();
        }
        [AllowAnonymous]//authorize oldugu için sayfada bu etiketle açık alanları belirledim
        [HttpPost]
        public IActionResult Login(LoginViewModels model)
        {
            if (ModelState.IsValid)
            {
                string hashedPassword = DoMD5HashedString(model.Password);

                // kullanıcının yazdığı tuzla md5 e çevir db ile kontrol et
                User user = _databaseContext.Users.SingleOrDefault(x => x.Username.ToLower() == model.Username.ToLower()
                    && x.Password == hashedPassword);

                if (user != null)
                {

                    if (user.Locked) // kullanıcıyı pasife alındıysa 
                    {
                        ModelState.AddModelError(nameof(model.Username), "Kullanıcı Kilitli");
                        return View(model);
                    }

                    List<Claim> claims = new List<Claim>(); // rol verme için de kullanılan çerezler
                    claims.Add(new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()));
                    claims.Add(new Claim(ClaimTypes.Name, user.Namesurname ?? string.Empty));
                    claims.Add(new Claim(ClaimTypes.Role, user.Role));
                    claims.Add(new Claim("Username", user.Username)); // role userin rolunu çekip yazdırıyoruz

                    ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);// ="cookie

                    ClaimsPrincipal principal = new ClaimsPrincipal(identity);

                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal); // bizi içeriye login edecek method
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Kullanıcı adı veya şifre hatalı");
                }

            }
            return View(model);
        }

        private string DoMD5HashedString(string s)
        {
            string md5Salt = _configuration.GetValue<string>("AppSettings:MD5Salt"); // ":" altına geç okumaya devam et demek
            string salted =s + md5Salt;
            string hashed = salted.MD5();
            return hashed;
        }

        [AllowAnonymous]//authorize oldugu için sayfada bu etiketle açık alanları belirledim
        public IActionResult Register()
        {
            return View();
        }

        [AllowAnonymous]//authorize oldugu için sayfada bu etiketle açık alanları belirledim
        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (_databaseContext.Users.Any(x => x.Username.ToLower() == model.Username.ToLower()))
                {
                    ModelState.AddModelError(nameof(model.Username), "kullanıcı adı Kullanılıyor");//kullanıcı adı alınmışsa hata göster
                    return View(model);
                }

                string hashedPassword = DoMD5HashedString(model.Password);
                // kullanıcının aldığını tuzla md5 e çevir db ile kontrol et



                User user = new User() //Burada tablolarımı Modelliyorum yapıyoruz
                {
                    Namesurname = model.Namesurname,
                    Email = model.Email,
                    Username = model.Username,
                    Password = hashedPassword,//şifrelenmiş şekilde çağırmış oldum
                };
                _databaseContext.Users.Add(user); //yeni nesnemi user tablosuna ekledim
                int affectedRowCount = _databaseContext.SaveChanges(); // buraya düştüğünde kayıt olusur
                if (affectedRowCount == 0)
                {
                    ModelState.AddModelError("", "Kullanıcı eklenemedi.");
                }
                else
                {
                    return RedirectToAction(nameof(Login));
                }
            }
            return View(model);
        }
        public IActionResult Profile()
        {
            ProfileInfoLoader();
            return View();
        }

        private void ProfileInfoLoader()
        {
            var userid = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier));
            User user = _databaseContext.Users.SingleOrDefault(x => x.UserId == userid);

            ViewData["Namesurname"] = user.Namesurname;
        }

        [HttpPost]
        public IActionResult ProgileIsimDegistir([Required][StringLength(50)] string? adsoyad)
        {
            if (ModelState.IsValid)
            {
                Guid userid = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier));
                User user = _databaseContext.Users.SingleOrDefault(x => x.UserId == userid);

                user.Namesurname = adsoyad;

                _databaseContext.SaveChanges();

                return RedirectToAction(nameof(Profile));
            }
            ProfileInfoLoader();

            return View("Profile");
        }
        


        [HttpPost]
        public IActionResult ProgileSifreDegistir([Required][MinLength(6)][MaxLength(16)] string? password)  
        {
            if (ModelState.IsValid)
            {
                Guid userid = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier));
                User user = _databaseContext.Users.SingleOrDefault(x => x.UserId == userid);

                string hashedPassword = DoMD5HashedString(password);

                user.Password = hashedPassword;

                _databaseContext.SaveChanges();

                ViewData["result"] = "ŞifreDeğişti";  
            }
            ProfileInfoLoader();

            return View("Profile");
        }

      


        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction(nameof(Login));
        }
    }
}
