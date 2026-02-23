using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Fintalks.Common.Commands;
using Fintalks.DB.DBEntity;

namespace Fintalks.Service.Mappers
{
    public class UserInfoMapperProfile : Profile
    {
        public UserInfoMapperProfile()
        {
            CreateMap<CreateUserInfoCommand, DBUserInfo>();
        }
    }
}
