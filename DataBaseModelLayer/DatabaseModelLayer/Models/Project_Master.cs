using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.DatabaseModelLayer.Models
{
	public class Project_Master : PropertyBaseModel
	{


		public DateTime StartSellingDate { get; set; }
		public DateTime EndSellingDate { get; set; }
		public decimal GoalSellingAmount { get; set; }
		public decimal TotalProjectArea { get; set; }
		public decimal AreaLength { get; set; }
		public decimal AreaWidth { get; set; }
		public virtual ICollection<Asset_Master> ProjectAssets { get; set; }
		public virtual ICollection<Building_Plan_Master> Buildings { get; set; }
	}
}
