using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace API
{
    public class ApiClient
    {
        public static ApiClient Instance = new ApiClient();

        public const string ApiBase = "http://192.168.1.130:3005/";
        private static readonly HttpClient _httpClient = new HttpClient();

        public async Task<T> GetAsync<T>(string endpointUrl)
        {
            var completeUrl = ApiBase + endpointUrl;
            var response = await _httpClient.GetAsync(completeUrl);

            if(response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync(); 
                var result = JsonConvert.DeserializeObject<T>(content);
                return result;
            }

            return default(T);
        }
    }
}
