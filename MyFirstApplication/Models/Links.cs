using System.Text.Json.Serialization;

namespace MyFirstApplication.Models;

public class Links
{
    [JsonPropertyName("self")]
    public Self? Self { get; set; }

    [JsonPropertyName("previousepisode")]
    public Previousepisode? Previousepisode { get; set; }
}