using MyFirstApplication.Models;

namespace MyFirstApplication.Services
{
    public interface IServices
    {
        public Task<IList<TvShow>> GetListOfTvShows();
        
    }
}
