using CRM.DatabaseServiceLayer.Services.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;
using CRM.Services.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.DatabaseServiceLayer.ServiceInject
{
    public static class ServiceInject
    {


		public static IServiceCollection AddEntitiesWithUnitofWork(this IServiceCollection services)
		{

			services.AddTransient<IUnitOfWork, UnitOfWork>();
			return services;
		}

    }
}
