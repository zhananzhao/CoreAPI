using System;
using System.Collections.Generic;
using System.Text;
using CoreAPI.Domains.Models.User;
using Util.Domains.Repositories;

namespace CoreAPI.Domains.Repositories
{
    public interface IUserInfoRepository : IRepository<UserInfoEntity>
    {
    }
}
