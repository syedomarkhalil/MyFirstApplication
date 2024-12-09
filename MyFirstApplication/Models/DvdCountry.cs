using System.Text.Json.Serialization;

namespace MyFirstApplication.Models;

public class DvdCountry
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("code")]
    public string Code { get; set; }

    [JsonPropertyName("timezone")]
    public string Timezone { get; set; }
}
