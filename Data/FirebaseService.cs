using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorVersa.Data
{
    public class FirebaseService
    {
        private readonly HttpClient _httpClient;

        public FirebaseService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetSpeedtestResultsJsonAsync()
        {
            var response = await _httpClient.GetAsync(".json");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                throw new Exception($"Failed to fetch data from Firebase. Status code: {response.StatusCode}");
            }
        }
    }
}
