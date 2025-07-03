namespace e_comerce.Infrastructure.DTO;

public record RegisterRequest(
    string Email,
    string Password,
    string PersonName,
    GenderOptions Gender);