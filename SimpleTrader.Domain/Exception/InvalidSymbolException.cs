using System.Runtime.Serialization;

namespace SimpleTrader.Domain.Exception
{
	public class InvalidSymbolException : IOException
	{
        public string? Symbol { get; set; }
        public InvalidSymbolException(string? symbol)
		{
			Symbol = symbol;
		}

		public InvalidSymbolException(string symbol, string? message) : base(message)
		{
			Symbol = symbol;
		}

		public InvalidSymbolException(string symbol, string? message, System.Exception? innerException) : base(message, innerException)
		{
			Symbol = symbol;
		}

		public InvalidSymbolException(string symbol, string? message, int hresult) : base(message, hresult)
		{
			Symbol = symbol;
		}

	
	}
}
