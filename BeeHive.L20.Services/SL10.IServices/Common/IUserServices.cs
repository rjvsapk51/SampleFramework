using BeeHive.L20.Services.SL20.Model;
using BeeHive.L20.Services.SL20.Model.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeeHive.L20.Services.SL10.IServices.Common
{
    public interface IUserServices
    {
        List<HopperModel> GetAll();
        HopperModel GetById(int id);
        HopperModel Create(HopperModel model);
        HopperModel Update(HopperModel model);
        void Delete(int id);
        HopperModel GetUserByUserNameAndPassword(LoginModel model);
    }
}
