using BeeHive.L30.Domain.SL20.Entities.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeeHive.L30.Domain.SL10.IRepository.Common
{
    public interface IRefreshTokenRepository
    {
        List<RefreshTokens> All();
        RefreshTokens GetById(long id);
        RefreshTokens Create(RefreshTokens domain);
        RefreshTokens Update(RefreshTokens domain);
        void Delete(long id);
        RefreshTokens GetByRefreshToken(string token);
    }
}
