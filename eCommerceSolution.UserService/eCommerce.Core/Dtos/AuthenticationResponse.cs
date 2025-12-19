namespace eCommerce.Core.Dtos;

public record AuthenticationResponse(
    Guid UserId,
    string? Token,
    string? Email,
    string? PersonName,
    string? Gender,
    bool Success
)
{
    // Parameterless constructor
    public AuthenticationResponse() : this(default, default, default, default, default, default)
    {
    }
}

// public record AuthenticationResponse
// {
//     // 使用 init 属性，AutoMapper 可以直接通过属性映射，不需要特殊的构造函数
//     public Guid UserId { get; init; }
//     public string? Token { get; init; }
//     public string? Email { get; init; }
//     public bool Success { get; init; }
//
//     // 依然可以通过 with 关键字操作
// }