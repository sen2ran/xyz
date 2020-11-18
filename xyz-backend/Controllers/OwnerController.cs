using xyz_backend.Models;
using xyz_backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace  xyz_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OwnerController : ControllerBase
    {
        private OwnerService _ownerService;
        public OwnerController(OwnerService ownerService)
        {
            _ownerService = ownerService;
        }
        [HttpPost]
        public IActionResult addOwner(Owner owner)
        {
            return Ok(_ownerService.addOwner(owner).Result);
        }


        [HttpGet("all")]
        public IActionResult getAll()
        {
            return Ok(_ownerService.getAll().Result);
        }

        [HttpGet("list/{nameString}")]
        public IActionResult GetOwnerByName(string nameString)
        {
            return Ok(_ownerService.GetOwnerByName(nameString).Result);
        }
    }
}