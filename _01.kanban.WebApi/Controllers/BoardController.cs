using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace kanban.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BoardController : ControllerBase
{
    private readonly ILogger<BoardController> _logger;

    public BoardController(ILogger<BoardController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IActionResult Get()
    {
       return Ok("List boards ");
    }
    [HttpPost]
    public IActionResult Post()
    {
       return Ok("List boards ");
    }
    [HttpPut]
    public IActionResult Update()
    {
       return Ok("List boards ");
    }
    [HttpDelete]
    public IActionResult Delete(long id)
    {
       return Ok("List boards ");
    }
}
