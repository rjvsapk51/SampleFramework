using BeeHive.L30.Domain.SL20.Entities.Common;
using System.Collections.Generic;

namespace BeeHive.L30.Domain.SL10.IRepository.Common
{
    public interface IRoleRepository
    {
        List<Role> All();
        Role GetById(long id);
        Role Create(Role domain);
        Role Update(Role domain);
        void Delete(long id);
    }
}
