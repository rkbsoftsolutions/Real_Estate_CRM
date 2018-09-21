using AccountCore.DataModels;
using CRM.DatabaseModelLayer.Context;
using CRM.DatabaseModelLayer.Models;
using CRM.DatabaseServiceLayer.Repositories.Interfaces;
using CRM.DatabaseServiceLayer.Repositories.ViewModels;
using Microsoft.EntityFrameworkCore;
using StudentCounselling.Services.Repository.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.DatabaseServiceLayer.Repositories.Services
{
	public class Application_Modules_Service : Repository<Application_Modules>, IApplication_Modules
	{
		private ApplicationDB _context;
		IApplication_Users application_Users;
		public Application_Modules_Service(DbContext context) : base(context)
		{
			_context = (ApplicationDB)context;

		}
		public async Task<List<ModulesViewModel>> GetModulesAndAssignedPermissionAsync()
		{
			var UserIds = _context.ApplicationUserRole.Select(u => u.UserId).ToList();
			if (UserIds.Any())
			{
				var lst = _context.ApplicationUsers.Where(u => UserIds.Contains(u.Id)).ToList();
			}

			return null;
		}

	}
}
