using System;
using System.Collections.Generic;
using System.Text;
using CoreAPI.Domains.Models.User;
using CoreAPI.Domains.Repositories;
using Util.Datas;

namespace CoreAPI.Infrastructure.Data.EF.SQL.Repositories
{
    internal class RolesRepository:RepositoryBase<Roles>,IRolesRepository
    {
        /// <summary>
        /// 初始化仓储
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        public RolesRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
