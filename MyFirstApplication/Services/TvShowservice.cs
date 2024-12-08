using MyFirstApplication.Infrastructure;
using MyFirstApplication.Models;

namespace MyFirstApplication.Services
{
    public class TvShowservice : ITvShowService
    {
        private readonly TvShowHttpClient _client;

        public TvShowservice(TvShowHttpClient client)
        {
            _client = client;
        }

        public async Task<IList<TvShow>> GetTvShows()
        {
            return await _client.GetTvShows();
        }
    }
}