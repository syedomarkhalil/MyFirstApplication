﻿namespace MyFirstApplication.Models;

public class Externals
{
    [JsonProperty("tvrage")]
    public int? Tvrage { get; set; }

    [JsonProperty("thetvdb")]
    public int? Thetvdb { get; set; }

    [JsonProperty("imdb")]
    public string? Imdb { get; set; }
}