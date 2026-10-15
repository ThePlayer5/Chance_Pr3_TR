using Authorize_chanse.DatabaseContext;
using Authorize_chanse.Interfaces;
using Authorize_chanse.Models;
using Authorize_chanse.Requests;
using Authorize_chanse.UniversalMethods;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Authorize_chanse.Services;

public class UserService : IUserService
{
    private readonly Contextdatabase _context;
    private readonly JWTtokenGenerator _jwtTokensGenerator;
    
    public UserService(Contextdatabase contextDatabase, JWTtokenGenerator jwtTokensGenerator)
    {
        _context = contextDatabase;
        _jwtTokensGenerator = jwtTokensGenerator;
    }
    public async Task<IActionResult> CheckProfile(string authorization)
    {
        var tempSession = authorization.Split(' ').Last();
    
        var session = await _context.Sessions
            .Include(s => s.User)
            .FirstOrDefaultAsync(s => s.token == tempSession);
    
        if (session == null)
        {
            return new UnauthorizedObjectResult(new 
            { 
                status = false, 
                message = "Сессия не найдена" 
            });
        }
    
        var userProfile = await _context.Logins
            .Include(l => l.User)
            .FirstOrDefaultAsync(l => l.userId == session.userId); 
    
        if (userProfile == null)
        {
            return new NotFoundObjectResult(new 
            { 
                status = false, 
                message = "Пользователь не найден" 
            });
        }
    
        return new OkObjectResult(new
        {
            status = true,
            message = "Данные профиля",
            data = new
            {
                userId = userProfile.User.userId,
                email = userProfile.email,
                fullname = userProfile.User.fullname,
                college = userProfile.User.college,
                password = userProfile.password
            }
        });
    }

    public async Task<IActionResult> GetMood()
    {
        var mood = await _context.MoodTrack.
            Include(u => u.User).ToListAsync();

        if (mood == null)
        {
            return new NotFoundObjectResult(new
            {
                status = false, message = "Object not found"
            });
        }

        return new OkObjectResult(new
            {
                status = true,
                data = new
                {
                   mood = mood
                }
            });
    }

    public async Task<IActionResult> CreateMood(string authorization, MoodQuery addMoodQuery)
    {
        var tempSession = authorization.Split(' ').Last();
    
        var session = await _context.Sessions
            .Include(s => s.User)
            .FirstOrDefaultAsync(s => s.token == tempSession);   
        
        var newMood = new MoodTrack()
        {
            moodLevel = addMoodQuery.moodLevel,
            note = addMoodQuery.note,
            createdAt = DateTime.UtcNow,
            userId = session.userId
        };
        
        await _context.AddAsync(newMood);
        await _context.SaveChangesAsync();

        return new OkObjectResult(new
        {
            status = true,
            message = "Ypur mood saved successfully"
        });
    }

    public async Task<IActionResult> GetDoctors()
    {
        var doctors = await _context.Doctors.ToListAsync();

        if (doctors == null)
        {
            return new NotFoundObjectResult(new
            {
                status = false, message = "Object not found"
            });
        }

        return new OkObjectResult(new
        {
            status = true,
            data = new
            {
                doctors = doctors
            }
        });
    }
}