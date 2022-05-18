using BeeHive.L20.Services.SL20.Model.Common;

namespace BeeHive.L20.Services.SL20.Model
{
    public class MenuModel : CommonAttributeModel
    {
        public long Id { get; set; }
        public string Banner { get; set; } 
        public string Icon { get; set; }
        public string RouterLink { get; set; }
        public long OrderNumber { get; set; }
        public bool IsActive { get; set; }
        public long ParentId { get; set; }
        public string Description { get; set; }
        public bool IsDashboard { get; set; }
    }
}
