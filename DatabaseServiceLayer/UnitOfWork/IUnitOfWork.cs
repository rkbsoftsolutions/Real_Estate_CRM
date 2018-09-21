using CRM.DatabaseServiceLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;


namespace CRM.DatabaseServiceLayer.Services.UnitOfWork
{
	public interface IUnitOfWork
	{
		IApplication_Modules Application_Moudels { get; }
	}
}
