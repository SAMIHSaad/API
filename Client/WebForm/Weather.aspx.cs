using System;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Client
{
    public partial class Weather : System.Web.UI.Page
    {
        private WeatherService _weatherService = new WeatherService();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected async void GetWeatherButton_Click(object sender, EventArgs e)
        {
            string city = cityTextBox.Text;

            try
            {
                JObject weatherData = await _weatherService.GetWeatherAsync(city);
                DisplayWeather(weatherData);
            }
            catch (Exception ex)
            {
                resultLabel.Text = ex.Message;
            }
        }

        private void DisplayWeather(JObject weatherData)
        {
            string description = weatherData["weather"][0]["description"].ToString();
            string temperature = weatherData["main"]["temp"].ToString();
            string humidity = weatherData["main"]["humidity"].ToString();

            resultLabel.Text = $"Weather: {description}<br/>Temperature: {temperature}°C<br/>Humidity: {humidity}%";
        }
    }
}