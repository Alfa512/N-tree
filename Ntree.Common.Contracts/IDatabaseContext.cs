using System;
using System.Data.Entity;
using Ntree.Common.Contracts.Repositories;

namespace Ntree.Common.Contracts
{
	public interface IDatabaseContext : IDisposable
    {
		void Commit();
		IUserRepository Users { get; }
		IImageRepository UserImages { get; }
	    Database Database { get; }
	}
}