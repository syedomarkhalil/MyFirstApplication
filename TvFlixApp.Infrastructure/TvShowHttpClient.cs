using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using TvFlixApp.Application.Contracts;
using TvFlixApp.Application.Models;

namespace TvFlixApp.Infrastructure
{
    public class TvShowHttpClient(HttpClient httpClient, IHttpContextAccessor context) : ITvShowServiceClient
    {
        private static readonly JsonSerializerOptions options = new()
        {
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            NumberHandling = JsonNumberHandling.AllowReadingFromString,
        };

        public async Task<List<TvShow>> GetTvShows()
        {
            var idToken = await context.HttpContext.GetTokenAsync("id_token");

            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", idToken);

            var response = await httpClient.GetAsync("/api/tvshows");

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