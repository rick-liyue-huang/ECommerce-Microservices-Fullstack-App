using AutoMapper;
using eCommerceSolution.UsersService.Core.Dtos;
using eCommerceSolution.UsersService.Domain.Entities;

namespace eCommerceSolution.UsersService.Core.Mappers;

public class ApplicationUserMappingProfile : Profile
{
    public ApplicationUserMappingProfile()
    {
        CreateMap<ApplicationUser, AuthenticationResponse>()
            .ForMember(
                dest => dest.UserId,
                opt => opt.MapFrom(src => src.UserId))
            .ForMember(
                dest => dest.Email,
                opt => opt.MapFrom(src => src.Email))
            .ForMember(
                dest => dest.PersonName,
                opt => opt.MapFrom(src => src.PersonName))
            .ForMember(
                dest => dest.Gender,
                opt => opt.MapFrom(src => src.Gender))
            .ForMember(
                dest => dest.Token,
                opt => opt.Ignore())
            .ForMember(
                dest => dest.Success,
                opt => opt.Ignore());

    }
}