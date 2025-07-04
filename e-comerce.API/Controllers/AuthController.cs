using e_comerce.Infrastructure.DTO;
using e_comerce.Infrastructure.Entities;
using e_comerce.Infrastructure.ServiceContracts;
using Microsoft.AspNetCore.Mvc;

namespace e_comerce.Web.Controllers;

[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IUserService _userService;
    public AuthController(IUserService userService)
    {
        _userService = userService;
    }
    
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequest request)
    {
        if (request is null)
        {
            return BadRequest();
        }
        var authenticationResponse = await _userService.Register(request);
        if (authenticationResponse is null || !authenticationResponse.Success)
        {
            return BadRequest("Invalid registration");
        }
        return Ok(authenticationResponse);
    }
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        if (request is null) return BadRequest();
        AuthenticationResponse? response = await _userService.Login(request);
        if (response is null || !response.Success)
        {
            return Unauthorized(response);
        }
        return Ok(response);        
    }
}