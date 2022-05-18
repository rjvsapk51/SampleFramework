using BeeHive.L30.Domain.SL20.Entities.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeeHive.L30.Domain.SL20.Entities.Common
{
    [Table("beehive_role")]
    public class Role : CommonAttribute
    {
        [Key]
        [Column("id")]
        public int Id  { get; set; }
        [Column("banner")]
        public string Banner { get; set; }
        [Column("description")]
        public string Description { get; set; }
        [Column("is_super_admin")]
        public bool IsSuperAdmin { get; set; }
        [Column("is_active")]
        public bool IsActive { get; set; }

    }
}
