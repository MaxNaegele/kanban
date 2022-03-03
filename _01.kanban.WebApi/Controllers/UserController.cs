using _02.kanban.Application.Interfaces.Application;
using _04.kanban.Core.ModelView.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace kanban.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserApplication _IUserApplication;
    public UserController(IUserApplication iUserApplication)
    {
        _IUserApplication = iUserApplication;
    }

    [HttpGet, AllowAnonymous]
    public async Task<IActionResult> Get()
    {
        return Ok(await _IUserApplication.GetUser());
    }
    [HttpPost, Route("Login"), AllowAnonymous]
    public async Task<IActionResult> Login([FromBody] UserLoginView login)
    {
        var token = await _IUserApplication.ExecuteLogin(login.Email, login.Password);
        if (token is not null)
            return Ok(token);
        return Unauthorized();
    }
    [HttpPost, AllowAnonymous]
    public async Task<IActionResult> Post([FromBody] UserView user)
    {
        var userInsert = await _IUserApplication.Create(user);
        return CreatedAtAction(nameof(Get), new { login = user.UseEmail }, userInsert);
    }
}
