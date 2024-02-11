using SimpleTrader.WPF.ViewModels;

namespace SimpleTrader.WPF.Factories
{
	public class HomeViewModelFactory : ISimpleTraderViewModelFactory<HomeViewModel>
	{
		private ISimpleTraderViewModelFactory<CryptoViewModel> _cryptoViewModelFactory;

		public HomeViewModelFactory(ISimpleTraderViewModelFactory<CryptoViewModel> cryptoViewModelFactory)
		{
			_cryptoViewModelFactory = cryptoViewModelFactory;
		}

		public HomeViewModel CreateViewModel()
		{
			return new HomeViewModel(_cryptoViewModelFactory.CreateViewModel());
		}
	}

}
