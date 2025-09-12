namespace MyFirstApplication.Models
{
    public class AppSettings
    {
        public string? BaseUri { get; set; }
        public int PageSize { get; set; }
        public string? GoogleSignOutUrl { get; set; }
        public AuthenticationSettings? AuthenticationSettings { get; set; }
    }

    public class AuthenticationSettings
    {
        public Facebook? Facebook { get; set; }
        public Twitter? Twitter { get; set; }
        public Google? Google { get; set; }
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