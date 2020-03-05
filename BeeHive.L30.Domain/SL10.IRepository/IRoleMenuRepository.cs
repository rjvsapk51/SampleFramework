using BeeHive.L30.Domain.SL20.Entities.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeeHive.L30.Domain.SL10.IRepository
{
    public interface IRoleMenuRepository
    {
        List<RoleMenu> All();
        RoleMenu GetById(int id);
        RoleMenu Create(RoleMenu domain);
        RoleMenu Update(RoleMenu domain);
        void Delete(int id);
    }
}
