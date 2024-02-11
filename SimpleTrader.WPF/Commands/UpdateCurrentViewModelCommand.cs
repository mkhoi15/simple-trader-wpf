using SimpleTrader.FinacialModelingPrepAPI.Services;
using SimpleTrader.WPF.Factories;
using SimpleTrader.WPF.State.Navigators;
using SimpleTrader.WPF.ViewModels;
using System.Windows.Input;

namespace SimpleTrader.WPF.Commands
{
	public class UpdateCurrentViewModelCommand : ICommand
	{
		public event EventHandler? CanExecuteChanged;

		private INavigator _navigator;
		private readonly ISimpleTraderAbstractFactory _viewModelFactory;
		public UpdateCurrentViewModelCommand(INavigator navigator, ISimpleTraderAbstractFactory simpleTraderAbstractFactory)
		{
			_navigator = navigator;
			_viewModelFactory = simpleTraderAbstractFactory;
		}

		public bool CanExecute(object? parameter)
		{
			return true;
		}

		public void Execute(object? parameter)
		{
			if(parameter is ViewType)
			{
				ViewType viewType = (ViewType)parameter;
				
				_navigator.CurrentViewModel = _viewModelFactory.CreateViewModel(viewType);
			}
		}
	}
}
