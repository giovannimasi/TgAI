using Microsoft.AspNetCore.Mvc;

namespace TgAI.Controllers;

[Route("bot")]
[ApiController]
[Tags("OpenAI Requests")]
public sealed class RequestController : Controller
{
    [HttpGet("")]
    public IActionResult Get()
    {
        return View();
    }
}
