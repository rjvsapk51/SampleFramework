using System;

namespace BeeHive.L20.Services.SL20.Model.Common
{
    public abstract class CommonAttributeModel
    {
        public long CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public long UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; } = DateTime.Now;
    }
}
