using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace SimpleTrader.EntityFramework
{
	public class SimpleTraderDbContextFactory : IDesignTimeDbContextFactory<SimpleTraderDbContext>
	{
		public SimpleTraderDbContext CreateDbContext(string[] args = null)
		{
			var optionsBuilder = new DbContextOptionsBuilder<SimpleTraderDbContext>();
			optionsBuilder.UseSqlServer("Data Source=MSI\\SQLEXPRESS;Initial Catalog=SimpleTrader;User ID=sa;Password=12345;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

			return new SimpleTraderDbContext(optionsBuilder.Options);
		}
	}
	
}
