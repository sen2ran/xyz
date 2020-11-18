using Microsoft.AspNetCore.Mvc;
using xyz_backend.Services;
using xyz_backend.Models;
using System;
using Microsoft.AspNetCore.Cors;

namespace  xyz_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private UserService _userService;
        private AdminService _adminService;
        public AuthController(UserService userService, AdminService adminService)
        {
            _userService = userService;
            _adminService = adminService;
        }
        [HttpPost("user")]
        public IActionResult userLogin(LoginUser loginUser)
        {
            return Ok(_userService.login(loginUser).Result);
        }
        [HttpPost("admin")]
        public IActionResult adminLogin(LoginUser loginUser)
        {
            return Ok(_adminService.login(loginUser).Result);
        }
    }
}