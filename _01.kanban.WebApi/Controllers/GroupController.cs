using _02.kanban.Application.Interfaces.Application;
using _04.kanban.Core.ModelView.Group;
using Microsoft.AspNetCore.Mvc;

namespace kanban.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GroupController : ControllerBase
{
    private readonly IGroupApplication _IGroupApplication;
    public GroupController(IGroupApplication iGroupApplication)
    {
        _IGroupApplication = iGroupApplication;
    }

    [HttpGet]
    public async Task<IActionResult> Get(long BrdId)
    {
        return Ok(await _IGroupApplication.FindAll(BrdId));
    }
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] GroupView group)
    {
        return Ok(await _IGroupApplication.Create(group));
    }
    [HttpPut]
    public async Task<IActionResult> Put([FromBody] GroupUpdateView group)
    {
        return Ok(await _IGroupApplication.Update(group));

    }
    [HttpDelete]
    public async Task<IActionResult> Delete(long id)
    {
        await _IGroupApplication.Delete(id);
        return Ok();
    }
}
