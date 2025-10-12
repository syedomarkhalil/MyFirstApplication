using TvFlixApp.Application.Models;

namespace TvFlixApp.Application.Contracts;

public interface ITvShowServiceClient
{
    Task<List<TvShow>> GetTvShows();
}