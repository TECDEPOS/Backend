using DEP.Repository.Models;
using DEP.Repository.ViewModels;
using DEP.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DEP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileTagController : ControllerBase
    {
        private readonly IFileTagService service;

        public FileTagController(IFileTagService service) { this.service = service; }

        [HttpGet, Authorize]
        public async Task<IActionResult> GetFileTags()
        {
            return Ok(await service.GetFileTags());
        }

        [HttpGet("{id:int}"), Authorize]
        public async Task<IActionResult> GetFileTagById(int id)
        {
            try
            {
                var file = await service.GetFileTagById(id);
                if (file == null)
                {
                    return NotFound();
                }
                return Ok(file);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{name}"), Authorize]
        public async Task<IActionResult> GetFileTagByName(string name)
        {
            try
            {
                var file = await service.GetFileTagByName(name);
                if (file == null)
                {
                    return NotFound();
                }
                return Ok(file);

            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpPost, Authorize]
        public async Task<IActionResult> AddFileTag(FileTagViewModel fileTag)
        {
            try
            {
                return Ok(await service.AddFileTag(fileTag));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut, Authorize]
        public async Task<IActionResult> UpdateFileTag(FileTagViewModel fileTag)
        {
            try
            {
                if (fileTag == null)
                {
                    return NotFound("Invalid FileTag");
                }
                return Ok(await service.UpdateFileTag(fileTag));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id:int}"), Authorize]
        public async Task<IActionResult> DeleteFileTag(int id)
        {
            try
            {
                return Ok(await service.DeleteFileTag(id));
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}
