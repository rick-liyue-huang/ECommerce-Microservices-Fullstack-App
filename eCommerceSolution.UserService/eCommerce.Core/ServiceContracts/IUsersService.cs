using eCommerce.Core.Dtos;

namespace eCommerce.Core.ServiceContracts;


/// <summary>
/// Contract for the UsersService
/// </summary>
public interface IUsersService
{
    /// <summary>
    /// Signin a user and return a response
    /// </summary>
    /// <param name="loginRequest"></param>
    /// <returns></returns>
    Task<AuthenticationResponse?> Login(LoginRequest loginRequest);
    
    /// <summary>
    /// Register a new user and return a response
    /// </summary>
    /// <param name="registerRequest"></param>
    /// <returns></returns>
    Task<AuthenticationResponse?> Register(RegisterRequest registerRequest);
}