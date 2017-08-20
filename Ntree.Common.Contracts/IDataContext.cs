using System;

namespace Ntree.Common.Contracts
{
	public interface IDataContext : IDisposable
	{
		void Commit();

	}
}