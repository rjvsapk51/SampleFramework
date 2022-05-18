using BeeHive.L20.Services.SL20.Model.Common;

namespace BeeHive.L20.Services.SL20.Model
{
    public class RoleMenuModel : CommonAttributeModel
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public int MenuId { get; set; }
        public bool Hatch { get; set; }
        public bool Know { get; set; }
        public bool Amend { get; set; }
        public bool StrikeOut { get; set; }

    }
}
