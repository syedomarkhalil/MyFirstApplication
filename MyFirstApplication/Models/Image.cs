using Newtonsoft.Json;

namespace MyFirstApplication.Models;

public class Image
{
    [JsonProperty("medium")]
    public string Medium { get; set; }

    [JsonProperty("original")]
    public string Original { get; set; }
}