using DEP.Repository.Models;
using DEP.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DEP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILocationService service;
        public LocationController(ILocationService service) { this.service = service; }

        [HttpGet, Authorize]
        public async Task<IActionResult> GetLocations()
        {
            return Ok(await service.GetLocations());
        }

        [HttpGet("{id:int}"), Authorize]
        public async Task<IActionResult> GetLocationById(int id)
        {
            return Ok(await service.GetLocationById(id));
        }

        [HttpGet("{name}"), Authorize]
        public async Task<IActionResult> GetLocationByName(string name)
        {
            return Ok(await service.GetLocationByName(name));
        }

        [HttpDelete("{id:int}"), Authorize]
        public async Task<IActionResult> DeleteLocation(int id)
        {
            return Ok(await service.DeleteLocation(id));
        }

        [HttpPut, Authorize]
        public async Task<IActionResult> UpdateLocation(Location location)
        {
            return Ok(await service.UpdateLocation(location));
        }

        [HttpPost, Authorize]
        public async Task<IActionResult> AddLocation(Location location)
        {
            return Ok(await service.AddLocation(location));
        }
    }
}
