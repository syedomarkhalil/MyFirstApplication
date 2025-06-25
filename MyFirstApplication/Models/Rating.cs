namespace MyFirstApplication.Models;

public class Rating
{
    [JsonProperty("average")]
    public double? Average { get; set; }
}