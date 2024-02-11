using System.Runtime.Serialization;

namespace SimpleTrader.Domain.Exception
{
	public class InsufficientFundsException : IOException
	{
		//private const string DefaultMessage = "Insufficient funds for the transaction";
		public double AccountBalance { get; set; }
		public double RequiredBalance { get; set; }

		public InsufficientFundsException(double acocuntBalance, double requiredBalance)
		{
			AccountBalance = acocuntBalance;
			RequiredBalance = requiredBalance;
		}

		public InsufficientFundsException(double acocuntBalance, double requiredBalance, string? message) : base(message)
		{
			AccountBalance = acocuntBalance;
			RequiredBalance = requiredBalance;
		}

		public InsufficientFundsException(double acocuntBalance, double requiredBalance, string? message, System.Exception? innerException) : base(message, innerException)
		{
			AccountBalance = acocuntBalance;
			RequiredBalance = requiredBalance;
		}

		public InsufficientFundsException(double acocuntBalance, double requiredBalance, string? message, int hresult) : base(message, hresult)
		{
			AccountBalance = acocuntBalance;
			RequiredBalance = requiredBalance;
		}
		
	}
}
