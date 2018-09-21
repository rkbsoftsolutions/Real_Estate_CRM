using AccountCore.DataModels;
using AccountCore.Repositories.Interfaces;
using CRM.DatabaseModelLayer.Context;
using CRM.DatabaseServiceLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using StudentCounselling.Services.Repository.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRM.DatabaseServiceLayer.Repositories.Services
{
    public class Application_Users_Service : Repository<ApplicationUsers>, IApplication_Users
	{

		private ApplicationDB _context;
		public Application_Users_Service(DbContext context) : base(context)
		{
			_context = (ApplicationDB)context;
			
		}

		public List<ApplicationUsers> GetUserByRole(Guid? RoleId)
		{
			if ((Guid?)RoleId == Guid.Empty)
			{
				var UserIds = _context.ApplicationUserRole.Select(u => u.UserId).ToList();
				if (UserIds.Any())
				{

					return _context.ApplicationUsers.Where(u => UserIds.Contains(u.Id)).ToList();
				}

			}
			throw new Exception("Roles not Found");
		}

		
	}
}
