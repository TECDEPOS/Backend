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

            if (dep is null)
            {
                return BadRequest($"An error has occurred, unable to add new department.");
            }

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

            if (!success)
            {
                return BadRequest($"Something went wrong, unable to delete department.");
            }
            return Ok(success);
        }
    }
}
