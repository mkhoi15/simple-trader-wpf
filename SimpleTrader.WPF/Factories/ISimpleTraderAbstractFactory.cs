using SimpleTrader.WPF.State.Navigators;
using SimpleTrader.WPF.ViewModels;

namespace SimpleTrader.WPF.Factories
{
	public interface ISimpleTraderAbstractFactory
	{
		ViewModelBase CreateViewModel(ViewType viewType);
	}
}
