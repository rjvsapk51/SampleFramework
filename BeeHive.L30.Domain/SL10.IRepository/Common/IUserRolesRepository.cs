using BeeHive.L30.Domain.SL20.Entities.Common;
using System.Collections.Generic;

namespace BeeHive.L30.Domain.SL10.IRepository.Common
{
    public interface IUserRolesRepository
    {
        List<UserRoles> All();
        UserRoles GetById(long id);
        UserRoles Create(UserRoles domain);
        UserRoles Update(UserRoles domain);
        void Delete(long id);
        List<UserRoles> GetByUserId(long userId);
    }
}
