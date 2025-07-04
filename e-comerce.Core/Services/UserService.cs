using AutoMapper;
using e_comerce.Infrastructure.DTO;
using e_comerce.Infrastructure.Entities;
using e_comerce.Infrastructure.Repositories;
using e_comerce.Infrastructure.ServiceContracts;

namespace e_comerce.Infrastructure.Services;

internal class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    public UserService(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }
    public async Task<AuthenticationResponse> Login(LoginRequest request)
    {
        ApplicationUser? user = await _userRepository.GetByEmailAndPassword(request.Email, request.Password);;
        if (user is null)
        {
            return null;
        }

        return _mapper.Map<ApplicationUser, AuthenticationResponse>(user) with
        {
            Success = true,
            Token = "token"
        };
    }

    public async Task<AuthenticationResponse> Register(RegisterRequest request)
    {
        var user = _mapper.Map<RegisterRequest, ApplicationUser>(request);
            
        //     new ApplicationUser()
        // {
        //     Email = request.Email,
        //     Gender = request.Gender.ToString(),
        //     PersonName = request.PersonName,
        //     Password = request.Password,
        //     UserId = Guid.NewGuid()
        // };
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