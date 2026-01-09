using eCommerceSolution.UsersService.Domain.Entities;

namespace eCommerceSolution.UsersService.Domain.RepositoryContracts;

public interface IUsersRepository
{
    Task<ApplicationUser?> AddUser(ApplicationUser user);
    
    Task<ApplicationUser?> GetUserByEmailAndByPassword(string? email, string? password);
}