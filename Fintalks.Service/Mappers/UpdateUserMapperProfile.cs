using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Fintalks.Common.Commands;
using Fintalks.DB.DBEntity;

namespace Fintalks.Service.Mappers
{
    public class UpdateUserMapperProfile : Profile
    {
        public UpdateUserMapperProfile()
        {
            CreateMap<UpdateUserProfileCommand, UpdateUserCommand>();
            CreateMap<UpdateUserProfileCommand, UpdateUserInfoCommand>();
            CreateMap<UpdateUserInfoCommand, DBUserInfo>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
