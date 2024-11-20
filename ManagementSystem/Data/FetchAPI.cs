using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ManagementSystem.Exceptions;

namespace ManagementSystem.Data
{
    // TODO:
    // 1. Summary comment with class description
    // 2. Add custom exception class for API related errors - Complete, but need proper Message
    internal class FetchAPI
    {
        // Lists
        internal static List<Weather> weatherList = new List<Weather>();

        // Methods
        internal static async Task FetchWeather(string apiUrl)
        {
            using var client = new HttpClient();

            try
            {
                // Get the weather data from VisualCrossing API
                var request = new HttpRequestMessage(HttpMethod.Get, apiUrl);

                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();

                var weatherJson = await response.Content.ReadAsStringAsync();

                if (!string.IsNullOrEmpty(weatherJson))
                {
                    // Parse the JSON data into a JsonElement
                    var weatherData = JsonSerializer.Deserialize<JsonElement>(weatherJson);

                    if (weatherData.TryGetProperty("days", out JsonElement daysElement) && daysElement.ValueKind == JsonValueKind.Array)
                    {
                        // Get necessary data from the JsonElement and store in Weather object
                        foreach (var day in daysElement.EnumerateArray())
                        {
                            string datetime = day.GetProperty("datetime").GetString();
                            string temp = day.GetProperty("temp").GetDouble().ToString();
                            string description = day.GetProperty("description").GetString();

                            Weather weather = new Weather(datetime, temp, description);
                            weatherList.Add(weather);
                        }

                        // Confirm data is in the list
                        foreach(var weather in weatherList)
                        {
                            Debug.WriteLine(weather.ToString());
                        }
                    }
                    else
                    {
                        Debug.WriteLine("Error: Could not find 'days' array in JSON data.");
                    }
                }
                else
                {
                    Debug.WriteLine("Error: Could not retrieve weather data from API.");
                }
            }
            catch (APIException e)
            {
                Debug.WriteLine($"Error fetching weather data: {e.Message}");
            }
        }
    }
}
