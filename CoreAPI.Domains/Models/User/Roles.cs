using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Util.Domains;

namespace CoreAPI.Domains.Models.User
{
    public class Roles:AggregateRoot
    {
       
        public Roles(Guid id) : base(id)
        {
        }
        public Roles() : this(Guid.Empty)
        {
        }

       [StringLength(50,ErrorMessage = "角色名称输入过长，不能超过50位")]
        public string RoleName { get; set; }

      

        public Guid UserId { get; set; }

        public DateTime? CreateTime { get; set; }

        public byte[] Version { get; set; }

        protected override void AddDescriptions()
        {
            base.AddDescriptions();
        }
    }
}
