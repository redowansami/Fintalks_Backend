using AutoMapper;
using Fintalks.Common.Commands;
using Fintalks.Common.DTOs;
using Fintalks.Common.Enums;
using Fintalks.Common.Models;
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
                    opt => opt.MapFrom(src => src.Name.Split(' ')[0])
                )
                .ForMember(
                    dest => dest.LastName,
                    opt =>
                        opt.MapFrom(src =>
                            src.Name.Split(' ').Length > 1 ? src.Name.Split(' ')[1] : ""
                        )
                )
                .ReverseMap()
                .ForMember(
                    dest => dest.Name,
                    opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}".Trim())
                );
            ;
            CreateMap<User, UserResponseDTO>();
            CreateMap<UpdateUserCommand, DBUser>()
                .ForMember(
                    dest => dest.FirstName,
                    opt =>
                    {
                        opt.PreCondition(src => src.Name != null);
                        opt.MapFrom(src => src.Name.Split(' ')[0]);
                    }
                )
                .ForMember(
                    dest => dest.LastName,
                    opt =>
                    {
                        opt.PreCondition(src => src.Name != null);
                        opt.MapFrom(src =>
                            src.Name.Split(' ').Length > 1 ? src.Name.Split(' ')[1] : ""
                        );
                    }
                )
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
