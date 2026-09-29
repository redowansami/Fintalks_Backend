using AutoMapper;
using Fintalks.Common.Commands;
using Fintalks.Common.DTOs;
using Fintalks.Common.Models;
using Fintalks.Common.Utils;
using Fintalks.DB.DBEntity;

namespace Fintalks.Service.Mappers
{
    public class UserMapperProfile : Profile
    {
        public UserMapperProfile()
        {
            CreateMap<CreateUserCommand, User>();
            CreateMap<User, DBUser>()
                .ForMember(
                    dest => dest.FirstName,
                    opt => opt.MapFrom(src => NameExtractor.FirstName(src.Name))
                )
                .ForMember(
                    dest => dest.LastName,
                    opt => opt.MapFrom(src => NameExtractor.LastName(src.Name))
                )
                .ReverseMap()
                .ForMember(
                    dest => dest.Name,
                    opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}".Trim())
                );
            CreateMap<User, UserResponseDTO>();
            CreateMap<User, CreateUserResponseDTO>();
            CreateMap<UpdateUserCommand, DBUser>()
                .ForMember(
                    dest => dest.FirstName,
                    opt =>
                    {
                        opt.PreCondition(src => src.Name != null);
                        opt.MapFrom(src => NameExtractor.FirstName(src.Name!));
                    }
                )
                .ForMember(
                    dest => dest.LastName,
                    opt =>
                    {
                        opt.PreCondition(src => src.Name != null);
                        opt.MapFrom(src => NameExtractor.LastName(src.Name));
                    }
                )
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
