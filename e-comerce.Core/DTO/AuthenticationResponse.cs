namespace e_comerce.Infrastructure.DTO;

public record AuthenticationResponse(
    Guid UserId,
    string? Email,
    string? PersonName,
    string? Gender,
    string? Token,
    bool Success
    );