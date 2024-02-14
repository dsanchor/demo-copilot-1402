using System.Net.Http;
using System.Threading.Tasks;
// json
using System.Text.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;
using MyWebApi;
using System;

namespace MyWebApi.Tests
{
    public class MyWebApiTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        public MyWebApiTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GetWeatherForecast_ReturnsSuccessStatusCode()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync("/weatherforecast");

            // Assert
            response.EnsureSuccessStatusCode();

            // Assert returns 5 weather forecasts in the response
            var responseString = await response.Content.ReadAsStringAsync();
            var weatherForecasts = JsonSerializer.Deserialize<WeatherForecast[]>(responseString, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            Assert.Equal(5, weatherForecasts.Length);

        }

        // validate sorted weather forecast
        [Fact]
        public async Task GetSortedWeatherForecast_ReturnsSuccessStatusCode()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync("/weatherforecast/sorted");

            // Assert
            response.EnsureSuccessStatusCode();

            // Assert returns 5 weather forecasts in the response
            var responseString = await response.Content.ReadAsStringAsync();
            var weatherForecasts = JsonSerializer.Deserialize<WeatherForecast[]>(responseString, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            Assert.Equal(5, weatherForecasts.Length);

            // Assert weather forecasts are sorted
            for (int i = 0; i < weatherForecasts.Length - 1; i++)
            {
                Assert.True(weatherForecasts[i].TemperatureC <= weatherForecasts[i + 1].TemperatureC);
            }
        }

        
        public record WeatherForecast(DateTime Date, int TemperatureC, string? Summary)
        {
            public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
        }
    }

}