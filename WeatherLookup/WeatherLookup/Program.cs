using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;

class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("=== WeatherLookup v1.0 ===");
        Console.WriteLine();

        // Get API key from environment variable
        string? apiKey = Environment.GetEnvironmentVariable("OPENWEATHER_APIKEY");

        if (string.IsNullOrWhiteSpace(apiKey))
        {
            Console.WriteLine("ERROR: OPENWEATHER_APIKEY is not set.");
            Console.WriteLine("Please run:  setx OPENWEATHER_APIKEY \"your_api_key_here\"");
            return;
        }

        // Dynamic user input
        Console.Write("Enter city name: ");
        string city = Console.ReadLine()!.Trim();

        if (string.IsNullOrWhiteSpace(city))
        {
            Console.WriteLine("City name cannot be empty.");
            return;
        }

        Console.Write("Units (metric/imperial/standard): ");
        string units = Console.ReadLine()!.Trim().ToLower();

        if (string.IsNullOrWhiteSpace(units))
            units = "metric"; // default units

        if (units != "metric" && units != "imperial" && units != "standard")
        {
            Console.WriteLine("Invalid units. Using metric by default.");
            units = "metric";
        }

        Console.WriteLine();
        Console.WriteLine("Fetching weather...");

        try
        {
            using HttpClient client = new HttpClient();

            string url =
                $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={apiKey}&units={units}";

            HttpResponseMessage response = await client.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine($"API Error: {response.StatusCode}");
                Console.WriteLine("Possible issues: Invalid city name or API key.");
                return;
            }

            string json = await response.Content.ReadAsStringAsync();

            using JsonDocument doc = JsonDocument.Parse(json);
            JsonElement root = doc.RootElement;

            string weatherMain = root.GetProperty("weather")[0].GetProperty("main").GetString()!;
            string description = root.GetProperty("weather")[0].GetProperty("description").GetString()!;
            double temp = root.GetProperty("main").GetProperty("temp").GetDouble();
            double feelsLike = root.GetProperty("main").GetProperty("feels_like").GetDouble();
            int humidity = root.GetProperty("main").GetProperty("humidity").GetInt32();

            Console.WriteLine();
            Console.WriteLine("=== Weather Report ===");
            Console.WriteLine($"City:           {city}");
            Console.WriteLine($"Condition:      {weatherMain} ({description})");
            Console.WriteLine($"Temperature:    {temp}° ({units})");
            Console.WriteLine($"Feels Like:     {feelsLike}°");
            Console.WriteLine($"Humidity:       {humidity}%");
            Console.WriteLine("======================");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Unexpected error occurred:");
            Console.WriteLine(ex.Message);
        }
    }
}
