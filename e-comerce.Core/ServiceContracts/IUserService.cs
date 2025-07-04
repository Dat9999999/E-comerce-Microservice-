using e_comerce.Infrastructure.DTO;

namespace e_comerce.Infrastructure.ServiceContracts;

public interface IUserService
{ 
    Task<AuthenticationResponse> Login(LoginRequest request); 
    Task<AuthenticationResponse> Register(RegisterRequest request);
}