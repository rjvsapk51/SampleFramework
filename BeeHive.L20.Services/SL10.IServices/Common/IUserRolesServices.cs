using BeeHive.L20.Services.SL20.Model;
using BeeHive.L20.Services.SL20.Model.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeeHive.L20.Services.SL10.IServices.Common
{
    public interface IUserRolesServices
    {
        List<UserRolesModel> GetAll();
        UserRolesModel GetById(long id);
        UserRolesModel Create(UserRolesModel model);
        UserRolesModel Update(UserRolesModel model);
        void Delete(int id);
        List<UserRolesModel> GetByUserId(long userId);
    }
}
