using Microsoft.AspNetCore.Mvc;
using MyFirstApplication.Models;
using Newtonsoft.Json;
using System.Collections;
using System.Configuration;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MyFirstApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var listOfShows = await GetListOfShows();
            var listofShowsViewModel = new List<ListOfShowsViewModel>();

            foreach (var show in listOfShows)
            {
                listofShowsViewModel.Add(new ListOfShowsViewModel
                {
                    imageURL = show.Image.Medium,
                    name = show.Name,
                    rating = show.Rating
                });
                   
            }

            return View(listofShowsViewModel);
        }

        public async Task<IList<Show>> GetListOfShows()
        {
            Uri requestUri = new Uri("https://api.tvmaze.com/shows");
            HttpClient client = new HttpClient();
            client.BaseAddress = requestUri;
            HttpResponseMessage response = await client.GetAsync(requestUri);

            if (response.IsSuccessStatusCode)
            {
                var res = await response.Content.ReadAsStringAsync();
                var showIndex = JsonConvert.DeserializeObject<IList<Show>>(res);
                
                if (showIndex != null)
                {
                    return showIndex;
                }
            }
                
            return new List<Show>();
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
