namespace TvFlixApp.Domain.Models
{
    public class AppSettings
    {
        public string? BaseUri { get; set; }
        public int PageSize { get; set; }
        public string? GoogleSignOutUrl { get; set; }
        public string? FacebookSignOutUrl { get; set; }
        public AuthenticationSettings? AuthenticationSettings { get; set; }
    }
}