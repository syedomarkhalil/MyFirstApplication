using Newtonsoft.Json;

namespace MyFirstApplication.Models;

public class Rating
{
    [JsonProperty("average")]
    public double? Average { get; set; }
}