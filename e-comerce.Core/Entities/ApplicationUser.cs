namespace e_comerce.Infrastructure.Entities;

public class ApplicationUser
{
    public Guid UserId { get; set; }
    public string? PersonName { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public string? Gender { get; set; }
    
}