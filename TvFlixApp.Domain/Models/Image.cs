using System.Text.Json.Serialization;

namespace TvFlixApp.Domain.Models;

public class Image
{
    [JsonPropertyName("medium")]
    public string? Medium { get; set; }

    [JsonPropertyName("original")]
    public string? Original { get; set; }
}