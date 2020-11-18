using Microsoft.AspNetCore.Mvc;
using xyz_backend.Services;
using xyz_backend.Models;

namespace  xyz_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminController : ControllerBase
    {
        private AdminService _adminService;
        public AdminController(AdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpPost]
        public IActionResult addUser(Admin newUser)
        {
            return Ok(_adminService.addUser(newUser).Result);
        }

        [HttpGet("all")]
        public IActionResult getAllUser()
        {
            return Ok(_adminService.getAllUser().Result);
        }

        [HttpPut]
        public IActionResult updateUser(Admin tmpUser)
        {
            return Ok(_adminService.updateUser(tmpUser).Result);
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult deleteUser(string id)
        {
            return Ok(_adminService.deleteUser(id).Result);
        }
    }
}