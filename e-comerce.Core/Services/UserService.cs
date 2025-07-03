using e_comerce.Infrastructure.DTO;
using e_comerce.Infrastructure.Entities;
using e_comerce.Infrastructure.Repositories;
using e_comerce.Infrastructure.ServiceContracts;

namespace e_comerce.Infrastructure.Services;

internal class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public async Task<AuthenticationResponse> Login(LoginRequest request)
    {
        ApplicationUser? user = await _userRepository.GetByEmailAndPassword(request.Email, request.Password);;
        if (user is null)
        {
            return null;
        }

        return new AuthenticationResponse(user.UserId,
            user.Email,
             user.PersonName,
             user.Gender, "token",
            true);
    }

    public async Task<AuthenticationResponse> Register(RegisterRequest request)
    {
        var user = new ApplicationUser()
        {
            Email = request.Email,
            Gender = request.Gender.ToString(),
            PersonName = request.PersonName,
            Password = request.Password,
            UserId = Guid.NewGuid()
        };
        ApplicationUser? userAdded = await _userRepository.AddUser(user);
        if (userAdded is null)
        {
            return null;
        }
        return new AuthenticationResponse(userAdded.UserId,
                    userAdded.Email,
                    userAdded.PersonName,
                    userAdded.Gender, 
                    "token",
            true);
    }
}