using BeeHive.L20.Services.SL20.Model.Common;

namespace BeeHive.L10.API.Authentication
{
    public interface ITokenGenerator
    {
        AuthenticationModel GenerateToken(HopperModel user);
        RefreshToken GenerateRefereshToken(long userId);
        bool ValidateRefreshToken(string token);
    }
}