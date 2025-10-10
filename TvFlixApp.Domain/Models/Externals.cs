using System.Text.Json.Serialization;

namespace TvFlixApp.Domain.Models;

public class Externals
{
    [JsonPropertyName("tvrage")]
    public int? Tvrage { get; set; }

    [JsonPropertyName("thetvdb")]
    public int? Thetvdb { get; set; }

    [JsonPropertyName("imdb")]
    public string? Imdb { get; set; }
}