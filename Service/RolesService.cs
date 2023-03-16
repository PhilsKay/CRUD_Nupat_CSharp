using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Nupat_CSharp.Models;

namespace Nupat_CSharp.Service
{
    
    public class RolesService : IRolesService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public RolesService(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            _roleManager = roleManager; 
            _userManager = userManager; 
        }
        /// <summary>
        /// Create Role
        /// </summary>
        /// <param name="user"></param>
        /// <param name="roleName"></param>
        /// <returns></returns>
        public async Task<string> AddUserToRole(string user, string roleName)
        {

            return string.Empty;
        }

        public async Task<string> CreateRole(string roleName)
        {

            var checkIfRoleExist = await _roleManager.RoleExistsAsync(roleName);
            if (!checkIfRoleExist)
            {
                IdentityRole role = new IdentityRole()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = roleName,
                };
                var result = await _roleManager.CreateAsync(role);

                if (result.Succeeded)
                {
                    return string.Empty;
                }
                else
                {
                    return result.Errors.First().Description;
                }
            }

            return "Role already exist";
          
        }
    }
}
