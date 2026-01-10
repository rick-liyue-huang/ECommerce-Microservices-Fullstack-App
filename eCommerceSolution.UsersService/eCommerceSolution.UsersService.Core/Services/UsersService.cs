using AutoMapper;
using eCommerceSolution.UsersService.Core.Dtos;
using eCommerceSolution.UsersService.Core.ServiceContracts;
using eCommerceSolution.UsersService.Domain.Entities;
using eCommerceSolution.UsersService.Domain.RepositoryContracts;

namespace eCommerceSolution.UsersService.Core.Services;

public class UsersService(IUsersRepository usersRepository, IMapper mapper) : IUsersService
{
    public async Task<AuthenticationResponse?> Login(LoginRequest request)
    {
        ApplicationUser? user = await usersRepository.GetUserByEmailAndByPassword(request.Email, request.Password);
        
        if (user == null) return null;
        
        // return new AuthenticationResponse(
        //     user.UserId, 
        //     user.Email,
        //     user.PersonName,
        //     user.Gender,
        //     Guid.NewGuid().ToString(),
        //     true
        // );

        return mapper.Map<AuthenticationResponse>(user) with { Success = true, Token = Guid.NewGuid().ToString() };
    }

    public async Task<AuthenticationResponse?> Register(RegisterRequest request)
    {
        // ApplicationUser user = new ApplicationUser()
        // {
        //     PersonName = request.PersonName,
        //     Email = request.Email,
        //     Password = request.Password,
        //     Gender = request.Gender.ToString()
        // };
        ApplicationUser user = mapper.Map<ApplicationUser>(request);
        
        ApplicationUser? newUser = await usersRepository.AddUser(user);
        
        if (newUser == null) return null;
        
        // return new AuthenticationResponse(
        //     newUser.UserId, 
        //     newUser.Email,
        //     newUser.PersonName,
        //     newUser.Gender,
        //     "new token",
        //     true
        // );
        
        return mapper.Map<AuthenticationResponse>(newUser) with { Success = true, Token = "new token" };
    }
}