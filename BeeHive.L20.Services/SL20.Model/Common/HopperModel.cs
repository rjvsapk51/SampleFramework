using System;

namespace BeeHive.L20.Services.SL20.Model.Common
{
    public class HopperModel: CommonAttributeModel
    {
        public long Id { get; set; }
        public string Identity { get; set; }
        public string Token { get; set; }
        public long IndividualId { get; set; }
        public bool IsSuperHopper { get; set; }
        public bool IsBlocked { get; set; }
        public DateTime LastHopped { get; set; }
        public DateTime CreatedOn { get; set; }
        public long CreatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public long UpdatedBy { get; set; }
    }
}
