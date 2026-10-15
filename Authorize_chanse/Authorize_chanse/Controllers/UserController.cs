using Authorize_chanse.Interfaces;
using Authorize_chanse.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Authorize_chanse.Controllers;


[ApiController]
[Route("api/[controller]")]
public class UserController
{
    public readonly IUserService _userService;
    public UserController(IUserService userService) => _userService = userService;
    
    [HttpGet]
    public async Task<IActionResult> CheckProfile([FromHeader] string authorization) => await _userService.CheckProfile(authorization);
    
    [HttpGet("GetMood")]
    public async Task<IActionResult> GetMood() => await _userService.GetMood();
    
    [HttpPost("CreateMood")]
    public async Task<IActionResult> CreateMood([FromHeader] string authorization, [FromBody] MoodQuery addMoodQuery) => await _userService.CreateMood(authorization, addMoodQuery);
    
    [HttpGet("GetDoctors")]
    public async Task<IActionResult> GetDoctors() => await _userService.GetDoctors();
}