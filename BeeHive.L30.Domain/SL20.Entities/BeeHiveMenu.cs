using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeeHive.L30.Domain.SL20.Entities
{
    [Table("beehive_menu")]
    public class BeeHiveMenu
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }
        [Column("banner")]
        public string Banner { get; set; }
        [Column("display_banner")]
        public string DisplayBanner { get; set; }
        [Column("icon")]
        public string Icon { get; set; }
        [Column("controller")]
        public string Controller { get; set; }
        [Column("action")]
        public string Action { get; set; }
        [Column("additional_parameter")]
        public string AdditionalParameter { get; set; }
        [Column("order_number")]
        public int OrderNumber { get; set; }
        [Column("access_to_all")]
        public bool AccessToAll { get; set; }
        [Column("is_dashboard_menu")]
        public bool IsDashboardMenu { get; set; }
        [Column("is_active")]
        public bool IsActive { get; set; }
        [Column("parent_id")]
        public long ParentId { get; set; }
        [Column("description")]
        public string Description { get; set; }
    }
}
