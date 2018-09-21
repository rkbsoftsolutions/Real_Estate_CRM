using CRM.DatabaseModelLayer.Context;
using CRM.DatabaseServiceLayer.Repositories.Interfaces;
using CRM.DatabaseServiceLayer.Repositories.Services;
using CRM.DatabaseServiceLayer.Services.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;




namespace CRM.Services.UnitOfWork
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly ApplicationDB context;
		public UnitOfWork(ApplicationDB _context)
		{
			context = _context;
		}
		private IApplication_Modules _IApplication_Moudels;

		public IApplication_Modules Application_Moudels {

			get
			{
				if (_IApplication_Moudels == null)
					_IApplication_Moudels = new Application_Modules_Service(context);
				return _IApplication_Moudels;
			}

		}
	}
}
