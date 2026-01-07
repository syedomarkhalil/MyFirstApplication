using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Serialization;
using TvFlixApp.Application.Contracts;
using TvFlixApp.Application.Models;

namespace TvFlixApp.Infrastructure
{
    
    public class TvShowHttpClient(HttpClient httpClient, IJwtTokenService jwtTokenService) : ITvShowServiceClient
    {
        private static readonly JsonSerializerOptions options = new()
        {
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            NumberHandling = JsonNumberHandling.AllowReadingFromString,
        };
       
        public async Task<List<TvShow>> GetTvShows()
        {
            var token = jwtTokenService.GenerateToken();            

            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
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