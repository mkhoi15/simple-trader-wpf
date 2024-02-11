using Microsoft.Extensions.DependencyInjection;
using SimpleTrader.Domain.Services;
using SimpleTrader.Domain.Services.TransactionServices;
using SimpleTrader.EntityFramework;
using SimpleTrader.EntityFramework.Services;
using SimpleTrader.FinacialModelingPrepAPI.Services;
using SimpleTrader.WPF.Factories;
using SimpleTrader.WPF.State.Navigators;
using SimpleTrader.WPF.ViewModels;
using System.Windows;

namespace SimpleTrader.WPF
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		protected override void OnStartup(StartupEventArgs e)
		{

			IServiceProvider serviceProvider = CreateServiceProvider();


			Window window = serviceProvider.GetRequiredService<MainWindow>();
			window.Show();

			base.OnStartup(e);
		}

		private IServiceProvider CreateServiceProvider()
		{
			IServiceCollection services = new ServiceCollection();

			services.AddSingleton<SimpleTraderDbContextFactory>();
			services.AddScoped<IStockService, StockService>();
			services.AddScoped<IBuyStockService, BuyStockService>();
			services.AddScoped(typeof(IDataService<>), typeof(GenericDataService<>));
			services.AddScoped<ICryptoService, CryptoService>();

			services.AddSingleton<ISimpleTraderAbstractFactory, SimpleTraderViewModelAbstractFactory>();
			services.AddSingleton<ISimpleTraderViewModelFactory<HomeViewModel>, HomeViewModelFactory>();
			services.AddSingleton<ISimpleTraderViewModelFactory<PortfolioViewModel>, PortfolioViewModelFactory>();
			services.AddSingleton<ISimpleTraderViewModelFactory<CryptoViewModel>, CryptoViewModelFactory>();

			services.AddScoped<MainWindowViewModel>();
			services.AddScoped<INavigator, Navigator>();

			services.AddScoped<MainWindow>(s => new MainWindow(s.GetRequiredService<MainWindowViewModel>()));

			return services.BuildServiceProvider();
		}

	}

}
