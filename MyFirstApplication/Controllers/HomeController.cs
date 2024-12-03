using Microsoft.AspNetCore.Mvc;
using MyFirstApplication.Models;
using System.Diagnostics;
using MyFirstApplication.Services;



namespace MyFirstApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IServices _services;

        public HomeController(ILogger<HomeController> logger, IServices services)
        {
            _logger = logger;
            _services = services;
        }

        public async Task<IActionResult> Index()
        {   
            var listOfShows = await _services.GetListOfTvShows();

            var listofShowsViewModel = new List<ListOfTvShowsViewModel>();

            foreach (var show in listOfShows)
            {
                listofShowsViewModel.Add(new ListOfTvShowsViewModel
                {
                    ImageURL = show.Image.Medium,
                    Name = show.Name,
                    Rating = show.Rating,
                    URL = show.Url
                });

            }

            return View(listofShowsViewModel);
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
