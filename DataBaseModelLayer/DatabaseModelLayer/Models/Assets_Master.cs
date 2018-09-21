using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.DatabaseModelLayer.Models
{
	public class Asset_Master : BaseModel
	{
		public int AssetType { get; set; }
		public string AssetLink { get; set; }
	}
}
