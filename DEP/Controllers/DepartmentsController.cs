using DEP.Repository.Models;
using DEP.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DEP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentService depService;
        public DepartmentsController(IDepartmentService depService)
        {
            this.depService = depService;
        }

        [HttpGet, Authorize]
        public async Task<IActionResult> GetDepartments()
        {
            return Ok(await depService.GetDepartments());
        }

        [HttpPost, Authorize]
        public async Task<IActionResult> AddDepartment(Department department)
        {
            var dep = await depService.AddDepartment(department);

            return Ok(dep);
        }

        [HttpPut, Authorize]
        public async Task<IActionResult> UpdateDepartment(Department department)
        {
            return Ok(await depService.UpdateDepartment(department));
        }

        [HttpDelete("{id:int}"), Authorize]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            var success = await depService.DeleteDepartment(id);

            return Ok(success);
        }
    }
}
