namespace TvFlixApp.Application.Models
{
    public class JWTTokenSettings
    {
        public string? JwtSecretKey { get; set; }
        public string? ResourceUrl { get; set; }
        public string? IssuerUrl { get; set; }
    }
}
