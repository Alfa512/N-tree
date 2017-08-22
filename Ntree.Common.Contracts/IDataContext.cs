using System;
using Ntree.Common.Contracts.Repositories;

namespace Ntree.Common.Contracts
{
	public interface IDataContext : IDisposable
    {
		void Commit();
		IUserRepository Users { get; }
		IImageRepository UserImages { get; }
	}
}