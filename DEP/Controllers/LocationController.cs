using DEP.Repository.Models;
using DEP.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DEP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILocationService service;
        public LocationController(ILocationService service) { this.service = service; }

        [HttpGet]
        public async Task<IActionResult> GetLocations()
        {
            return Ok(await service.GetLocations());
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetLocationById(int id)
        {
            return Ok(await service.GetLocationById(id));
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> GetLocationByName(string name)
        {
            return Ok(await service.GetLocationByName(name));
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteLocation(int id)
        {
            return Ok(await service.DeleteLocation(id));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateLocation(Location location)
        {
            return Ok(await service.UpdateLocation(location));
        }

        [HttpPost]
        public async Task<IActionResult> AddLocation(Location location)
        {
            return Ok(await service.AddLocation(location));
        }
    }
}
