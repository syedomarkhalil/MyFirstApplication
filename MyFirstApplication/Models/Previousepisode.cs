using System.Text.Json.Serialization;

namespace MyFirstApplication.Models;

public class Previousepisode
{
    [JsonPropertyName("href")]
    public string? Href { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }
}