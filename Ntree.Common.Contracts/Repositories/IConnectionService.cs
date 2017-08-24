namespace Ntree.Common.Contracts.Repositories
{
	public interface IConnectionService
	{
		void ChangeDatabase(
			string sourceonnectionStringName = "",
			string destconnectionStringName = "",
			string initialCatalog = "",
			string dataSource = "",
			string userId = "",
			string password = "",
			bool integratedSecuity = true);
	}
}