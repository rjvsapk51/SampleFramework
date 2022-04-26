using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeeHive.L10.API.Authentication
{
    /// <summary>
    /// 
    /// </summary>
    public class AuthenticationModel
    {
        /// <summary>
        /// 
        /// </summary>
        public string AccessToken { get; set; }
        public DateTime Expiration { get; set; }
        public RefreshToken RefreshToken { get; set; }
    }
    public class RefreshToken
    {
        public string AccessToken { get; set; }
        public DateTime Expiration { get; set; }
    }
}
