using System.Net.Http.Headers;
using System.Reflection.Metadata;
using System.Security.Claims;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using TvFlixApp.Application.Contracts;
using TvFlixApp.Application.Models;



namespace TvFlixApp.Infrastructure
{
    
    public class TvShowHttpClient(HttpClient httpClient, IJwtTokenService jwtTokenService, IHttpContextAccessor context) : ITvShowServiceClient
    {
        
        private static readonly JsonSerializerOptions options = new()
        {
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            NumberHandling = JsonNumberHandling.AllowReadingFromString,
        };
       
        public async Task<List<TvShow>> GetTvShows()
        {
            var accessToken = await context.HttpContext.GetTokenAsync("access_token");
            
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
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