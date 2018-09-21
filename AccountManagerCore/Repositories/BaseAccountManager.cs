using AccountCore.DataModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountCore.Repositories
{
	class BaseAccountManager
	{
		
		public BaseAccountManager() {

		}

		public BaseAccountManager(UserManager<ApplicationUsers> userManager)
		{
			

		}


	}
}
