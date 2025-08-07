namespace MyFirstApplication.Models
{
    public class AppSettings
    {
        public string? BaseUri { get; set; }
        public int PageSize { get; set; }
    }

    public class Authentication
    {
        public Google? GoogleSettings { get; set; }
    }

    public class Google
    {
        public string? ClientId { get; set; }
        public string? ClientSecret { get; set; }
        public string? EndPoint { get; set; }
    }
}