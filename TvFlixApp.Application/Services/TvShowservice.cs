using TvFlixApp.Application.Extensions;
using TvFlixApp.Domain.Interfaces;
using TvFlixApp.Domain.Models;
using TvFlixApp.Domain.TvShowHttpClient;


namespace TvFlixApp.Application.Services
{
    public class TvShowService : ITvShowService
    {
        private readonly TvShowHttpClient _client;

        public TvShowService(TvShowHttpClient client)
        {
            _client = client;
        }

        public async Task<(List<TvShow>, int)> GetTvShows(int pageNumber, int pageSize)
        {
            var listOfShows = await _client.GetTvShows();
            (List<TvShow> paginatedListOfShows, int totalPages) = listOfShows.Pagify(pageNumber, pageSize);
            return (paginatedListOfShows, totalPages);
        }
    }
}