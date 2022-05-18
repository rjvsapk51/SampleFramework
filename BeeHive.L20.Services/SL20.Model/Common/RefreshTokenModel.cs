using System;

namespace BeeHive.L20.Services.SL20.Model.Common
{
    public class RefreshTokenModel
    {
        public long Id { get; set; }
        public long HopperId { get; set; }
        public string RefreshToken { get; set; }
        public DateTime Expiration { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
