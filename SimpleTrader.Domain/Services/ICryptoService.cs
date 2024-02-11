using SimpleTrader.Domain.Models;

namespace SimpleTrader.Domain.Services
{
	public interface ICryptoService
	{
		Task<Crypto> GetCrypto(CryptoSymbol cryptoSymbol);
	}
}
