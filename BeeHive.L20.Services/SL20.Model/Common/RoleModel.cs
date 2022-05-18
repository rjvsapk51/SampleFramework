using BeeHive.L20.Services.SL20.Model.Common;

namespace BeeHive.L20.Services.SL20.Model
{
    public partial class RoleModel : CommonAttributeModel
    {
        public int Id { get; set; }
        public string Banner { get; set; }
        public string Description { get; set; }
        public bool IsSuperAdmin { get; set; }
        public bool IsActive { get; set; }
    }
}
