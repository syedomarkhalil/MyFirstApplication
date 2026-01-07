using TvFlixApp.Application.Contracts;
using TvFlixApp.Application.Extensions;
using TvFlixApp.Application.Models;

namespace TvFlixApp.Services
{
    public class TvShowService : ITvShowService
    {
        private readonly ITvShowServiceClient _client;
        public TvShowService(ITvShowServiceClient client)
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