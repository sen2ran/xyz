using Microsoft.AspNetCore.Mvc;
using xyz_backend.Services;
using xyz_backend.Models;

namespace xyz_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DressTypeController : ControllerBase
    {
        private DressTypeService _dressTypeService;
        public DressTypeController(DressTypeService dressTypeService)
        {
            _dressTypeService = dressTypeService;
        }
        [HttpPost]
        public IActionResult addDress(DressType dressType)
        {
            return Ok(_dressTypeService.addDress(dressType).Result);
        }
        [HttpGet("all")]
        public IActionResult getAll()
        {
            return Ok(_dressTypeService.getAll().Result);
        }
    }
}