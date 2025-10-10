using System.Text.Json.Serialization;

namespace TvFlixApp.Domain.Models;

public class Links
{
    [JsonPropertyName("self")]
    public Self? Self { get; set; }

    [JsonPropertyName("previousepisode")]
    public Previousepisode? Previousepisode { get; set; }
}