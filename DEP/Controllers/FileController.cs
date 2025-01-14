using DEP.Repository.Context;
using DEP.Repository.Models;
using DEP.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using System.Net;
using System.Text.Json;

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
            if (file == null)
            {
                return NotFound();
            }

            var path = Path.Combine(configuration.GetSection("Appsettings:AppDirectory").Value, file.FilePath);

            if (!System.IO.File.Exists(path))
            {
                return NotFound();
            }

            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;

            var contentType = GetContentType(path); // Retrieve the content type dynamically
            var fileName = file.FileName;

            return File(memory, contentType, fileName);
        }

        private string GetContentType(string path)
        {
            var provider = new FileExtensionContentTypeProvider();
            if (!provider.TryGetContentType(path, out var contentType))
            {
                contentType = "application/octet-stream";
            }
            return contentType;
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
        public async Task<IActionResult> AddMultipleFiles([FromForm] List<IFormFile> files, [FromForm] string fileTags, [FromForm] int personId)
        {
            try
            {
                if (files == null || !files.Any())
                {
                    return BadRequest("No files uploaded.");
                }

                var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                var fileTagList = JsonSerializer.Deserialize<List<FileTag>>(fileTags!, options);

                var uploadedFiles = await service.AddMultipleFiles(files, fileTagList, personId);

                return Ok(uploadedFiles);
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
