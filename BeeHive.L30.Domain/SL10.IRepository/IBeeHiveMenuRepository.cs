using BeeHive.L30.Domain.SL20.Entities;
using System.Collections.Generic;

namespace BeeHive.L30.Domain.SL10.IRepository
{
    public interface IBeeHiveMenuRepository
    {
        List<BeeHiveMenu> All();
        BeeHiveMenu GetById(int id);
        BeeHiveMenu Create(BeeHiveMenu domain);
        BeeHiveMenu Update(BeeHiveMenu domain);
        void Delete(int id);
    }
}
