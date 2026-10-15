using Authorize_chanse.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Authorize_chanse.Interfaces;

public interface IAuthService
{
    Task<IActionResult> RegisterNewUser(QueryUsers register);
    Task<IActionResult> AuthUser(AuthUser authUser);
}