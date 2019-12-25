using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Util.ApplicationServices;

namespace CoreAPI.Services.Dtos
{
    [DataContract]

    public class UserInfoDto : DtoBase
    {
        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public int Age { get; set; }
        [DataMember]
        public DateTime? Birthday { get; set; }
        [DataMember]
        public DateTime? CreateTime { get; set; }
        [DataMember]
        public string Addr { get; set; }

        [DataMember]
        public byte[] Version { get; set; }

        public ICollection<RolesDto> Roles { get; set; }
    }
}
