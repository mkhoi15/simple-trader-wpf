using SimpleTrader.Domain.Exception;
using SimpleTrader.Domain.Models;

namespace SimpleTrader.Domain.Services.TransactionServices
{
	public class BuyStockService : IBuyStockService
	{
		private readonly IStockService _stockService;
		private readonly IDataService<Account> _accountService;

		public BuyStockService(IStockService stockService, IDataService<Account> accountService)
		{
			_stockService = stockService;
			_accountService = accountService;
		}

		public async Task<Account> BuyStock(Account buyer, string symbol, int shares)
		{
			double stockPrice = await _stockService.GetPrice(symbol);

			if(stockPrice * shares > buyer.Balance)
			{
				throw new InsufficientFundsException(buyer.Balance, stockPrice * shares);
			}

			AssetTransaction assetTransaction = new AssetTransaction()
			{
				Account = buyer,
				Asset = new Asset()
				{
					Symbol = symbol,
					PriceShare = stockPrice
				},
				isPurchase = true,
				ShareAmount = shares
			};

			buyer.AssetTransactions.Add(assetTransaction);
			buyer.Balance -= stockPrice * shares;

			await _accountService.Update(buyer.Id, buyer);

			return buyer;
		}
	}
}
