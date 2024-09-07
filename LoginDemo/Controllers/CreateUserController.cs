using LoginDemo.DatabaseServices;
using LoginDemo.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace LoginDemo.Controllers;

[Route("api/[controller]")]
[Controller]
public class CreateUserController(UserService userService) : ControllerBase
{
    [HttpGet]
    public async Task<IResult> UserExistsGet([FromQuery] string email)
    {
        var user = await userService.GetAsync(email);
        if (user?.Email is not null)
            return Results.Ok(true);
        
        return Results.Ok(false);
    }
    
    [HttpPost]
    public async Task<IResult> CreateNewUserPost([FromBody] User user)
    {
        var createdId = userService.CreateAsync(user);
        if (createdId.Id > 0)
            return Results.Ok(true);
        
        return Results.Ok(false);
    }
}