using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
using Ntree.Domain.Model.Enums;

namespace Ntree.Domain.Model.DataModel
{
	[Table("UserImages")]
	public class Image
	{
		public Image()
		{
			Id = Guid.NewGuid().ToString();
		}
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public string Id { get; set; }
		public string ImagePath { get; set; }
		public string FileType { get; set; }
		public string Description { get; set; }
		public bool Avatar { get; set; }
		public ImageType ImageType { get; set; }
		public DateTime CreationDate { get; set; }
		public DateTime LastUpdateDate { get; set; }
		public DbGeography Location { get; set; }
		public byte Privacy { get; set; }
		public bool IsDeleted { get; set; }
		public virtual User User { get; set; }
		public virtual string UserId { get; set; }
		public virtual string BikeId { get; set; }
	}
}