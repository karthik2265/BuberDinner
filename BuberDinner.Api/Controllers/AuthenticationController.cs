using Microsoft.AspNetCore.Mvc;
// projects ref
using BuberDinner.Contracts.Authentication;

namespace BuberDinner.Api.Controllers;

[ApiController]
[Route("auth")]
public class AuthenticationController : ControllerBase
{

  [HttpPost("register")]
  public IActionResult Register(RegisterRequest request)
  {
    return Ok(request);
  }

  [HttpPost("login")]
  public IActionResult Register(LoginRequest request)
  {
    return Ok(request);
  }
}