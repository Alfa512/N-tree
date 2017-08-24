using System;
using System.Configuration;
using System.IO;
using Ntree.Common.Contracts.Repositories;

namespace Ntree.Business.Services
{
	public class ConfigurationService : IConfigurationService
	{

		public string SourceConnectionString
		{
			get => ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
			set
			{
				if (value == null) return;
				SourceConnectionString = value;
			}
		}

		public string DestinationConnectionString
		{
			get => ConfigurationManager.ConnectionStrings["DestinationConnection"].ConnectionString;
			set
			{
				if (value == null) return;
				DestinationConnectionString = value;
			}
		}
	}
}