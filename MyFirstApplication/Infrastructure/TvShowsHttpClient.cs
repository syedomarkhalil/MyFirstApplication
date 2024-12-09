using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.Extensions.Options;
using MyFirstApplication.Models;

namespace MyFirstApplication.Infrastructure
{
    // no appsettings injection here, the BaseUri
    // is configured in program.cs

    // using a primary constructor like below, instead of defining a seaparte one
    // this is a new feature of C# 12. You can still define a separate one if needed.
    public class TvShowHttpClient(HttpClient httpClient)
    {
        // define this once as static
        private static readonly JsonSerializerOptions options = new()
        {
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            NumberHandling = JsonNumberHandling.AllowReadingFromString,
        };

        public async Task<IList<TvShow>> GetTvShows()
        {
            // you just call the /shows api, BaseUri is already configured
            var response = await httpClient.GetAsync("/shows");

            if (response.IsSuccessStatusCode)
            {
                var res = await response.Content.ReadAsStringAsync();
                var showIndex = JsonSerializer.Deserialize<IList<TvShow>>(res, options);

                if (showIndex != null)
                {
                    return showIndex;
                }
            }

            return [];
        }
    }
}
