using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Facebook;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication.Twitter;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MyFirstApplication.Models;

namespace MyFirstApplication.Controllers
{
    [Route("[controller]/[action]")]
    public class AccountController : Controller
    {
        private readonly IOptions<AppSettings> _settings;

        public AccountController(IOptions<AppSettings> settings)
        {
            _settings = settings;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public async Task SignInWithGoogle()
        {
            await HttpContext.ChallengeAsync(GoogleDefaults.AuthenticationScheme, new AuthenticationProperties
            {
                RedirectUri = Url.Action("Index", "Home")
            });
        }

        public async Task SignInWithFacebook()
        {
            await HttpContext.ChallengeAsync(FacebookDefaults.AuthenticationScheme, new AuthenticationProperties
            {
                RedirectUri = Url.Action("Index", "Home")
            });
        }

        public async Task SignInWithTwitter()
        {
            await HttpContext.ChallengeAsync(TwitterDefaults.AuthenticationScheme, new AuthenticationProperties
            {
                RedirectUri = Url.Action("Index", "Home")
            });
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            var returnUrl = Url.ActionLink(nameof(Login));
            var redirectUrl = _settings.Value.GoogleSignOutUrl + returnUrl;
            return Redirect(redirectUrl);
        }
    }
}