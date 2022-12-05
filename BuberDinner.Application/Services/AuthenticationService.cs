using BuberDinner.Application.Common.Interfaces.Authentication;


namespace BuberDinner.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
  private readonly IJwtTokenGenerator _jwtTokenGenerator;

  public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator)
  {
    _jwtTokenGenerator = jwtTokenGenerator;
  }

  public AuthenticationResult Login(string email, string password)
  {
    return new AuthenticationResult(Guid.NewGuid(), "fs", "ls", email, "token");
  }

  public AuthenticationResult Register(string firstName, string lastName, string email, string password)
  {
    // Check if user already exists

    // Create a user (generate unique Id)
    var userId = Guid.NewGuid();
    // Create a JWT token
    var token = _jwtTokenGenerator.GenerateToken(userId, firstName, lastName);
    return new AuthenticationResult(Guid.NewGuid(), firstName, lastName, email, token);
  }
}