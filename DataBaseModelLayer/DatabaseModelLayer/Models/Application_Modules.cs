using AccountCore.DataModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CRM.DatabaseModelLayer.Models
{
	public class Application_Modules : BaseModelHead
	{}


	public class Mouels_Roles_Link : BaseModel
	{
		
		public Guid Application_Modules_Id { get; set; }
		
		public Guid Application_Roles_Id { get; set; }

		[ForeignKey("Application_Modules_Id")]
		public Application_Modules application_Modules { get; set; }

	    [ForeignKey("Application_Roles_Id")]
		public ApplicationRoles applicationRoles { get; set; }
	}



	
}
