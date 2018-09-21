using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CRM.DatabaseModelLayer.Models;
using CRM.DatabaseServiceLayer.Services.UnitOfWork;
using Microsoft.AspNetCore.Mvc;



namespace CRM.RealEstate.Controllers.Admin
{
	[Area("Admin")]
	public class ModulesController : Controller
	{

		IUnitOfWork IUnitOfWork;
		public ModulesController(IUnitOfWork _IUnitOfWork)
		{
		
			
			IUnitOfWork = _IUnitOfWork;
		}


		public IActionResult Modules()
		{

			IEnumerable<Application_Modules> application_Moudels = IUnitOfWork.Application_Moudels.GetAll();
			return View();
		}

		public IActionResult ModulesConfig() {

			var list=IUnitOfWork.Application_Moudels.GetModulesAndAssignedPermissionAsync();
			return View();

		}




	}
}
