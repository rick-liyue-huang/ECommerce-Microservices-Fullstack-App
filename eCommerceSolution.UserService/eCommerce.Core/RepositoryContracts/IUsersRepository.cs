using eCommerce.Domain.Entities;

namespace eCommerce.Core.RepositoryContracts;


/// <summary>
/// Contract for the UsersRepository
/// </summary>
public interface IUsersRepository
{
    /// <summary>
    /// Add a new user to the database
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    Task<ApplicationUser?> AddUser(ApplicationUser user);
    
    /// <summary>
    /// Get a user by email and password
    /// </summary>
    /// <param name="email"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    Task<ApplicationUser?> GetUserByEmailAndPassword(string email, string password);
}