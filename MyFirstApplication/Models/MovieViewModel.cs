namespace MyFirstApplication.Models
{
    public class MovieViewModel
    {
        
        public required string Title { get; set; }
        public string? Actors { get; set; } = string.Empty;
        public string? Director { get; set; } = string.Empty;
        public string? Writer {  get; set; } = string.Empty;
        public string? Genre { get; set; } = string.Empty;
        public string? Rated {  get; set; }
        public string? Website { get; set; } = string.Empty;
        public string? ImageUrl { get; set; } = string.Empty;

    }
}
