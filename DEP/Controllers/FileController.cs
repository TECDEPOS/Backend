using DEP.Repository.Context;
using DEP.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace DEP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IConfiguration configuration;
        private readonly DatabaseContext context;
        private readonly IFileService service;

        public FileController(IFileService service, DatabaseContext context, IConfiguration configuration)
        { this.service = service; this.context = context; this.configuration = configuration; }

        [HttpGet("role/{roleId:int}"), Authorize]
        public async Task<IActionResult> GetFiles(int roleId)
        {
            try
            {
                return Ok(await service.GetFiles(roleId));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id:int}"), Authorize]
        public async Task<IActionResult> GetFileById(int id)
        {
            try
            {
                var file = await service.GetFileById(id);
                if (file == null)
                {
                    return NotFound("Awww Dang it!");
                }
                return Ok(file);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpGet("{name}"), Authorize]
        public async Task<IActionResult> GetFileByName(string name)
        {
            try
            {
                var file = await service.GetFileByName(name);
                if (file == null)
                {
                    return NotFound("Better luck next time!");
                }
                return Ok(file);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpGet("DownloadFile/{id:int}")]
        public async Task<IActionResult> DownloadFile(int id)
        {
            var file = context.Files.Where(f => f.FileId == id).FirstOrDefault();

            var path = Path.Combine(configuration.GetSection("Appsettings:AppDirectory").Value, file.FilePath);

            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            var contentType = "APPLICATION/octet-stream";
            var fileName = file.FileName;

            return File(memory, contentType, fileName);
        }

        [HttpPost("{userId:int}/{tagId:int}")]
        public async Task<IActionResult> AddFile(IFormFile file, int userId, int tagId)
        {
            try
            {
                if (file == null)
                {
                    return NotFound("File not Given? Be better than that!");
                }
                return Created("File", await service.AddFile(file, userId, tagId));
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpPost("multiple")]
        public async Task<IActionResult> AddMultipleFiles()
        {
            var formData = Request.Form;

            try
            {
                if (formData == null)
                {
                    return NotFound("Form is null");
                }
                return Created("File", await service.AddMultipleFiles(formData));
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        /*[HttpPut]
        public async Task<IActionResult> UpdateFile(File file)
        {
            try
            {
                if(file is null)
                {
                    return NotFound("What piece of sheeeit is this!?");
                }
                return Ok(await service.UpdateFile(file));
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        } */

        [HttpDelete("{id:int}"), Authorize]
        public async Task<IActionResult> Deletefile(int id)
        {
            try
            {
                return Ok(await service.DeleteFile(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
