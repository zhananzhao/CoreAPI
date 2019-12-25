using System;
using System.Collections.Generic;
using System.Text;
using Util.Domains.Repositories;

namespace CoreAPI.Domains.Queries
{
   public class UserInfoQuery:Pager
    {
        public string UserName { get; set; }
    }
}
