using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Entities;


namespace BuberDinner.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
  private readonly IJwtTokenGenerator _jwtTokenGenerator;
  private readonly IUserRepository _userRepository;

  public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
  {
    _jwtTokenGenerator = jwtTokenGenerator;
    _userRepository = userRepository;
  }

  public AuthenticationResult Login(string email, string password)
  {
    // check if user exists
    var user = _userRepository.GetUserByEmail(email);
    if (user is null)
    {
      throw new Exception("User with given email does not exist");
    }
    // check password
    if (user.Password != password)
    {
      throw new Exception("Password does not match");
    }
    // create jwt token
    var token = _jwtTokenGenerator.GenerateToken(user);
    return new AuthenticationResult(user, token);
  }

  public AuthenticationResult Register(string firstName, string lastName, string email, string password)
  {
    // validate user does not exist
    var user = _userRepository.GetUserByEmail(email);
    if (user is not null)
    {
      throw new Exception("User with given email exists");
    }
    // Create a user (generate unique Id)
    var newUser = new User() { FirstName = firstName, LastName = lastName, Email = email, Password = password };
    _userRepository.Add(newUser);
    // Create a JWT token
    var token = _jwtTokenGenerator.GenerateToken(newUser);
    return new AuthenticationResult(newUser, token);
  }
}