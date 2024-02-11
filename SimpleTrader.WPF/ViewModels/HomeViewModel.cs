

namespace SimpleTrader.WPF.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        public CryptoViewModel CryptoViewModel { get; set; }
        public HomeViewModel(CryptoViewModel cryptoViewModel)
        {
            CryptoViewModel = cryptoViewModel;
        }
    }
}
