using System.Text.Json;
using Microsoft.Extensions.Options;
using MyFirstApplication.Models;

namespace MyFirstApplication.Infrastructure
{
    public class TvShowHttpClient
    {
        private readonly HttpClient _httpClient;
        private readonly AppSettings _appSettings;

        public TvShowHttpClient(HttpClient httpClient, IOptions<AppSettings> appSettings)
        {
            _httpClient = httpClient;
            _appSettings = appSettings.Value;
        }

        public async Task<IList<TvShow>> GetTvShows()
        {
            var baseURI = _appSettings.BaseUri;
            var response = await _httpClient.GetAsync(baseURI);

            if (response.IsSuccessStatusCode)
            {
                var res = await response.Content.ReadAsStringAsync();
                var showIndex = JsonSerializer.Deserialize<IList<TvShow>>(res);

                if (showIndex != null)
                {
                    return showIndex;
                }
            }
            return new List<TvShow>();
        }
    }
}