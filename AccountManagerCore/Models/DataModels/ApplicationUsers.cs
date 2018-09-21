using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AccountCore.DataModels
{

	public partial class ApplicationUsers : IdentityUser<Guid>
	{
		public ApplicationUsers()
		{
		}
	}

    public class ApplicationRoles : IdentityRole<Guid>
    {

        public ApplicationRoles()
        {

        }
        public ApplicationRoles(string roleName) : base(roleName)
        {
        }
    }
	public class ApplicationUserRole : IdentityUserRole<Guid>
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public Guid ApplicationUserRoleId { get; set; }
	}
}