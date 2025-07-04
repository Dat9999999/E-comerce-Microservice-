namespace e_comerce.Infrastructure.DTO;

public record LoginRequest(
    string? Email,
    string? Password);