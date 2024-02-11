using SimpleTrader.WPF.Commands;
using SimpleTrader.WPF.Factories;
using SimpleTrader.WPF.Models;
using SimpleTrader.WPF.ViewModels;
using System.ComponentModel;
using System.Windows.Input;

namespace SimpleTrader.WPF.State.Navigators
{
	public class Navigator : ObservabalObject, INavigator
	{
		private ViewModelBase _currentViewModel;

		public Navigator(ISimpleTraderAbstractFactory viewModelFactory)
		{
			UpdateCurrentViewModelCommand = new UpdateCurrentViewModelCommand(this, viewModelFactory);
		}

		public ViewModelBase CurrentViewModel
		{
			get => _currentViewModel; 
			set
			{
				_currentViewModel = value;
				OnPropertyChanged(nameof(CurrentViewModel));
			}
		}

		public ICommand UpdateCurrentViewModelCommand { get;  set; }

		
	}
}
