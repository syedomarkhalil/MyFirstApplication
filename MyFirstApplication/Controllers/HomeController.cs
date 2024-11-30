using Microsoft.AspNetCore.Mvc;
using MyFirstApplication.Models;
using System.Diagnostics;
using MyFirstApplication.Services;
using Newtonsoft.Json;
using MyFirstApplication.Repository;

namespace MyFirstApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;
        private readonly IServices _services;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration, IServices services)
        {
            _logger = logger;
            _configuration = configuration;
            _services = services;
        }

        public async Task<IActionResult> Index()
        {
            
            
            var listOfShows = await _services.GetListOfShows();

            var listofShowsViewModel = new List<ListOfShowsViewModel>();

            foreach (var show in listOfShows)
            {
                listofShowsViewModel.Add(new ListOfShowsViewModel
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
