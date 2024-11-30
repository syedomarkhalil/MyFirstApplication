using Microsoft.Extensions.Configuration;
using MyFirstApplication.Models;
using MyFirstApplication.Repository;
using Newtonsoft.Json;
using System.Configuration;
using System.Net.Http;

namespace MyFirstApplication.Services
{

    public class Services : IServices
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public Services(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClient = httpClientFactory.CreateClient();
            _configuration = configuration;
        }
        public async Task<IList<Show>> GetListOfShows()
        {


            var baseUri = _configuration["URL:BaseURI"];
            HttpResponseMessage response = await _httpClient.GetAsync(baseUri);

            if (response.IsSuccessStatusCode)
            {
                var res = await response.Content.ReadAsStringAsync();
                var showIndex = JsonConvert.DeserializeObject<IList<Show>>(res);

                if (showIndex != null)
                {
                    return showIndex;
                }
            }

            return new List<Show>();
        }
    }
   
}
