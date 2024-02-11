using SimpleTrader.Domain.Services;
using SimpleTrader.WPF.ViewModels;

namespace SimpleTrader.WPF.Factories
{
	public class CryptoViewModelFactory : ISimpleTraderViewModelFactory<CryptoViewModel>
	{
		private readonly ICryptoService _cryptoService;

		public CryptoViewModelFactory(ICryptoService cryptoService)
		{
			_cryptoService = cryptoService;
		}

		public CryptoViewModel CreateViewModel()
		{
			return CryptoViewModel.LoadCryptoViewModel(_cryptoService);
		}
	}
	
}
