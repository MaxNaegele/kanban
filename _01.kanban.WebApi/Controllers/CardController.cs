using _02.kanban.Application.Interfaces.Application;
using _04.kanban.Core.ModelView.Card;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace kanban.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CardController : ControllerBase
{
    private readonly ICardApplication _ICardApplication;

    public CardController(ICardApplication iCardApplication)
    {
        _ICardApplication = iCardApplication;
    }

    [HttpGet]
    public async Task<IActionResult> Get(long grpId)
    {
        return Ok(await _ICardApplication.FindAll(grpId));
    }
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CardView card)
    {
        try
        {
            return Ok(await _ICardApplication.Create(card));
        }
        catch (System.Exception ex)
        {
            return BadRequest(ex);
        }
    }
    [HttpPut]
    public async Task<IActionResult> Pust([FromBody] CardUpdateView card)
    {
        return Ok(await _ICardApplication.Update(card));
    }
}
