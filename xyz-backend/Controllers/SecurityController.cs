using xyz_backend.Models;
using xyz_backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace  xyz_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SecurityController : ControllerBase
    {
        private SecurityService _securityService;
        public SecurityController(SecurityService securityService)
        {
            _securityService = securityService;
        }

        [HttpPost]
        public IActionResult addUser(Security security)
        {
            return Ok(_securityService.addUser(security).Result);
        }
        [HttpGet("all")]
        public IActionResult getAllUser()
        {
            return Ok(_securityService.getAllUser().Result);
        }
    }
}