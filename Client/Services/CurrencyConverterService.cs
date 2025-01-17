using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

public class CurrencyConverterService
{
    private readonly string apiKey = "ff35b5fb3cc1c17bcc2f5c7f"; // Your API key

    public async Task<double> ConvertCurrencyAsync(string fromCurrency, string toCurrency, double amount)
    {
        string url = $"https://v6.exchangerate-api.com/v6/{apiKey}/pair/{fromCurrency}/{toCurrency}/{amount}";

        using (HttpClient client = new HttpClient())
        {
            HttpResponseMessage response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                string jsonResponse = await response.Content.ReadAsStringAsync();

                try
                {
                    JObject data = JObject.Parse(jsonResponse);
                    double convertedAmount = (double)data["conversion_result"];
                    return convertedAmount;
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error parsing JSON response: {ex.Message}. Response content: {jsonResponse}");
                }
            }
            else
            {
                throw new Exception($"Error: Unable to retrieve data. Status code: {response.StatusCode}");
            }
        }
    }

    public async Task<List<Tuple<string, string>>> GetSupportedCurrenciesAsync()
    {
        string url = $"https://v6.exchangerate-api.com/v6/{apiKey}/codes";

        using (HttpClient client = new HttpClient())
        {
            HttpResponseMessage response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                string jsonResponse = await response.Content.ReadAsStringAsync();

                try
                {
                    JObject data = JObject.Parse(jsonResponse);
                    JArray supportedCodes = (JArray)data["supported_codes"];
                    List<Tuple<string, string>> currencies = new List<Tuple<string, string>>();

                    foreach (var code in supportedCodes)
                    {
                        string currencyCode = code[0].ToString();
                        string currencyName = code[1].ToString();
                        currencies.Add(new Tuple<string, string>(currencyCode, currencyName));
                    }

                    return currencies;
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error parsing JSON response: {ex.Message}. Response content: {jsonResponse}");
                }
            }
            else
            {
                throw new Exception($"Error: Unable to retrieve data. Status code: {response.StatusCode}");
            }
        }
    }
}