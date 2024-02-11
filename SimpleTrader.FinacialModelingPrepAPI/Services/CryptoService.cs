using Newtonsoft.Json;
using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services;

namespace SimpleTrader.FinacialModelingPrepAPI.Services
{
	public class CryptoService : ICryptoService
	{
		public async Task<Crypto> GetCrypto(CryptoSymbol cryptoSymbol)
		{
			using (FinancialModelingPrepHttpClient client = new FinancialModelingPrepHttpClient())
			{
				string uri = $"quote/{cryptoSymbol}?apikey=302jgz7dJRVMkkOBcKgE8VpSi6w97Eud";

				HttpResponseMessage response = await client.GetAsync(uri);
				string jsonResponse = await response.Content.ReadAsStringAsync();

				var cryptoArray = JsonConvert.DeserializeObject<Crypto[]>(jsonResponse);

				// Since the API always returns a single object inside an array, take the first element
				var crypto = cryptoArray[0];

				// Set the Symbol since it's not present in the JSON response
				crypto.Symbol = cryptoSymbol;

				return crypto;
			}
		}
	}
}
