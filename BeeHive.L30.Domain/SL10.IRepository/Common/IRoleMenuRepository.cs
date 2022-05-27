using BeeHive.L30.Domain.SL20.Entities.Common;
using System.Collections.Generic;

namespace BeeHive.L30.Domain.SL10.IRepository.Common
{
    public interface IRoleMenuRepository
    {
        List<RoleMenu> All();
        RoleMenu GetById(long id);
        RoleMenu Create(RoleMenu domain);
        RoleMenu Update(RoleMenu domain);
        void Delete(long id);
        List<RoleMenu> GetByRoleId(long roleId);
    }
}
