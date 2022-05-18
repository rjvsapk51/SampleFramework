using BeeHive.L30.Domain.SL20.Entities.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeeHive.L30.Domain.SL20.Entities.Common
{
    [Table("beehive_menu")]
    public class Menu : CommonAttribute
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }
        [Column("banner")]
        public string Banner { get; set; }
        [Column("icon")]
        public string Icon { get; set; }
        [Column("routerlink")]
        public string RouterLink { get; set; }
        [Column("order_number")]
        public long OrderNumber { get; set; }
        [Column("is_active")]
        public bool IsActive { get; set; }
        [Column("parent_id")]
        public long ParentId { get; set; }
        [Column("is_dashboard")]
        public bool IsDashboard { get; set; }
    }
}
