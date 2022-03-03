using _02.kanban.Application.Interfaces.Application;
using _04.kanban.Core.ModelView.Board;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace kanban.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BoardController : ControllerBase
{
    private readonly IBoardApplication _IBoardApplication;

    public BoardController(IBoardApplication iBoardApplication)
    {
        _IBoardApplication = iBoardApplication;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(await _IBoardApplication.FindAll());
    }
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] BoardView board)
    {
       
        return Ok(await _IBoardApplication.Create(board));
      
    }
}
