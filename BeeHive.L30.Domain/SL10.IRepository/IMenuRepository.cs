using BeeHive.L30.Domain.SL20.Entities.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeeHive.L30.Domain.SL10.IRepository
{
    public interface IMenuRepository
    {
        List<Menu> All();
        Menu GetById(int id);
        Menu Create(Menu domain);
        Menu Update(Menu domain);
        void Delete(int id);
    }
}
