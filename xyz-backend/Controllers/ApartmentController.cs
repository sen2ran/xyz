using Microsoft.AspNetCore.Mvc;
using xyz_backend.Services;
using xyz_backend.Models;

namespace  xyz_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApartmentController : ControllerBase
    {
        private ApartmentService _apartmentService;
        public ApartmentController(ApartmentService apartmentService)
        {
            _apartmentService = apartmentService;
        }

        [HttpGet("all")]
        public IActionResult getAll()
        {
            return Ok(_apartmentService.getAll().Result);
        }

        [HttpPost]
        public IActionResult addApartment(ReqApartment apartment)
        {
            return Ok(_apartmentService.addApartment(apartment).Result);
        }

        [HttpGet("single/{id:length(24)}")]
        public IActionResult getAllUnitById(string id)
        {
            return Ok(_apartmentService.getAllUnitById(id).Result);
        }

        [HttpPost("single/{id:length(24)}")]
        public IActionResult addUnitById(string id, Unit payload)
        {
            return Ok(_apartmentService.addUnitById(id, payload).Result);
        }
    }
}