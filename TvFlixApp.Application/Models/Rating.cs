using System.Text.Json.Serialization;

namespace TvFlixApp.Application.Models;

public class Rating
{
    [JsonPropertyName("average")]
    public double? Average { get; set; }
}