using MyFirstApplication.Models;

namespace MyFirstApplication.Repository
{
    public interface IServices
    {
        public Task<IList<Show>> GetListOfShows();
    }
}
