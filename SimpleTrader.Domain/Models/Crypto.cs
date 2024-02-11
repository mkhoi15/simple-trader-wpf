

namespace SimpleTrader.Domain.Models
{
    public enum CryptoSymbol
    {
		BTCUSD,
		ETHUSD,
		EULUSD
	}

	public class Crypto
	{
        public CryptoSymbol Symbol { get; set; }
        public string? Name { get; set; }
        public double Price { get; set; }
        public double Change { get; set; }
    }
}
