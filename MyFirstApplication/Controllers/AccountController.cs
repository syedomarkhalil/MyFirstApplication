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

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            return View();
        }

        public IActionResult SignInWithGoogle(string returnUrl)
        {
            var clientId = "877899375263-m4io06muost8fv7l6k68lugkcr58eicc.apps.googleusercontent.com";
            var redirectUri = returnUrl;
            var url = "https://accounts.google.com/o/oauth2/v2/auth?access_type=online&client_id=" + clientId + "&redirect_uri=" + redirectUri + "&response_type=code&scope=email&prompt=consent";

            HttpContext.Response.Redirect(url, true);

            return View("Login");
        }

        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            //LoginViewModel model = new LoginViewModel
            //{
            //    ReturnUrl = returnUrl,
            //    ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList()
            //};
            return View();
        }

        // GET: AccountController
        public ActionResult Index()
        {
            return View();
        }
    }
}