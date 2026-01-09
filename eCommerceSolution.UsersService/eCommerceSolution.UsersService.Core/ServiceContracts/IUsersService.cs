using eCommerceSolution.UsersService.Core.Dtos;

namespace eCommerceSolution.UsersService.Core.ServiceContracts;

public interface IUsersService
{
    Task<AuthenticationResponse?> Login(LoginRequest request);
    
    Task<AuthenticationResponse?> Register(RegisterRequest request);
}