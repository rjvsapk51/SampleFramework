using BeeHive.L20.Services.SL20.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeeHive.L20.Services.SL10.IServices
{
    public interface IRoleMenuServices
    {
        List<RoleMenuModel> GetAll();
        RoleMenuModel GetById(int id);
        RoleMenuModel Create(RoleMenuModel model);
        RoleMenuModel Update(RoleMenuModel model);
        void Delete(int id);
        List<RoleMenuModel> GetByRoleId(long roleId);
    }
}
