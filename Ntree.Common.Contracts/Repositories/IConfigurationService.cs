namespace Ntree.Common.Contracts.Repositories
{
	public interface IConfigurationService
	{
		string SourceConnectionString { get; }
		string DestinationConnectionString { get; }
	}
}