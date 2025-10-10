using System.Text.Json.Serialization;

namespace TvFlixApp.Domain.Models;

public class Rating
{
    [JsonPropertyName("average")]
    public double? Average { get; set; }
}