using TvFlixApp.Domain.Models;

namespace TvFlixApp.Domain.Interfaces
{
    public interface ITvShowService
    {
        public Task<(List<TvShow>, int)> GetTvShows(int pageNumber, int pageSize);
    }
}