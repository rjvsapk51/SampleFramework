using BeeHive.L20.Services.SL20.Model.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeeHive.L20.Services.SL10.IServices.Common
{
    public interface IRefreshTokenService
    {
        List<RefreshTokenModel> GetAll();
        RefreshTokenModel GetById(int id);
        RefreshTokenModel Create(RefreshTokenModel model);
        RefreshTokenModel Update(RefreshTokenModel model);
        void Delete(long id);
        RefreshTokenModel GetByRefreshToken(string token);
    }
}
