using AccountCore.Repositories;
using AccountCore.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountCore.ServiceInjects
{
  public static  class ServiceInjects
    {
		public static IServiceCollection AddAccountManager(this IServiceCollection services)
		{

			services.AddTransient<IAccountManager, AccountManager>();
			return services;
		}
	}
}
