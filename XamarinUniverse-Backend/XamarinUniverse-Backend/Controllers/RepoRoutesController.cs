using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XamarinUniverse_Backend.Services;

namespace XamarinUniverse_Backend.Controllers
{
    [Route("repos/[controller]")]
    [ApiController]
    public class RepoRoutesController : ControllerBase
    {
        private readonly IGithubFilesService _ghService;

        public RepoRoutesController(IGithubFilesService ghService)
        {
            _ghService = ghService;
        }

        // Github files prototype.
        // To be refactor
        [HttpGet("{owner}/{repo}/{*path}")]
        public async Task<IActionResult> Get(string owner, string repo, string path)
        {
            var file = await _ghService.GetFileFromGithub(owner, repo, path);
            if (file==null)
            {
                return NotFound();
            }
            if (file.IsMd)
            {
                return File(Encoding.UTF8.GetBytes($"<!doctype html><html lang=\"en\"></head><body>{await _ghService.RepoMdToHtml(file)}</body></html>"), "text/html");
            }

            return File(await _ghService.RepoFileStream(file), "application/octet-stream", file.Name);
        }
    }
}