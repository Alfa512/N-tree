using System.Windows.Forms;
using Ntree.Common.Contracts;
using Ntree.Data.Entity;
using SimpleInjector;

namespace Ntree.UI
{
	public class AppStart
	{
		// For more information on configuring authentication, please visit http://go.microsoft.com/fwlink/?LinkId=301864
		public void ConfigureAuth()
		{
			var container = new Container();

			// Register your types, for instance:
			//container.Register<IDataContext, ApplicationDbContext>(Lifestyle.Singleton);
			//container.Register<IUserContext, WinFormsUserContext>();
			container.Register<Form>();

			// Optionally verify the container.
			//container.Verify();
		}
	}
}