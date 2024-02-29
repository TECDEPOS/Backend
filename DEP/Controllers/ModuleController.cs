using DEP.Repository.Models;
using DEP.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DEP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModuleController : ControllerBase
    {
        private readonly IModuleService service;
        public ModuleController(IModuleService service) { this.service = service; }

        [HttpGet, Authorize]
        public async Task<IActionResult> GetModules()
        {
            return Ok(await service.GetModules());
        }

        [HttpPost, Authorize]
        public async Task<IActionResult> AddModule(Module module)
        {
            return Ok(await service.AddModule(module));
        }

        [HttpDelete("{id:int}"), Authorize]
        public async Task<IActionResult> DeleteModule(int id)
        {
            return Ok(await service.DeleteModule(id));
        }

        [HttpPut, Authorize]
        public async Task<IActionResult> UpdateModule(Module module)
        {
            return Ok(await service.UpdateModule(module));
        }

    }
}
