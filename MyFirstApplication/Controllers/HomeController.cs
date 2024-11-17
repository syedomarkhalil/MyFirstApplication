using Microsoft.AspNetCore.Mvc;
using MyFirstApplication.Models;
using Newtonsoft.Json;
using System.Configuration;
using System.Diagnostics;
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

            Uri requestUri = new Uri("https://www.omdbapi.com/?i=tt3896198&apikey=a5a1b501");
            HttpClient client = new HttpClient();
            client.BaseAddress = requestUri;
            HttpResponseMessage response = await client.GetAsync(requestUri);
            

            if (response.IsSuccessStatusCode)
            {
                var movieResponse = await response.Content.ReadAsStringAsync();
                var movieObject = JsonConvert.DeserializeObject<Movie>(movieResponse);
                var movieCard = MaptoMovie(movieObject);
                var movieViewModel = ToViewModel(movieCard);
                return View(movieViewModel);
            }
            return View();
        }

        private MovieViewModel ToViewModel(Movie movieCard)
        {
            var viewModel = new MovieViewModel
            {
                Actors = movieCard.Actors,
                Director = movieCard.Director,
                Genre = movieCard.Genre,
                Title = movieCard.Title,
                Rated = movieCard.Rated,
                Website = movieCard.Website,
                Writer = movieCard.Writer,
                //ImageUrl = movieCard.Poster
            };
            return viewModel;
            
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public Movie MaptoMovie(Movie contentResponse)
        {
            var movie = new Movie
            {
                Title = contentResponse.Title,
                Year = contentResponse.Year,
                Director = contentResponse.Director,
                Actors = contentResponse.Actors,
                Awards = contentResponse.Awards,
                Genre = contentResponse.Genre,
                Writer = contentResponse.Writer,
                Type = contentResponse.Type,
                imdbRating = contentResponse.imdbRating,
                imdbID = contentResponse.imdbID,
                BoxOffice = contentResponse.BoxOffice,
                Country = contentResponse.Country,
                DVD = contentResponse.DVD,
                imdbVotes = contentResponse.imdbVotes,
                Language = contentResponse.Language,
                Rated = contentResponse.Rated,
                Plot = contentResponse.Plot,
                Poster = contentResponse.Poster,
                Production = contentResponse.Production,
                Ratings = contentResponse.Ratings,
                Released = contentResponse.Released,
                Runtime = contentResponse.Runtime,
                Response = contentResponse.Response,
                Website = contentResponse.Website
            };
            return movie;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
