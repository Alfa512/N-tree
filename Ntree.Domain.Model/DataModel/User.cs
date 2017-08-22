using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ntree.Domain.Model.DataModel
{
	public class User
	{

	    public User()
	    {
	        UserImages = new List<Image>();
	    }
        [Key]
		public string Id { get; set; }
		public string Name { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public string UserName { get; set; }
		public bool Sex { get; set; }
		public DateTime RegistrationDate { get; set; }
		public string RestorePasswordToken { get; set; }
		public DateTime TokenValidTo { get; set; }
	    public virtual ICollection<Image> UserImages { get; set; }
    }
}