using System.Text.Json.Serialization;

namespace TvFlixApp.Application.Models;

public class Self
{
    [JsonPropertyName("href")]
    public string? Href { get; set; }
}