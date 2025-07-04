namespace e_comerce.Infrastructure.DTO;

public record AuthenticationResponse(
    Guid UserId,
    string? Email,
    string? PersonName,
    string? Gender,
    string? Token,
    bool Success
)
{
    public AuthenticationResponse() : this(default, default, default, default, default, default)
    {
    }
}