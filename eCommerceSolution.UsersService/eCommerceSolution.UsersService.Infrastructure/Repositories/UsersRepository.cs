using eCommerceSolution.UsersService.Core.Dtos;
using eCommerceSolution.UsersService.Domain.Entities;
using eCommerceSolution.UsersService.Domain.RepositoryContracts;

namespace eCommerceSolution.UsersService.Infrastructure.Repositories;

public class UsersRepository : IUsersRepository
{
    public async Task<ApplicationUser?> AddUser(ApplicationUser user)
    {
        user.UserId = Guid.NewGuid();
        
        return user;
    }

    public async Task<ApplicationUser?> GetUserByEmailAndByPassword(string? email, string? password)
    {
        return new ApplicationUser()
        {
            UserId = Guid.NewGuid(),
            Email = email,
            Password = password,
            PersonName = "Test",
            Gender = GenderOptions.Male.ToString()
        };
    }
}