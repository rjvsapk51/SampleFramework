using BeeHive.L20.Services.SL20.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeeHive.L20.Services.SL10.IServices
{
    public interface IRoleServices
    {
        List<RoleModel> GetAll();
        RoleModel GetById(int id);
        RoleModel Create(RoleModel model);
        RoleModel Update(RoleModel model);
        void Delete(int id);
    }
}
