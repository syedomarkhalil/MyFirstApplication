using MyFirstApplication.Extensions;
using MyFirstApplication.Infrastructure;
using MyFirstApplication.Models;

namespace MyFirstApplication.Services
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
            (List<TvShow> paginatedListOfShows, int totalPages) = listOfShows.Pagination(pageNumber, pageSize);
            return (paginatedListOfShows, totalPages);
        }
    }
}