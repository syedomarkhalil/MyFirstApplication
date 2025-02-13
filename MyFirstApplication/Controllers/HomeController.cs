using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MyFirstApplication.Models;
using MyFirstApplication.Services;

namespace MyFirstApplication.Controllers
{
    [Route("[controller]/[action]")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITvShowService _tvShowService;
        private readonly IOptions<AppSettings> _settings;

        public HomeController(ILogger<HomeController> logger, ITvShowService tvShowService, IOptions<AppSettings> settings)
        {
            _logger = logger;
            _tvShowService = tvShowService;
            _settings = settings;
        }

        [Route("")]
        [Route("~/")]
        [Route("{pageNumber?}", Name = "Get_Shows")]
        public async Task<IActionResult> Index(int pageNumber = 1)
        {
            var pageSize = _settings.Value.PageSize;
            (var listOfShows, int totalPages) = await _tvShowService.GetTvShows(pageNumber, pageSize);

            var model = listOfShows.Select(show => new TvShowViewModel
            {
                ImageUrl = show.Image.Medium,
                Name = show.Name,
                Rating = show.Rating,
                URL = show.Url
            }).ToList();
            ViewData["TotalPages"] = totalPages;
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}