namespace MyFirstApplication.Models
{
    public class AppSettings
    {
        public string? BaseUri { get; set; }
        public int PageSize { get; set; }
        public Google? GoogleAuthSettings { get; set; }
        public Facebook? FacebookAuthSettings { get; set; }
        public Twitter? TwitterAuthSettings { get; set; }
        public string? GoogleSignOutUrl { get; set; }
    }

    public class Twitter
    {
        public string? ClientId { get; set; }
        public string? ClientSecret { get; set; }
    }

    public class Facebook
    {
        public string? AppId { get; set; }
        public string? AppSecret { get; set; }
    }

    public class Google
    {
        public string? ClientId { get; set; }
        public string? ClientSecret { get; set; }
    }
}