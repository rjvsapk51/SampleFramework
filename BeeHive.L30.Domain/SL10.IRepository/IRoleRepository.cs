using BeeHive.L30.Domain.SL20.Entities.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeeHive.L30.Domain.SL10.IRepository
{
    public interface IRoleRepository
    {
        List<Role> All();
        Role GetById(int id);
        Role Create(Role domain);
        Role Update(Role domain);
        void Delete(int id);
    }
}
