using eCommerceSolution.UsersService.Core.Dtos;
using eCommerceSolution.UsersService.Core.ServiceContracts;
using Microsoft.AspNetCore.Mvc;

namespace eCommerceSolution.UsersService.API.Controllers;

[Route("api/[controller]")] // api/auth
[ApiController]
public class AuthController(IUsersService usersService) : ControllerBase
{
    
    [HttpPost("register")] // api/auth/register
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        if (request == null)
        {
            return BadRequest("Invalid register request");
        }
        
        // Call the UsersService to register the user
        AuthenticationResponse? response = await usersService.Register(request);
        
        if (response == null || response.Success == false)
        {
            return BadRequest(response);
        }
        
        return Ok(response);
    }

    [HttpPost("login")] // api/auth/login
    public async Task<IActionResult> Login(LoginRequest request)
    {
        if (request == null)
        {
            return BadRequest("Invalid login request");
        }
        
        // Call the UsersService to login the user
        AuthenticationResponse? response = await usersService.Login(request);
        if (response == null || response.Success == false)
        {
            return Unauthorized(response);
        }
        return Ok(response);
    }
}