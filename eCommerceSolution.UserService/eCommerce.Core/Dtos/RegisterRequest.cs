using eCommerce.Domain.Enums;

namespace eCommerce.Core.Dtos;

public record RegisterRequest(string? Email, string? Password, string? PersonName, GenderOption Gender);