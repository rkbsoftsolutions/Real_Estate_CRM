using AccountCore.DataModels;
using CRM.DatabaseServiceLayer.Services.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.DatabaseServiceLayer.Repositories.Interfaces
{
	public interface IApplication_Users : IRepository<ApplicationUsers>
	{
		List<ApplicationUsers> GetUserByRole(Guid? RoleId); 
	}
}
