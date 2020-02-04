using System;
using System.Collections.Generic;
using System.Text;

namespace BeeHive.L20.Services.SL20.Model
{
    public partial class RoleModel
    {
        public int Id { get; set; }
        public string Banner { get; set; }
        public string Description { get; set; }
        public bool IsSuperAdmin { get; set; }
        public bool IsActive { get; set; }
    }
}
