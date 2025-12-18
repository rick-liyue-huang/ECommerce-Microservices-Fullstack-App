namespace eCommerce.Core.Dtos;

public record AuthenticationResponse(
    Guid UserId, 
    string? Token, 
    string? Email, 
    string? PersonName, 
    string? Gender, 
    bool Success
);