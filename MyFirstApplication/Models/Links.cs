using Newtonsoft.Json;

namespace MyFirstApplication.Models;

public class Links
{

    [JsonProperty("self")]
    public Self Self { get; set; }

    [JsonProperty("previousepisode")]
    public Previousepisode Previousepisode { get; set; }
}
