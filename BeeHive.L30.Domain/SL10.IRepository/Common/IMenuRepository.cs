using BeeHive.L30.Domain.SL05.DomainModel.Lookup;
using BeeHive.L30.Domain.SL20.Entities.Common;
using System.Collections.Generic;

namespace BeeHive.L30.Domain.SL10.IRepository.Common
{
    public interface IMenuRepository
    {
        List<Menu> All();
        Menu GetById(long id);
        Menu Create(Menu domain);
        Menu Update(Menu domain);
        void Delete(long id);
        List<MenuLookup> GetAllMenuLookup();
    }
}
