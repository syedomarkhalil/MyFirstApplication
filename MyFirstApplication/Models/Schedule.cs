namespace MyFirstApplication.Models;

public class Schedule
{
    [JsonProperty("time")]
    public string Time { get; set; }

    [JsonProperty("days")]
    public IList<string> Days { get; set; }
}