using BeeHive.L20.Services.SL20.Model.Common;

namespace BeeHive.L20.Services.SL20.Model
{
    public partial class RoleModel : CommonAttributeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public long[] MenuIds { get; set; }
    }
}
