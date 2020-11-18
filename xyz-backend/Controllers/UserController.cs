using Microsoft.AspNetCore.Mvc;
using xyz_backend.Services;
using xyz_backend.Models;

namespace  xyz_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private UserService _userService;
        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public IActionResult addUser(User newUser)
        {
            return Ok(_userService.addUser(newUser).Result);
        }

        [HttpGet("all")]
        public IActionResult getAllUser()
        {
            return Ok(_userService.getAllUser().Result);
        }

        [HttpPut("approval")]
        public IActionResult approvalUser(ApprovalUser tmpUser)
        {
            return Ok(_userService.updateUser(tmpUser).Result);
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult deleteUser(string id)
        {
            return Ok(_userService.deleteUser(id).Result);
        }
    }
}