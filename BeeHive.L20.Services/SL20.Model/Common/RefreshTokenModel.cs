using System;
using System.Collections.Generic;
using System.Text;

namespace BeeHive.L20.Services.SL20.Model.Common
{
    public class RefreshTokenModel
    {
        public long Id { get; set; }
        public long HopperId { get; set; }
        public string RefreshToken { get; set; }
    }
}
