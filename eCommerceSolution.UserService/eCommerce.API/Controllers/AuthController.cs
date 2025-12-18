using eCommerce.Core.Dtos;
using eCommerce.Core.ServiceContracts;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.API.Controllers;

[Route("api/[controller]")] // /api/auth
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IUsersService _usersService;

    public AuthController(IUsersService usersService)
    {
        _usersService = usersService;
    }
    
    [HttpPost("register")] // POST /api/auth/register
    public async Task<IActionResult> Register(RegisterRequest registerRequest)
    {
        if (registerRequest == null) return BadRequest("Invalid register request");
        
        // call the UsersService to register the user
        AuthenticationResponse? response = await _usersService.Register(registerRequest);
        
        if (response == null || response.Success == false)
        {
            return BadRequest(response); 
        }
        return Ok(response);
    }

    [HttpPost("login")] // POST /api/auth/login
    public async Task<IActionResult> Login(LoginRequest loginRequest)
    {
        // Check for invalid login request
        if (loginRequest == null) return BadRequest("Invalid login request");
        
        AuthenticationResponse? response = await _usersService.Login(loginRequest);
        
        
        if (response == null || response.Success == false)
        {
            return Unauthorized(response); 
        }
        return Ok(response);
    }
}