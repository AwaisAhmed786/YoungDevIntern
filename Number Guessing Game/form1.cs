using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace CurrencyConverter
{
    public partial class Form1 : Form
    {
        private const string ApiKey = "YOUR_API_KEY_HERE"; // Replace with your ExchangeRate-API key
        private const string ApiUrl = "https://v6.exchangerate-api.com/v6/" + ApiKey + "/latest/USD";

        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            await LoadCurrenciesAsync();
        }

        private async Task LoadCurrenciesAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(ApiUrl);
                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();
                JObject data = JObject.Parse(responseBody);
                var currencies = data["conversion_rates"].ToObject<Dictionary<string, decimal>>();

                comboBoxFromCurrency.Items.AddRange(currencies.Keys.ToArray());
                comboBoxToCurrency.Items.AddRange(currencies.Keys.ToArray());

                comboBoxFromCurrency.SelectedIndex = 0;
                comboBoxToCurrency.SelectedIndex = 0;
            }
        }

        private async void buttonConvert_Click(object sender, EventArgs e)
        {
            decimal amount;
            if (!decimal.TryParse(textBoxAmount.Text, out amount))
            {
                MessageBox.Show("Please enter a valid amount.");
                return;
            }

            string fromCurrency = comboBoxFromCurrency.SelectedItem.ToString();
            string toCurrency = comboBoxToCurrency.SelectedItem.ToString();

            decimal convertedAmount = await ConvertCurrencyAsync(amount, fromCurrency, toCurrency);
            labelResult.Text = $"{amount} {fromCurrency} = {convertedAmount:F2} {toCurrency}";
        }

        private async Task<decimal> ConvertCurrencyAsync(decimal amount, string fromCurrency, string toCurrency)
        {
            using (HttpClient client = new HttpClient())
            {
                string url = $"https://v6.exchangerate-api.com/v6/{ApiKey}/pair/{fromCurrency}/{toCurrency}";
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();
                JObject data = JObject.Parse(responseBody);
                decimal rate = (decimal)data["conversion_rate"];

                return amount * rate;
            }
        }
    }
}
