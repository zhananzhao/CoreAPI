using System;
using System.Data;
using System.Linq;
using System.Text;
using CoreAPI.Domains.Models.User;
using CoreAPI.Domains.Queries;
using CoreAPI.Services.Contracts;
using CoreAPI.Services.Dtos;
using Dappers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Redis;
using Newtonsoft.Json;
using Util;
using Util.ApplicationServices;
using Util.Datas;
using Util.Datas.Queries;
using Util.Datas.Sql.Queries.Builders;
using Util.Domains.Repositories;

namespace CoreAPI.Services.Impl
{
   public class UserInfoService:ServiceBase<UserInfoEntity, UserInfoDto,UserInfoQuery>, IUserInfoService
    {
        private IDistributedCache _RedisCache { get; set; }
        public UserInfoService(IUnitOfWork unitOfWork,
            IRepository<UserInfoEntity> repository,
            IDistributedCache cache) 
            : base(unitOfWork, repository)
        {
            _RedisCache=cache ;
        }

        protected override UserInfoDto ToDto(UserInfoEntity entity)
        {
            return entity.ToDto();
        }

        protected override UserInfoEntity ToEntity(UserInfoDto dto)
        {
            return dto.ToEntity();
        }

        public override IQueryBase<UserInfoEntity> GetQuery(UserInfoQuery param)
        {
            return new Query<UserInfoEntity>(param)
                .Filter(t=>t.UserName.Contains(param.UserName));
        }

        public UserInfoDto GetUserInfo(string userId)
        {
            var cacheInfo = _RedisCache.Get(userId.ToLower());
            if (cacheInfo!=null&&cacheInfo.Length!=0)
            {
                return JsonConvert.DeserializeObject<UserInfoDto>(Encoding.Default.GetString(cacheInfo));
            }
            var entity = Repository.Find(t => t.Id == userId.ToGuid()).Include(t => t.UseRoleses).FirstOrDefault();
            if (entity!=null)
            {
                var jsonData = JsonConvert.SerializeObject(entity.ToDto());
                _RedisCache.Set(entity.Id.ToString(), Encoding.Default.GetBytes(jsonData),new DistributedCacheEntryOptions()
                {
                    AbsoluteExpirationRelativeToNow=TimeSpan.FromMinutes(20)
                });
            }
            return entity.ToDto();

        }

        public PagerList<UserInfoDto> GetUserList(UserInfoQuery query)
        {
            var conn = Repository.GetUnitOfWork() as DbContext;
            var dbConnection = conn.Database.GetDbConnection();
            SqlBuilder sqlBuilder=new SqlBuilder();
            sqlBuilder.From("tb_User");
            sqlBuilder.Select("*");
            sqlBuilder.Contains("UserName", query.UserName);
            sqlBuilder.SetPager(query);
            var totalCount = sqlBuilder.GetCountSql();
            var dataSql = sqlBuilder.GetSql();
            query.TotalCount = dbConnection.ExecuteScalar<int>(totalCount, sqlBuilder.GetParams());
            var dtos = dbConnection.Query<UserInfoEntity>(dataSql, sqlBuilder.GetParams()).ToPageList(query).Convert(ToDto);
            return dtos;
        }

        protected override void AddAfter(UserInfoEntity entity)
        {
            var jsonData = JsonConvert.SerializeObject(entity.ToDto());
            _RedisCache.Set(entity.Id.ToString(),Encoding.Default.GetBytes(jsonData));
            base.AddAfter(entity);
        }

        protected override void UpdateAfter(UserInfoEntity entity)
        {
            var jsonData = JsonConvert.SerializeObject(entity.ToDto());
            _RedisCache.Set(entity.Id.ToString(), Encoding.Default.GetBytes(jsonData));
            base.UpdateAfter(entity);
        }
    }
}
