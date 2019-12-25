using System;
using System.Collections.Generic;
using System.Text;
using CoreAPI.Domains.Models.User;
using Util;

namespace CoreAPI.Services.Dtos
{
    public static class UserInfoDtoExtension
    {
        public static UserInfoEntity ToEntity(this UserInfoDto dto)
        {
            return new UserInfoEntity(dto.Id.ToGuid())
            {
                UserName=dto.UserName,
                Age=dto.Age,
                Birthday=dto.Birthday,
                CreateTime=dto.CreateTime,
               Addr = dto.Addr
            };
        }

        public static UserInfoDto ToDto(this UserInfoEntity entity)
        {
            return new UserInfoDto()
            {
                Id=entity.Id.ToString(),
                UserName=entity.UserName,
                Age=entity.Age,
                Birthday=entity.Birthday,
                CreateTime=entity.CreateTime,
                Addr = entity.Addr,
            };
        }
    }
}
