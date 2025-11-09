using TvFlixApp.Application.Models;

namespace TvFlixApp.Application.Contracts
{
    public interface ITvShowService
    {
        public Task<(List<TvShow>, int)> GetTvShows(int pageNumber, int pageSize);
    }
}