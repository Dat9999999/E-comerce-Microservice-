using e_comerce.Infrastructure.DTO;

namespace e_comerce.Infrastructure.ServiceContracts;

internal interface IUserService
{ 
    Task<AuthenticationResponse> Login(LoginRequest request); 
    Task<AuthenticationResponse> Register(RegisterRequest request);
}