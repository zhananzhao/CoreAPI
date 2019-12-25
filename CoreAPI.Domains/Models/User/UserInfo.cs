using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text;
using Util.Domains;

namespace CoreAPI.Domains.Models.User
{
   public class UserInfoEntity: AggregateRoot
    {
        public UserInfoEntity() : this(Guid.Empty)
        {
        }

        public UserInfoEntity(Guid id) : base(id)
        {

        }
        [StringLength(100,ErrorMessage = "用户名输入过长，不能超过50位")]
        public string UserName { get; set; }

        public int Age { get; set; }

        public DateTime? Birthday { get; set; }

        public DateTime? CreateTime { get; set; }

        public byte[] Version { get; set; }

        public string Addr { get; set; }

        public virtual ICollection<Roles> UseRoleses { get; set; }



        protected override void AddDescriptions()
        {
            base.AddDescriptions();
        }
    }
}
