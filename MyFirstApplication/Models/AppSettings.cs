namespace MyFirstApplication.Models
{
    public class AppSettings
    {
        public string? BaseUri { get; set; }
        public int PageSize { get; set; }
        public string? GoogleSignOutUrl { get; set; }
        public AuthenticationSettings? AuthenticationSettings { get; set; }
    }
}