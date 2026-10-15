using Authorize_chanse.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Authorize_chanse.Interfaces;

public interface IUserService
{
    Task<IActionResult> CheckProfile(string authorization);

    Task<IActionResult> GetMood();
    
    Task<IActionResult> CreateMood(string authorization, MoodQuery addMoodQuery);
    
    Task<IActionResult> GetDoctors();
}