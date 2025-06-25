﻿namespace MyFirstApplication.Models;

public class Country
{
    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("code")]
    public string Code { get; set; }

    [JsonProperty("timezone")]
    public string Timezone { get; set; }
}