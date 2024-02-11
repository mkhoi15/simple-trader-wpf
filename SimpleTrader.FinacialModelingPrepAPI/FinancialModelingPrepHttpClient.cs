namespace SimpleTrader.FinacialModelingPrepAPI
{
	public class FinancialModelingPrepHttpClient : HttpClient
	{
		public FinancialModelingPrepHttpClient()
		{
			this.BaseAddress = new Uri("https://financialmodelingprep.com/api/v3/");
		}
	}
}
