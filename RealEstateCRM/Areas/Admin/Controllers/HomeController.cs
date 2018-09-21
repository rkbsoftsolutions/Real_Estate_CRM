using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CRM.DatabaseServiceLayer.Services.UnitOfWork;
using Microsoft.AspNetCore.Mvc;


namespace CRM.RealEstate.Controllers.Admin
{
	public class HomeController : Controller
	{

		IUnitOfWork IUnitOfWork;
		public HomeController(IUnitOfWork _IUnitOfWork)
		{
			IUnitOfWork = _IUnitOfWork;
		}




	}
}
