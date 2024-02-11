using Newtonsoft.Json;
using SimpleTrader.Domain.Exception;
using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services;
using SimpleTrader.FinacialModelingPrepAPI.Result;

namespace SimpleTrader.FinacialModelingPrepAPI.Services
{
	public class StockService : IStockService
	{
		public async Task<double> GetPrice(string symbol)
		{
			using (FinancialModelingPrepHttpClient client = new FinancialModelingPrepHttpClient())
			{
				string uri = $"stock/real-time-price/{symbol}?apikey=302jgz7dJRVMkkOBcKgE8VpSi6w97Eud";

				HttpResponseMessage response = await client.GetAsync(uri);

				string jsonResponse = await response.Content.ReadAsStringAsync();

				var stock = JsonConvert.DeserializeObject<StockPriceResult>(jsonResponse);

				if (stock == null )
				{
					throw new InvalidSymbolException(symbol);
				}

				return stock.Price;
			}
		}
	}
}
