using BeeHive.L20.Services.SL20.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeeHive.L20.Services.SL10.IServices
{
    public interface IMenuService
    {
        List<MenuModel> GetAll();
        MenuModel GetById(int id);
        MenuModel Create(MenuModel model);
        MenuModel Update(MenuModel model);
        void Delete(int id);
    }
}
