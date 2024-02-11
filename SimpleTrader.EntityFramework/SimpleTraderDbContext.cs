using Microsoft.EntityFrameworkCore;
using SimpleTrader.Domain.Models;

namespace SimpleTrader.EntityFramework
{
	public class SimpleTraderDbContext : DbContext
	{
		public SimpleTraderDbContext()
		{
		}
		public SimpleTraderDbContext(DbContextOptions options) : base(options)
		{
		}
        
        public DbSet<Account> Accounts { get; set; }
		public DbSet<AssetTransaction> AssetTransactions { get; set; }
		public DbSet<Asset> Assets { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<AssetTransaction>().OwnsOne(a => a.Asset);
			base.OnModelCreating(modelBuilder);
		}
	

	}
	
}
