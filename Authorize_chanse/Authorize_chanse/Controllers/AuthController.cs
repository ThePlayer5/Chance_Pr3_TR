using Authorize_chanse.Interfaces;
using Authorize_chanse.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Authorize_chanse.Controllers;


[ApiController]
[Route("api/[controller]")]
public class AuthController
{
    public readonly IAuthService _service;
    public AuthController(IAuthService service) => _service = service; 
    
    [HttpPost("Register")]
    public async Task<IActionResult> Register(QueryUsers register) => await _service.RegisterNewUser(register);
    
    [HttpPost("Authorize")]
    public async Task<IActionResult> AuthUser(AuthUser authUser) => await _service.AuthUser(authUser);
    
}