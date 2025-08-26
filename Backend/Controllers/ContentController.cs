using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Backend.Models;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContentController : ControllerBase
    {
        [HttpGet("admin")]
        [Authorize(Roles = Roles.Admin)]
        public IActionResult GetAdminContent()
        {
            return Ok("Admins.");
        }

        [HttpGet("editor")]
        [Authorize(Roles = Roles.Editor)]
        public IActionResult GetEditorContent()
        {
            return Ok(" Editors.");
        }

        [HttpGet("viewer")]
        [Authorize(Roles = Roles.Viewer)]
        public IActionResult GetViewerContent()
        {
            return Ok("Viewers.");
        }

    }
}
