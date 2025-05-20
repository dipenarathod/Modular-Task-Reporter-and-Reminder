using FinalProject.Information_Collector;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

//Checked
namespace FinalProject.Information_Collector_Plugins
{
    public class WeatherCollector : AbsInformationCollector
    {
        [JsonProperty]
        private string apiKey;

        [JsonConstructor]
        public WeatherCollector() : base()
        {
            this.source = "Weather Collector";
            ID = Guid.NewGuid().ToString();

            
            this.SetParameters(
                new Dictionary<string, string> { { "apiKey", "string" } },
                new Dictionary<string, string>()
            );

            this.SetRunTimeParameters(
                new Dictionary<string, string>
                {
                    { "city", "string" },
                    { "country", "string" }
                },
                new Dictionary<string, string>
                {
                    { "units", "string" }
                }
            );
        }

        public override async Task CollectInformation()
        {
            Console.WriteLine("Making Weather Report");

            var configParams = GetRequiredParameters();
            var runtimeParams = GetRunTimeRequiredParameters();
            var runtimeOptional = GetRunTimeOptionalParameters();

            apiKey = configParams["apiKey"];
            string city = runtimeParams["city"];
            string country = runtimeParams["country"];
            string units = "metric";
            if (runtimeOptional.ContainsKey("units") && runtimeOptional["units"].Equals("metric") || runtimeOptional["units"].Equals("imperial"))
            {
                units = runtimeOptional["units"];
            }

            string query = $"{Uri.EscapeDataString(city)},{Uri.EscapeDataString(country)}";
            string url = $"https://api.openweathermap.org/data/2.5/weather?q={query}&appid={apiKey}&units={units}";

            using (HttpClient client = new HttpClient())
            {
                string response = await client.GetStringAsync(url);
                JObject weatherData = JObject.Parse(response);

                string description = "No description";
                if (weatherData["weather"]?[0]?["description"] != null)
                {
                    description = (string)weatherData["weather"][0]["description"];
                }

                double temperature = 0;
                if (weatherData["main"]?["temp"] != null)
                {
                    temperature = (double)weatherData["main"]["temp"];
                }

                double feelsLike = 0;
                if (weatherData["main"]?["feels_like"] != null)
                {
                    feelsLike = (double)weatherData["main"]["feels_like"];
                }

                int humidity = 0;
                if (weatherData["main"]?["humidity"] != null)
                {
                    humidity = (int)weatherData["main"]["humidity"];
                }

                String report = "Weather in " + city + ", " + country+"\n";
                report += description + "\n";
                if (units.Equals("metric"))
                {
                    report += "Temperature: " + temperature + " Celsius" + "\n";
                    report += "Feels like Temperature: " + feelsLike + " Celsius" + "\n";
                }
                else
                {
                    report += "Temperature: " + temperature + " F" + "\n";
                    report += "Feels like Temperature: " + feelsLike + " F" + "\n";
                }
                report += "Humidity: " + humidity +"%";

                String title = "Weather Report - " + city + ", " + country; 
                SetTitle(title);
                SetDescription(report);
            }
        }
    }
}
