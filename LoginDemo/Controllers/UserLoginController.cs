using LoginDemo.DatabaseServices;
using Microsoft.AspNetCore.Mvc;

namespace LoginDemo.Controllers;

[Route("api/[controller]")]
[Controller]
public class UserLoginController(UserService userService) : ControllerBase
{
    [HttpPost]
    public async Task<IResult> UserLoginPost([FromBody] LoginInfo loginInfo)
    {
        var user = await userService.GetAsync(loginInfo.Email);
        if (user.Password == loginInfo.Password)
            return Results.Ok(true);
        
        return Results.Ok(false);
    }
}