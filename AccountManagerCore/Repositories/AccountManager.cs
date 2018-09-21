using AccountCore.DataModels;
using AccountCore.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;


namespace AccountCore.Repositories
{

    public enum UserFindBy { FindByEmail, FindByName, FindById }




    public class AccountManager : IAccountManager
    {

        private readonly UserManager<ApplicationUsers> userManager;
        private readonly SignInManager<ApplicationUsers> signInManager;
        private readonly IHttpContextAccessor httpAccessor;
        private readonly RoleManager<ApplicationRoles> _roleManager;
        public string CurrentUserId
        {
            get
            {

                return userManager.GetUserId(httpAccessor.HttpContext.User);
            }
        }

		public Claim CurrentUserClaim
		{
			get
			{

				return httpAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
			}
		}


		

		public AccountManager(UserManager<ApplicationUsers> userManager,
            IHttpContextAccessor httpAccessor,
            RoleManager<ApplicationRoles> _roleManager,
            SignInManager<ApplicationUsers> _signInManager
            )
        {
            this.userManager = userManager;
            this.httpAccessor = httpAccessor;
            this._roleManager = _roleManager;
            this.signInManager = _signInManager;
        }

        public async Task<(bool, string[])> CreateUserAsync(ApplicationUsers user, IEnumerable<string> roles, string password)
        {

			var result = await userManager.CreateAsync(user, password);
            if (!result.Succeeded)
                return (false, result.Errors.Select(e => e.Description).ToArray());
            user = await userManager.FindByNameAsync(user.UserName);
            try
            {
                result = await this.userManager.AddToRolesAsync(user, roles.Distinct());
            }
            catch (Exception ex)
            {
                await DeleteUserAsync(user);
                throw;
            }

            if (!result.Succeeded)
            {
                await DeleteUserAsync(user);
                return (false, result.Errors.Select(e => e.Description).ToArray());
            }

            return (true, new string[] { });
        }
        public async Task<IdentityResult> CreateUserAsync(ApplicationUsers user)
        {
            return await userManager.CreateAsync(user);
        }
        public async Task<(bool, string[])> DeleteUserAsync(string userId)
        {
            var user = await userManager.FindByIdAsync(userId);

            if (user != null)
                return await DeleteUserAsync(user);

            return (true, new string[] { });
        }
        public async Task<(bool, string[])> DeleteUserAsync(ApplicationUsers user)
        {
            var result = await userManager.DeleteAsync(user);
            return (result.Succeeded, result.Errors.Select(e => e.Description).ToArray());
        }

        public async Task<ApplicationUsers> GetUserByUserNameAsync(string userName)
        {
            var _user = await userManager.FindByNameAsync(userName);
            if (_user != null)
            {
                if (_user.LockoutEnabled == true)
                    return _user;
                else
                    return null;
            }
            return null;
        }

        public async Task<ApplicationUsers> GetUserByEmailAsync(string email)
        {
            return await userManager.FindByEmailAsync(email);
        }

        public async Task<IList<string>> GetUserRolesAsync(ApplicationUsers user)
        {
            return await userManager.GetRolesAsync(user);
        }


        public async Task<(ApplicationUsers, string[])> GetUserAndRolesAsync(string userId)
        {
            throw new NotSupportedException();
            //var user = await _context.Users
            //	.Include(u => u.Roles)
            //	.Where(u => u.Id == userId)
            //	.FirstOrDefaultAsync();

            //if (user == null)
            //	return null;

            //var userRoleIds = user.Roles.Select(r => r.RoleId).ToList();

            //var roles = await _context.Roles
            //	.Where(r => userRoleIds.Contains(r.Id))
            //	.Select(r => r.Name)
            //	.ToArrayAsync();

            //return Tuple.Create(user, roles);
        }


        public async Task<List<(ApplicationUsers, string[])>> GetUsersAndRolesAsync(int page, int pageSize)
        {
            throw new NotSupportedException();

            //IQueryable<ApplicationUsers> usersQuery = _context.Users
            //	.Include(u => u.Roles)
            //	.OrderBy(u => u.UserName);

            //if (page != -1)
            //	usersQuery = usersQuery.Skip((page - 1) * pageSize);

            //if (pageSize != -1)
            //	usersQuery = usersQuery.Take(pageSize);

            //var users = await usersQuery.ToListAsync();

            //var userRoleIds = users.SelectMany(u => u.Roles.Select(r => r.RoleId)).ToList();

            //var roles = await _context.Roles
            //	.Where(r => userRoleIds.Contains(r.Id))
            //	.ToArrayAsync();

            //return users.Select(u => Tuple.Create(u,
            //	roles.Where(r => u.Roles.Select(ur => ur.RoleId).Contains(r.Id)).Select(r => r.Name).ToArray()))
            //	.ToList();
        }

        public async Task<ApplicationUsers> GetUserByIdAsync(string userId)
        {
            return await userManager.FindByIdAsync(userId);
        }

        public async Task<(bool, string[])> UpdateUserAsync(ApplicationUsers user)
        {
            return await UpdateUserAsync(user, null);
        }


        public async Task<(bool, string[])> UpdateUserAsync(ApplicationUsers user, IEnumerable<string> roles)
        {
            var result = await userManager.UpdateAsync(user);
            if (!result.Succeeded)
                return (false, result.Errors.Select(e => e.Description).ToArray());


            if (roles != null)
            {
                var userRoles = await userManager.GetRolesAsync(user);

                var rolesToRemove = userRoles.Except(roles).ToArray();
                var rolesToAdd = roles.Except(userRoles).Distinct().ToArray();

                if (rolesToRemove.Any())
                {
                    result = await userManager.RemoveFromRolesAsync(user, rolesToRemove);
                    if (!result.Succeeded)
                        return (false, result.Errors.Select(e => e.Description).ToArray());
                }

                if (rolesToAdd.Any())
                {
                    result = await userManager.AddToRolesAsync(user, rolesToAdd);
                    if (!result.Succeeded)
                        return (false, result.Errors.Select(e => e.Description).ToArray());
                }
            }

            return (true, new string[] { });
        }


        public async Task<(bool, string[])> ResetPasswordAsync(ApplicationUsers user, string newPassword)
        {
            string resetToken = await userManager.GeneratePasswordResetTokenAsync(user);

            var result = await userManager.ResetPasswordAsync(user, resetToken, newPassword);
            if (!result.Succeeded)
                return (false, result.Errors.Select(e => e.Description).ToArray());

            return (true, new string[] { });
        }

        public async Task<(bool, string[])> UpdatePasswordAsync(ApplicationUsers user, string currentPassword, string newPassword)
        {
            var result = await userManager.ChangePasswordAsync(user, currentPassword, newPassword);
            if (!result.Succeeded)
                return (false, result.Errors.Select(e => e.Description).ToArray());

            return (true, new string[] { });
        }

        public async Task<bool> CheckPasswordAsync(ApplicationUsers user, string password)
        {
            return await userManager.CheckPasswordAsync(user, password);
            //{
            //	if (!userManager.SupportsUserLockout)
            //		await userManager.AccessFailedAsync(user);

            //	return false;
            //}

            //return true;
        }

        public async Task<(bool, string[])> CreateRoleAsync(ApplicationRoles role, IEnumerable<string> claims)
        {
            if (claims == null)
                claims = new string[] { };

            //string[] invalidClaims = claims.Where(c => ApplicationPermissions.GetPermissionByValue(c) == null).ToArray();
            //if (invalidClaims.Any())
            //	return Tuple.Create(false, new[] { "The following claim types are invalid: " + string.Join(", ", invalidClaims) });


            var result = await _roleManager.CreateAsync(role);
            if (!result.Succeeded)
                return (false, result.Errors.Select(e => e.Description).ToArray());


            //role = await _roleManager.FindByNameAsync(role.Name);

            //foreach (string claim in claims.Distinct())
            //{
            //	result = await this._roleManager.AddClaimAsync(role, new Claim(CustomClaimTypes.Permission, ApplicationPermissions.GetPermissionByValue(claim)));

            //	if (!result.Succeeded)
            //	{
            //		await DeleteRoleAsync(role);
            //		return Tuple.Create(false, result.Errors.Select(e => e.Description).ToArray());
            //	}
            //}

            return (true, new string[] { });
        }

        //public async Task<ApplicationRole> GetRoleByIdAsync(string roleId)
        //{
        //	return await _roleManager.FindByIdAsync(roleId);
        //}


        public async Task<ApplicationRoles> GetRoleByNameAsync(string roleName)
        {
            return await _roleManager.FindByNameAsync(roleName);
        }

        public async Task SignInAsync(ApplicationUsers user, bool isPersistent, string authenticationMethod = null)
        {
            await signInManager.SignInAsync(user, isPersistent);
        }

        public async Task<IdentityResult> SetLockoutEnabledAsync(ApplicationUsers user, bool enabled)
        {
            return await userManager.SetLockoutEnabledAsync(user, enabled);
        }

        public async Task SignOutAsync()
        {
            await signInManager.SignOutAsync();
        }


        public async Task<ApplicationUsers> GetTwoFactorAuthenticationUserAsync()
        {
            return await signInManager.GetTwoFactorAuthenticationUserAsync();
        }




        //public async Task<ApplicationRole> GetRoleLoadRelatedAsync(string roleName)
        //{
        //	var role = await _context.Roles
        //		.Include(r => r.Claims)
        //		.Include(r => r.Users)
        //		.Where(r => r.Name == roleName)
        //		.FirstOrDefaultAsync();

        //	return role;
        //}


        //public async Task<List<ApplicationRole>> GetRolesLoadRelatedAsync(int page, int pageSize)
        //{
        //	IQueryable<ApplicationRole> rolesQuery = _context.Roles
        //		.Include(r => r.Claims)
        //		.Include(r => r.Users)
        //		.OrderBy(r => r.Name);

        //	if (page != -1)
        //		rolesQuery = rolesQuery.Skip((page - 1) * pageSize);

        //	if (pageSize != -1)
        //		rolesQuery = rolesQuery.Take(pageSize);

        //	var roles = await rolesQuery.ToListAsync();

        //	return roles;
        //}




        //public async Task<Tuple<bool, string[]>> UpdateRoleAsync(ApplicationRole role, IEnumerable<string> claims)
        //{
        //	if (claims != null)
        //	{
        //		string[] invalidClaims = claims.Where(c => ApplicationPermissions.GetPermissionByValue(c) == null).ToArray();
        //		if (invalidClaims.Any())
        //			return Tuple.Create(false, new[] { "The following claim types are invalid: " + string.Join(", ", invalidClaims) });
        //	}


        //	var result = await _roleManager.UpdateAsync(role);
        //	if (!result.Succeeded)
        //		return Tuple.Create(false, result.Errors.Select(e => e.Description).ToArray());


        //	if (claims != null)
        //	{
        //		var roleClaims = (await _roleManager.GetClaimsAsync(role)).Where(c => c.Type == CustomClaimTypes.Permission);
        //		var roleClaimValues = roleClaims.Select(c => c.Value).ToArray();

        //		var claimsToRemove = roleClaimValues.Except(claims).ToArray();
        //		var claimsToAdd = claims.Except(roleClaimValues).Distinct().ToArray();

        //		if (claimsToRemove.Any())
        //		{
        //			foreach (string claim in claimsToRemove)
        //			{
        //				result = await _roleManager.RemoveClaimAsync(role, roleClaims.Where(c => c.Value == claim).FirstOrDefault());
        //				if (!result.Succeeded)
        //					return Tuple.Create(false, result.Errors.Select(e => e.Description).ToArray());
        //			}
        //		}

        //		if (claimsToAdd.Any())
        //		{
        //			foreach (string claim in claimsToAdd)
        //			{
        //				result = await _roleManager.AddClaimAsync(role, new Claim(CustomClaimTypes.Permission, ApplicationPermissions.GetPermissionByValue(claim)));
        //				if (!result.Succeeded)
        //					return Tuple.Create(false, result.Errors.Select(e => e.Description).ToArray());
        //			}
        //		}
        //	}

        //	return Tuple.Create(true, new string[] { });
        //}


        //public async Task<bool> TestCanDeleteRoleAsync(string roleId)
        //{
        //	return !await _context.UserRoles.Where(r => r.RoleId == roleId).AnyAsync();
        //}

    }
}
