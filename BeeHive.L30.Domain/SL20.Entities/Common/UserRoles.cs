using BeeHive.L30.Domain.SL20.Entities.Generic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BeeHive.L30.Domain.SL20.Entities.Common
{
    [Table("beehive_user_role")]
    public class UserRoles: CommonAttribute
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }
        [Column("hopper_id")]
        public long UserId { get; set; }
        [Column("role_id")]
        public long RoleId { get; set; }
    }
}
