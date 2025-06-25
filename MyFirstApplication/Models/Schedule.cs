using System.Text.Json.Serialization;

namespace MyFirstApplication.Models;

public class Schedule
{
    [JsonPropertyName("time")]
    public string Time { get; set; }

    [JsonPropertyName("days")]
    public IList<string> Days { get; set; }
}