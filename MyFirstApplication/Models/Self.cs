using System.Text.Json.Serialization;

namespace MyFirstApplication.Models;

public class Self
{
    [JsonPropertyName("href")]
    public string? Href { get; set; }
}