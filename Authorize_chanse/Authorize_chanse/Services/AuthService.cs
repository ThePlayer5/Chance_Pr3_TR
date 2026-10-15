using Authorize_chanse.DatabaseContext;
using Authorize_chanse.Interfaces;
using Authorize_chanse.Models;
using Authorize_chanse.Requests;
using Authorize_chanse.UniversalMethods;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Authorize_chanse.Services;

public class AuthService : IAuthService
{
    private readonly Contextdatabase _context;
    private readonly JWTtokenGenerator _jwtTokenGenerator;

    public AuthService(Contextdatabase context, JWTtokenGenerator jwtTokenGenerator)
    {
        _context = context;
        _jwtTokenGenerator = jwtTokenGenerator;
    }
    public async Task<IActionResult> RegisterNewUser(QueryUsers register)
    {
        if (await _context.Logins.AnyAsync(x => x.email == register.Email))
        {
            return new BadRequestObjectResult(new
            {
                status = false,
                message = "Пользователь с таким Email уже существует"
            });
        }
        var newLogin = new Logins()
        {
            email = register.Email,
            password = register.Password,
            User = new Users()
            {
                fullname = register.fullname,
                college = register.college,
                roleId = 2,
                email = register.Email,
            }
           

        };
        await _context.AddAsync(newLogin);
        await _context.SaveChangesAsync();

        return new OkObjectResult(new
        {
            status = true,
            message = "Вы успешно зарегистрировались"   
        });
    }

    public async Task<IActionResult> AuthUser(AuthUser authUser)
    {
        var selectedUser = _context.Logins
            .Include(login => login.User)
            .FirstOrDefault(login => login.email == authUser.Email && login.password == authUser.Password);

        if (selectedUser != null)
        {
            string token = _jwtTokenGenerator.GenerateJwtToken(selectedUser.userId, selectedUser.User.roleId);

            _context.Sessions.Add(new Session()
            {
                token = token,
                userId = selectedUser.userId,
            });
            await _context.SaveChangesAsync();
            

            return new OkObjectResult(new { status = true, token = token, userId = selectedUser.User.userId, roleId = selectedUser.User.roleId });
        }
        else
        {
            return new NotFoundObjectResult(new
                { status = false, message = "User not found. Check you login and password!" });
        }
        
        
    }
}