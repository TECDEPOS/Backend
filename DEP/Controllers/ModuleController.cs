using DEP.Repository.Models;
using DEP.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DEP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModuleController : ControllerBase
    {
        private readonly IModuleService service;
        public ModuleController(IModuleService service) { this.service = service; }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetModuleById(int id)
        {
            return Ok(await service.GetModuleById(id));
        }

        [HttpGet]
        public async Task<IActionResult> GetModules()
        {
            return Ok(await service.GetModules());
        }

        [HttpGet("Type/{type:int}")]
        public async Task<IActionResult> GetModulesByType(int type)
        {
            return Ok(await service.GetModulesByType(type));
        }

        [HttpPost]
        public async Task<IActionResult> AddModule(Module module)
        {
            return Ok(await service.AddModule(module));
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteModule(int id)
        {
            return Ok(await service.DeleteModule(id));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateModule(Module module)
        {
            return Ok(await service.UpdateModule(module));
        }

    }
}
