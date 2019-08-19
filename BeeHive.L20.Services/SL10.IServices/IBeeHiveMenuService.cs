using BeeHive.L20.Services.SL20.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeeHive.L20.Services.SL10.IServices
{
    public interface IBeeHiveMenuService
    {
        List<BeeHiveMenuModel> GetAll();
        BeeHiveMenuModel GetById(int id);
        BeeHiveMenuModel Create(BeeHiveMenuModel model);
        BeeHiveMenuModel Update(BeeHiveMenuModel model);
        void Delete(int id);
    }
}
