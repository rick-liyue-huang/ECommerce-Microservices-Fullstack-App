using AutoMapper;
using eCommerce.Core.Dtos;
using eCommerce.Core.RepositoryContracts;
using eCommerce.Core.ServiceContracts;
using eCommerce.Domain.Entities;

namespace eCommerce.Core.Services;

public class UsersService(IUsersRepository usersRepository, IMapper mapper) : IUsersService
{

    public async Task<AuthenticationResponse?> Login(LoginRequest loginRequest)
    {
        ApplicationUser? user = await usersRepository.GetUserByEmailAndPassword(loginRequest.Email!, loginRequest.Password!);
        
        if (user == null) return null;
        
        // return new AuthenticationResponse(user.UserId, "Token", user.Email, user.PersonName, user.Gender, true);
        
        return mapper.Map<AuthenticationResponse>(user) with { Success = true, Token = "ttToken" };
    }

    public async Task<AuthenticationResponse?> Register(RegisterRequest registerRequest)
    {
        //Create a new user from the register request
        ApplicationUser user = new ApplicationUser
        {
            Email = registerRequest.Email,
            Password = registerRequest.Password,
            PersonName = registerRequest.PersonName,
            Gender = registerRequest.Gender.ToString()
        };
        ApplicationUser? newUser = await usersRepository.AddUser(user);

        if (newUser == null) return null;
        
        // return new AuthenticationResponse(newUser.UserId, "newToken", newUser.Email, newUser.PersonName, newUser.Gender, true);

        return mapper.Map<AuthenticationResponse>(newUser) with { Success = true, Token = "newnewToken" };
    }
}