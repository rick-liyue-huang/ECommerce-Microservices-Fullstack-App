namespace eCommerceSolution.UsersService.Domain.Entities;

/// <summary>
/// Define the ApplicationUser entity to match the Users table in the database.
/// </summary>
public class ApplicationUser
{
    public Guid UserId { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public string? PersonName { get; set; }
    public string? Gender { get; set; }
}