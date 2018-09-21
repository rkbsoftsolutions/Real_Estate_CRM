﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM.DatabaseServiceLayer.Repositories.ViewModels
{
	public class ModulesViewModel
	{
		public string ModuleName { get; set; }
		public string RoleName { get; set; }
		public int RoleId { get; set; }
		public Guid ModuleId { get; set; }
	}
}
