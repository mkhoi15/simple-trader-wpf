using SimpleTrader.WPF.State.Navigators;
using SimpleTrader.WPF.ViewModels;
using System.Windows;

namespace SimpleTrader.WPF
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow(object dataContext)
		{	
			InitializeComponent();
			//DataContext = new MainWindowViewModel();
			DataContext = dataContext;
		}
	}
}