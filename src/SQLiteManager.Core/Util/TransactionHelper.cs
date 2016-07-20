using System.Transactions;

namespace SQLiteManager.Core
{
	internal static class TransactionHelper
	{
		public static TransactionScope NewTransaction()
		{
			return new TransactionScope(
				TransactionScopeOption.Required,
				new TransactionOptions {
					IsolationLevel = IsolationLevel.ReadCommitted
				}
			);
		}
	}
}
