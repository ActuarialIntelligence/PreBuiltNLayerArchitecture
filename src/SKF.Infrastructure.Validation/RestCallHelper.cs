using System.Net.Http;
using System;
using System.Threading.Tasks;

namespace SKF.Infrastructure.Validation
{
    public static class RestCallHelper
    {
        public static async Task RestAPICall(string[] args)
        {
            // Create an instance of HttpClient
             var httpClient = new HttpClient();

            // Specify the API endpoint URL
            string apiUrl = "https://api.example.com/some-endpoint";

            try
            {
                // Send a GET request to the API endpoint
                HttpResponseMessage response = await httpClient.GetAsync(apiUrl);

                // Check if the request was successful (status code 200-299)
                if (response.IsSuccessStatusCode)
                {
                    // Read the response content as a string
                    string responseBody = await response.Content.ReadAsStringAsync();

                    // Process the response data as needed
                    Console.WriteLine(responseBody);
                }
                else
                {
                    Console.WriteLine($"The API request failed with status code: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
