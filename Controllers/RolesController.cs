using Microsoft.AspNetCore.Mvc;
using Nupat_CSharp.Service;

namespace Nupat_CSharp.Controllers
{
    public class RolesController : Controller
    {
        private readonly IRolesService _rolesService;

        public RolesController(IRolesService rolesService)
        {
            _rolesService = rolesService;
        }
        public IActionResult CreateRole()
        {
            return View();
        }

        public async Task<IActionResult> AddRole(string roleName)
        {
            var result = await _rolesService.CreateRole(roleName);
            if (string.IsNullOrEmpty(result))
            {
                return View("CreateRole");
            }
            string error = result;
            ViewBag.RoleName= error;    
            return View("CreateRole");
        }

        public IActionResult UserRole()
        {
            return View();
        }


        public async Task<IActionResult> AddUserToRole(string user, string roleName)
        {
            var result = await _rolesService.AddUserToRole(user, roleName);
            if (string.IsNullOrEmpty(result))
            {
                return View("UserRole");
            }
            string error = result;
            ViewBag.RoleName = error;
            return View("UserRole");

        }



    }
}
