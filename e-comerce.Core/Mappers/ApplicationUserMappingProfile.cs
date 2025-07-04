using AutoMapper;
using e_comerce.Infrastructure.DTO;
using e_comerce.Infrastructure.Entities;

namespace e_comerce.Infrastructure.Mappers;

public class ApplicationUserMappingProfile : Profile
{
    public ApplicationUserMappingProfile()
    {
        CreateMap<ApplicationUser, AuthenticationResponse>()
            .ForMember(dest=>dest.Success, opt => opt.Ignore())
            .ForMember(dest => dest.Token, opt => opt.Ignore());
        CreateMap<RegisterRequest, ApplicationUser>()
            .ForMember(dest => dest.UserId, opt => opt.Ignore());
    }
}