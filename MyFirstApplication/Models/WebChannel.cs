using System.Text.Json.Serialization;

namespace MyFirstApplication.Models;

public class WebChannel
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("country")]
    public Country Country { get; set; }

    [JsonPropertyName("officialSite")]
    public string OfficialSite { get; set; }
}
