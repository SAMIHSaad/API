using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace Client
{
    public partial class Currency : System.Web.UI.Page
    {
        protected DropDownList from;
        protected DropDownList to;
        protected TextBox amount;
        protected Label result;
        private CurrencyConverterService _currencyConverterService = new CurrencyConverterService();

        protected async void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                await PopulateCurrencyDropdowns();
            }
        }

        private async Task PopulateCurrencyDropdowns()
        {
            try
            {
                var currencies = await _currencyConverterService.GetSupportedCurrenciesAsync();

                from.Items.Clear();
                to.Items.Clear();

                foreach (var currency in currencies)
                {
                    from.Items.Add(new ListItem(currency.Item2, currency.Item1));
                    to.Items.Add(new ListItem(currency.Item2, currency.Item1));
                }
            }
            catch (Exception ex)
            {
                result.Text = ex.Message;
            }
        }

        protected async void ConvertButton_Click(object sender, EventArgs e)
        {
            string fromCurrency = from.SelectedValue;
            string toCurrency = to.SelectedValue;
            double amountValue;

            if (double.TryParse(amount.Text, out amountValue))
            {
                try
                {
                    double convertedAmount = await _currencyConverterService.ConvertCurrencyAsync(fromCurrency, toCurrency, amountValue);
                    result.Text = $"Converted Amount: {convertedAmount} {toCurrency}";
                }
                catch (Exception ex)
                {
                    result.Text = ex.Message;
                }
            }
            else
            {
                result.Text = "Please enter a valid amount.";
            }
        }
    }
}