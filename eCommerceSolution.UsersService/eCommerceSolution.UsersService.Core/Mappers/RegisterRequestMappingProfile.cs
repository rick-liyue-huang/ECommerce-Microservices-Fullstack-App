using AutoMapper;
using eCommerceSolution.UsersService.Core.Dtos;
using eCommerceSolution.UsersService.Domain.Entities;

namespace eCommerceSolution.UsersService.Core.Mappers;

public class RegisterRequestMappingProfile : Profile
{
    public RegisterRequestMappingProfile()
    {
        CreateMap<RegisterRequest, ApplicationUser>()
            .ForMember(
                dest => dest.Email, 
                opt => opt.MapFrom(src => src.Email))
            .ForMember(
                dest => dest.PersonName, 
                opt => opt.MapFrom(src => src.PersonName))
            .ForMember(
                dest => dest.Gender, 
                opt => opt.MapFrom(src => src.Gender.ToString()))
            .ForMember(
                dest => dest.Password, 
                opt => opt.MapFrom(src => src.Password));
    }
}