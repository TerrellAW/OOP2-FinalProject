using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ManagementSystem.Exceptions;

namespace ManagementSystem
{
    /// <summary>
    /// FetchAPI class is responsible for fetching weather data from the VisualCrossing API.
    /// A static List of Weather objects will store the data for use in the application.
    /// 
    /// Steps:
    /// 1. Create a static List of Weather objects to store the weather data.
    /// 2. Create a static method to fetch the weather data from the API.
    /// 3. Use HttpClient to send a GET request to the API.
    /// 4. Parse the JSON data into a JsonElement.
    /// 5. Extract the necessary data from the JsonElement and store in a Weather object.
    /// 6. Add the Weather object to the List.
    /// 7. Debug output to confirm data is stored in the List.
    /// 8. Handle exceptions for API connection errors and JSON parsing errors.
    /// </summary>
    /// <returns>
    /// The weatherList field will be populated with Weather objects containing the weather data.
    /// Weather data for each day will be displayed in that day's Calendar entry.
    /// </returns>
    /// <exception cref="APIException">Thrown when there is an error fetching weather data.</exception>
    /// <exception cref="APIDataException">Thrown when there is an error parsing the JSON data.</exception>
    /// <exception cref="APIConnectionException">Thrown when there is an error connecting to the API.</exception>

    internal class FetchAPI
    {
        // Lists
        internal static SLL weatherList = new SLL();

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
                        weatherList.PrintData(weatherList.Size);
                    }
                    else
                    {
                        throw new APIDataException("Error: Could not find 'days' array in JSON data.");
                    }
                }
                else
                {
                    throw new APIConnectionException("Error: Could not retrieve weather data from API.");
                }
            }
            catch (APIException e)
            {
                Debug.WriteLine($"Error fetching weather data: {e.Message}");
            }
        }
    }
}
