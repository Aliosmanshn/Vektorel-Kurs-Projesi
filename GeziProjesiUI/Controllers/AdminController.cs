using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GeziProjesiUI.Controllers
{
    [Authorize(Roles ="admin")]//admin olanlar girebilir birden fazla rol verebiliriz
    //[Authorize(Roles = "admin", AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]

    public class AdminController : Controller
    {
        //[Authorize] tüm sayfalara bakmasını istemiyorsan tek tek ver
        public IActionResult Index()
        {
            return View();
        }
    }
}
