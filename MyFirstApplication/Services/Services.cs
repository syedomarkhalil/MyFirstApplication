using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MyFirstApplication.Models;
using Newtonsoft.Json;
using System.Configuration;
using System.Net.Http;

namespace MyFirstApplication.Services
{

    public class Services : IServices
    {
        private readonly HttpClient _httpClient;
        private readonly IOptions<AppSettings> _appSettings;

        public Services(IHttpClientFactory httpClientFactory, IOptions<AppSettings> appSettings)
        {
            _httpClient = httpClientFactory.CreateClient();
            _appSettings = appSettings;
        }
        public async Task<IList<TvShow>> GetListOfTvShows()
        {
            
            var baseURI = _appSettings.Value.BaseURI;
            //var baseUri = _configuration["URL:BaseURI"];
            var response = await _httpClient.GetAsync(baseURI);

            if (response.IsSuccessStatusCode)
            {
                var res = await response.Content.ReadAsStringAsync();
                var showIndex = JsonConvert.DeserializeObject<IList<TvShow>>(res);

                if (showIndex != null)
                {
                    return showIndex;
                }
            }

            return new List<TvShow>();
        }
    }
   
}
