using System;
using System.Collections.Generic;
using System.Text;
using Util.ApplicationServices;

namespace CoreAPI.Services.Dtos
{
  public  class RolesDto :DtoBase
    {
        public string RoleName { get; set; }
        
        public int UserId { get; set; }

        public DateTime? CreateTime { get; set; }

        public byte[] Version { get; set; }
    }
}
