using MyFirstApplication.Models;

namespace MyFirstApplication.Services
{
    public interface ITvShowService
    {
        public Task<IList<TvShow>> GetTvShows();
    }
}