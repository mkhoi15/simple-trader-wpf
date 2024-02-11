namespace SimpleTrader.Domain.Models
{
	public class Account : IEntity
	{
		public User? AccountHolder { get; set; }
		public double Balance { get; set; }
		public ICollection<AssetTransaction> AssetTransactions { get; set; } = new List<AssetTransaction>();
	}
}
