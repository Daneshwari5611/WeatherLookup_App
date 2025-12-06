using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Models;

namespace Services
{
    public class WeatherClient : IDisposable
    {
        private readonly HttpClient _http;
        private readonly string _apiKey;

        public WeatherClient(string apiKey)
        {
            _apiKey = apiKey;
            _http = new HttpClient();
            _http.BaseAddress = new Uri("https://api.openweathermap.org/");
        }

        public async Task<WeatherResponse> GetCurrentWeatherAsync(string city, string units)
        {
            var url = $"data/2.5/weather?q={city}&appid={_apiKey}&units={units}";
            var response = await _http.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadFromJsonAsync<WeatherResponse>();
            return result!;
        }

        public void Dispose() => _http.Dispose();
    }
}
