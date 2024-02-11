

using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services;

namespace SimpleTrader.WPF.ViewModels
{
    public class CryptoViewModel : ViewModelBase
    {
        private readonly ICryptoService _cryptoService;
        public CryptoViewModel(ICryptoService cryptoService)
        {
            _cryptoService = cryptoService;
        }
        private Crypto _btcusd;
        public Crypto BTCUSD
        {
            get { return _btcusd; }
            set
            {
				_btcusd = value;
				OnPropertyChanged(nameof(BTCUSD));
			}
        }
        private Crypto _ethusd;
        public Crypto ETHUSD
        {
            get { return _ethusd; }
            set
            {
                _ethusd = value;
                OnPropertyChanged(nameof(ETHUSD));
            }
        }
        private Crypto _eulusd;
        public Crypto EULUSD
        {
			get { return _eulusd; }
			set
            {
				_eulusd = value;
				OnPropertyChanged(nameof(EULUSD));
			}
		}

        public static CryptoViewModel LoadCryptoViewModel(ICryptoService cryptoService)
        {
			CryptoViewModel cryptoViewModel = new CryptoViewModel(cryptoService);
			cryptoViewModel.LoadCrypto();
			return cryptoViewModel;
		}

        private async Task LoadCrypto()
        {
			BTCUSD = await _cryptoService.GetCrypto(CryptoSymbol.BTCUSD);
			ETHUSD = await _cryptoService.GetCrypto(CryptoSymbol.ETHUSD);
			EULUSD = await _cryptoService.GetCrypto(CryptoSymbol.EULUSD);
		}
    }
}
