using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CRM.DatabaseModelLayer.Models
{
	public class Building_Plan_Master : PropertyBaseModel
	{
		[ForeignKey("Project_Master")]
		public Guid Project_Master_Id { get; set; }
		public Project_Master Project_Master { get; set; }

	}
}
