using System.Text;
using CoreAPI.Domains.Queries;
using CoreAPI.Services.Contracts;
using CoreAPI.Services.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Redis;
using Newtonsoft.Json;
using Util.Domains.Repositories;

namespace CoreWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserInfoController : ControllerBase
    {
        private IUserInfoService _userInfoService { get; set; }

       
        public UserInfoController(IUserInfoService userInfoService,IDistributedCache cache)
        {
            _userInfoService = userInfoService;
           
        }
        
        [HttpPost]
        public void Post([FromBody] UserInfoDto dto)
        {
            dto.Id = dto.Id.ToUpper();
            _userInfoService.Save(dto);
        }
        
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            _userInfoService.Delete(id);
        }

        [HttpGet("{id}")]
        public ActionResult<UserInfoDto> Get(string id)
        {
            return _userInfoService.GetUserInfo(id);
        }

        [HttpGet("detail/{id}")]
        public ActionResult<PagerList<UserInfoDto>> GetUserInfo(string id)
        {
            return _userInfoService.GetUserList(new UserInfoQuery(){UserName = "zhao",Page=1,PageSize=3,Order="Id"});
        }


    }
}
