using System;

namespace Ntree.Domain.Model.DataModel
{
	public class User
	{
		public string Name { get; set; }
		public string LastName { get; set; }
		public bool Sex { get; set; }
		public DateTime RegistrationDate { get; set; }
		public string RestorePasswordToken { get; set; }
		public DateTime TokenValidTo { get; set; }
	}
}