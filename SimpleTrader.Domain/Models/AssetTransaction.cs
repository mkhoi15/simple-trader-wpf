namespace SimpleTrader.Domain.Models
{
	public class AssetTransaction : IEntity
	{
		public Account? Account { get; set; }
        public bool isPurchase { get; set; }
		public Asset? Asset { get; set; }
        public int ShareAmount { get; set; }
        public DateTime DateProcessed { get; set; }
    }
}
