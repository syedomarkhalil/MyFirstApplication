using Newtonsoft.Json;

namespace MyFirstApplication.Models;

public class Self
{
    [JsonProperty("href")]
    public string? Href { get; set; }
}