using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace BlazorVersa.Data
{
    public class ScanService
    {
        private readonly HttpClient _httpClient;

        public ScanService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<(Dictionary<string, ScanResults>, string, string)> GetScanResultsAndRawDataAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync(".json");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var resultsDictionary = JsonSerializer.Deserialize<Dictionary<string, ScanResults>>(json);

                    if (resultsDictionary != null)
                    {
                        Console.WriteLine("JSON data parsed successfully into ScanResult.");
                        return (resultsDictionary, json, null);
                    }
                    else
                    {
                        var errorMessage = "Failed to parse JSON data into ScanResult.";
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
