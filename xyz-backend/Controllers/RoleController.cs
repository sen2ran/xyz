using Microsoft.AspNetCore.Mvc;
using xyz_backend.Services;
using xyz_backend.Models;

namespace  xyz_backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RoleController : ControllerBase
    {
        private RoleService _roleService;

        public RoleController(RoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet]
        public IActionResult GetAllRoles()
        {
            return Ok(_roleService.getAllRole().Result);
        }

        [HttpPost]
        public IActionResult addRole(Role newRole)
        {
            return Ok(_roleService.addRole(newRole).Result);
        }
    }
}

