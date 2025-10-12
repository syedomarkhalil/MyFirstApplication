using System.Text.Json;
using System.Text.Json.Serialization;
using TvFlixApp.Application.Contracts;
using TvFlixApp.Application.Models;

namespace TvFlixApp.Infrastructure
{
    public class TvShowHttpClient(HttpClient httpClient) : ITvShowServiceClient
    {
        private static readonly JsonSerializerOptions options = new()
        {
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            NumberHandling = JsonNumberHandling.AllowReadingFromString,
        };

        public async Task<List<TvShow>> GetTvShows()
        {
            var response = await httpClient.GetAsync("/shows");

            if (response.IsSuccessStatusCode)
            {
                var res = await response.Content.ReadAsStringAsync();
                var showIndex = JsonSerializer.Deserialize<List<TvShow>>(res, options);

                if (showIndex != null)
                {
                    return showIndex;
                }
            }
            return [];
        }
    }
}