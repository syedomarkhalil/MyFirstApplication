namespace MyFirstApplication.Models;

public class Previousepisode
{
    [JsonProperty("href")]
    public string Href { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }
}