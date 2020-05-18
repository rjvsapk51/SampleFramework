using System;
using System.Collections.Generic;
using System.Text;

namespace BeeHive.L20.Services.SL20.Model
{
    public class MenuModel
    {
        public long Id { get; set; }
        public string Banner { get; set; }
        public string DisplayBanner { get; set; }    
        public string Icon { get; set; }
        public string RouterLink { get; set; }
        public long OrderNumber { get; set; }
        public bool AccessToAll { get; set; }
        public bool IsDashboardMenu { get; set; }
        public bool IsActive { get; set; }
        public long ParentId { get; set; }
        public string Description { get; set; }
    }
    public class MenuLookup
    {
        public long Id { get; set; }
        public string Banner { get; set; }
    }
}
