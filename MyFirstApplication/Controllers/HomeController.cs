using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MyFirstApplication.Models;
using MyFirstApplication.Services;

namespace MyFirstApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITvShowService _services;

        public HomeController(ILogger<HomeController> logger, ITvShowService services)
        {
            _logger = logger;
            _services = services;
        }

        public async Task<IActionResult> Index()
        {
            var listOfShows = await _services.GetTvShows();

            var model = listOfShows.Select(show => new TvShowViewModel
            {
                ImageUrl = show.Image.Medium,
                Name = show.Name,
                Rating = show.Rating,
                URL = show.Url
            }).ToList();

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