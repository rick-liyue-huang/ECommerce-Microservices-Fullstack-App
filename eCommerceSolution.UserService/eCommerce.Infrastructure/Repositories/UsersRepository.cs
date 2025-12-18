using eCommerce.Core.RepositoryContracts;
using eCommerce.Domain.Entities;
using eCommerce.Domain.Enums;

namespace eCommerce.Infrastructure.Repositories;

public class UsersRepository : IUsersRepository
{
    public async Task<ApplicationUser?> AddUser(ApplicationUser user)
    {
        // Generate a new unique ID for the user
        user.UserId = Guid.NewGuid();
        return user;
    }

    public async Task<ApplicationUser?> GetUserByEmailAndPassword(string email, string password)
    {
        return new ApplicationUser()
        {
            UserId = Guid.NewGuid(),
            Email = email,
            Password = password,
            PersonName = "Rick",
            Gender = nameof(GenderOption.Male)
        };
    }
}