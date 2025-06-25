using MyFirstApplication.Models;

namespace MyFirstApplication.Infrastructure
{
    public class TvShowHttpClient(HttpClient httpClient)
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