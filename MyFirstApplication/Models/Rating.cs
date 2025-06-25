using System.Text.Json.Serialization;

namespace MyFirstApplication.Models;

public class Rating
{
    [JsonPropertyName("average")]
    public double? Average { get; set; }
}