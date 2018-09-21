using CRM.DatabaseModelLayer.Models;
using CRM.DatabaseServiceLayer.Repositories.ViewModels;
using CRM.DatabaseServiceLayer.Services.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CRM.DatabaseServiceLayer.Repositories.Interfaces
{
	public interface IApplication_Modules : IRepository<Application_Modules>
	{
	Task<List<ModulesViewModel>> GetModulesAndAssignedPermissionAsync();
	}
}
