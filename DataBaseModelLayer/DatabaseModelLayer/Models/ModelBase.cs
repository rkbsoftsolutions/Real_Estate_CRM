using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CRM.DatabaseModelLayer.Models
{
	public abstract class BaseModel
	{
		[Key]
		public Guid Id { get; set; }
		public DateTime Created_Date { get { return new DateTime(); } }
		public DateTime Update_Time { get { return new DateTime(); } }
		
		public bool IsActive { get; set; }
		
	}

	public abstract class BaseModelHead : BaseModel
	{
		public string Name { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public string ShortDescription { get; set; }
		
	}

	public abstract class PropertyBaseModel : BaseModelHead
	{
		public int Units_Types { get; set; }
	}
}
