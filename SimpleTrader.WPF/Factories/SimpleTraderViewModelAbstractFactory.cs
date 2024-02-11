using AngleSharp.Browser.Dom;
using SimpleTrader.FinacialModelingPrepAPI.Services;
using SimpleTrader.WPF.State.Navigators;
using SimpleTrader.WPF.ViewModels;

namespace SimpleTrader.WPF.Factories
{
	public class SimpleTraderViewModelAbstractFactory : ISimpleTraderAbstractFactory
	{
		private readonly ISimpleTraderViewModelFactory<HomeViewModel> _homeViewModelFactory;
		private readonly ISimpleTraderViewModelFactory<PortfolioViewModel> _portfolioViewModelFactory;
		public SimpleTraderViewModelAbstractFactory(ISimpleTraderViewModelFactory<HomeViewModel> homeViewModelFactory, ISimpleTraderViewModelFactory<PortfolioViewModel> portfolioViewModelFactory)
		{
			_homeViewModelFactory = homeViewModelFactory;
			_portfolioViewModelFactory = portfolioViewModelFactory;
		}

		public ViewModelBase CreateViewModel(ViewType viewType)
		{
			switch (viewType)
			{
				case ViewType.Home:
					return _homeViewModelFactory.CreateViewModel();
				case ViewType.Portfolio:
					return _portfolioViewModelFactory.CreateViewModel();
				default:
					throw new ArgumentException("The ViewType does not have a ViewModel.", nameof(viewType));
				
			}
		}
	}
}
