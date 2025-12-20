using Dapper;
using eCommerce.Core.RepositoryContracts;
using eCommerce.Domain.Entities;
using eCommerce.Domain.Enums;
using eCommerce.Infrastructure.DbContext;

namespace eCommerce.Infrastructure.Repositories;

public class UsersRepository(DapperDbContext dbContext) : IUsersRepository
{
    
    public async Task<ApplicationUser?> AddUser(ApplicationUser user)
    {
        // Generate a new unique ID for the user
        user.UserId = Guid.NewGuid();
        
        // SQL query to insert the user into the database
        string query = "INSERT INTO public.\"users\"(\"userid\", \"email\", \"password\", \"personname\", \"gender\") VALUES(@UserId, @Email, @Password, @PersonName, @Gender)";
        
        int rowCountAffected = await dbContext.DbConnection.ExecuteAsync(query, user);

        if (rowCountAffected > 0)
        {
            return user;
        }
        else
        {
            return null;
        }
    }

    public async Task<ApplicationUser?> GetUserByEmailAndPassword(string email, string password)
    {
        // sql query to get the user by email and password
        string query = "SELECT * FROM public.\"users\" WHERE \"email\"=@Email AND \"password\"=@Password";
        
        var parameters = new { Email = email, Password = password };
        ApplicationUser? user = await dbContext.DbConnection.QueryFirstOrDefaultAsync<ApplicationUser>(query, parameters);
        
        return user;
    }
}