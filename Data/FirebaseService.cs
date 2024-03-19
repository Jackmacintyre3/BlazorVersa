using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
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

        public async Task<(Dictionary<string, SpeedtestResults>, string, string)> GetSpeedtestResultsAndRawDataAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync(".json");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var resultsDictionary = JsonSerializer.Deserialize<Dictionary<string, SpeedtestResults>>(json);

                    if (resultsDictionary != null)
                    {
                        Console.WriteLine("JSON data parsed successfully into SpeedtestResults.");
                        return (resultsDictionary, json, null);
                    }
                    else
                    {
                        var errorMessage = "Failed to parse JSON data into SpeedtestResults.";
                        Console.WriteLine(errorMessage);
                        return (null, null, errorMessage);
                    }
                }
                else
                {
                    var errorMessage = $"Failed to fetch data from Firebase. Status code: {response.StatusCode}";
                    Console.WriteLine(errorMessage);
                    return (null, null, errorMessage);
                }
            }
            catch (Exception ex)
            {
                var errorMessage = $"An error occurred while fetching data from Firebase: {ex.Message}";
                Console.WriteLine(errorMessage);
                return (null, null, errorMessage);
            }
        }
    }
}
