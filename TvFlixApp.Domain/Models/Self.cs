using System.Text.Json.Serialization;

namespace TvFlixApp.Domain.Models;

public class Self
{
    [JsonPropertyName("href")]
    public string? Href { get; set; }
}