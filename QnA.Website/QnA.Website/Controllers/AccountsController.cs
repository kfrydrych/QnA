using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using QnA.Website.Models;
using System.Threading.Tasks;

namespace QnA.Website.Controllers
{
    public class AccountsController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            var model = new LoginViewModel
            {
                ReturnUrl = "/sessions",
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Login(string returnUrl, string provider)
        {
            return Challenge(new AuthenticationProperties { RedirectUri = returnUrl }, provider);
        }

        [HttpGet]
        public async Task Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            Response.Redirect("/");
        }
    }
}