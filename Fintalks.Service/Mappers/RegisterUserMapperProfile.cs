using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Fintalks.Common.Commands;

namespace Fintalks.Service.Mappers
{
    internal class RegisterUserMapperProfile : Profile
    {
        public RegisterUserMapperProfile()
        {
            CreateMap<RegisterUserCommand, CreateUserCommand>();
            CreateMap<RegisterUserCommand, CreateUserInfoCommand>()
                .ForMember(dest => dest.DBUserID, opt => opt.Ignore());
        }
    }
}
