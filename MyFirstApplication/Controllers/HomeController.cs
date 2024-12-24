using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MyFirstApplication.Models;
using MyFirstApplication.Services;

namespace MyFirstApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITvShowService _services;
        private readonly IOptions<AppSettings> _settings;

        public HomeController(ILogger<HomeController> logger, ITvShowService services, IOptions<AppSettings> settings)
        {
            _logger = logger;
            _services = services;
            _settings = settings;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int id)
        {
            var pageSize = _settings.Value.PageSize;
            int pageCount;
            List<TvShow> paginatedResult;

            var listOfShows = await _services.GetTvShows();

            GetPagination(id, pageSize, listOfShows, out pageCount, out paginatedResult);

            var model = paginatedResult.Select(show => new TvShowViewModel
            {
                ImageUrl = show.Image.Medium,
                Name = show.Name,
                Rating = show.Rating,
                URL = show.Url
            }).ToList();
            ViewData["PageCount"] = pageCount;

            return View(model);
        }

        private static void GetPagination(int id, int pageSize, List<TvShow> listOfShows, out int pageCount, out List<TvShow> paginatedResult)
        {
            pageCount = (int)Math.Ceiling((double)(listOfShows.Count / pageSize));
            paginatedResult = listOfShows.Skip((id - 1) * pageSize).Take(pageSize).ToList();
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