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

        public async Task<List<TvShow>> GetTvShows()
        {
            return await _client.GetTvShows();
        }
    }
}