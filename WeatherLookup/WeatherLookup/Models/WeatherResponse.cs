using System.Text.Json.Serialization;

namespace Models
{
    public class WeatherResponse
    {
        [JsonPropertyName("weather")]
        public WeatherInfo[]? Weather { get; set; }

        [JsonPropertyName("main")]
        public MainInfo Main { get; set; } = new MainInfo();

        [JsonPropertyName("wind")]
        public WindInfo? Wind { get; set; }

        [JsonPropertyName("sys")]
        public SysInfo? Sys { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }
    }

    public class WeatherInfo
    {
        [JsonPropertyName("main")]
        public string? Main { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }
    }

    public class MainInfo
    {
        [JsonPropertyName("temp")]
        public double Temp { get; set; }

        [JsonPropertyName("feels_like")]
        public double FeelsLike { get; set; }

        [JsonPropertyName("humidity")]
        public int Humidity { get; set; }
    }

    public class WindInfo
    {
        [JsonPropertyName("speed")]
        public double Speed { get; set; }
    }

    public class SysInfo
    {
        [JsonPropertyName("country")]
        public string? Country { get; set; }
    }
}
