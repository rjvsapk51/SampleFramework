using BeeHive.L30.Domain.SL20.Entities.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeeHive.L30.Domain.SL20.Entities.Common
{
    [Table("beehive_role_menu")]
    public class RoleMenu: CommonAttribute
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("role_id")]
        public int RoleId { get; set; }
        [Column("menu_id")]
        public int MenuId { get; set; }
        [Column("hatch")]
        public bool Hatch { get; set; }
        [Column("know")]
        public bool Know { get; set; }
        [Column("amend")]
        public bool Amend { get; set; }
        [Column("strike_out")]
        public bool StrikeOut { get; set; }
    }
}
