using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;


namespace Client
{
    public class WeatherService
    {
        private readonly string apiKey = "c684d0d3f326823d5a940a22842ccd55"; 

        public async Task<JObject> GetWeatherAsync(string city)
        {
            string url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={apiKey}&units=metric";

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    return JObject.Parse(jsonResponse);
                }
                else
                {
                    throw new Exception($"Error: Unable to retrieve data. Status code: {response.StatusCode}");
                }
            }
        }
    }
}