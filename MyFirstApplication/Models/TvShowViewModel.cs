namespace MyFirstApplication.Models
{
    public class TvShowViewModel
    {
        public List<TvShows>? TvShows { get; set; }
        public int TotalPages { get; set; }
        public Dictionary<string, string>? TokenInfo { get; set; }
    }

    public class TvShows
    {
        public string? Name { get; set; }
        public Rating? Rating { get; set; }
        public string? ImageUrl { get; set; }
        public string? URL { get; set; }
    }
}