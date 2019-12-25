using System;
using System.Collections.Generic;
using System.Text;
using CoreAPI.Domains.Queries;
using CoreAPI.Services.Dtos;
using Util.ApplicationServices;
using Util.Domains.Repositories;

namespace CoreAPI.Services.Contracts
{
   public interface IUserInfoService:IServiceBase<UserInfoDto, UserInfoQuery>
   {
       PagerList<UserInfoDto> GetUserList(UserInfoQuery query);

       UserInfoDto GetUserInfo(string userId);
   }
}
