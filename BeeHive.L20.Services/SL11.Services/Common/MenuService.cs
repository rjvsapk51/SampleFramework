using AutoMapper;
using BeeHive.L20.Services.SL10.IServices;
using BeeHive.L20.Services.SL20.Model;
using BeeHive.L20.Services.SL20.Model.Lookup;
using BeeHive.L30.Domain.SL05.DomainModel.Lookup;
using BeeHive.L30.Domain.SL10.IRepository.Common;
using BeeHive.L30.Domain.SL20.Entities.Common;
using System.Collections.Generic;
using System.Linq;

namespace BeeHive.L20.Services.SL11.Services
{
    public class MenuService:IMenuService
    {
        private readonly IMenuRepository _menuRepository;
        private readonly IMapper _mapper;
        public MenuService(IMenuRepository menuRepository, IMapper mapper)
        {
            _menuRepository = menuRepository;
            _mapper = mapper;
        }

        public MenuModel Create(MenuModel model)
        {
            return _mapper.Map<MenuModel>(_menuRepository.Create(_mapper.Map<Menu>(model)));
        }

        public void Delete(int id)
        {
            _menuRepository.Delete(id);
        }

        public List<MenuModel> GetAll()
        {
            List<Menu> entities = _menuRepository.All();
            return _mapper.Map<List<MenuModel>>(entities);
        }

        public MenuModel GetById(int id)
        {
            Menu entity = _menuRepository.GetById(id);
            return _mapper.Map<MenuModel>(entity);
        }

        public MenuModel Update(MenuModel model)
        {
            return _mapper.Map<MenuModel>(_menuRepository.Update(_mapper.Map<Menu>(model)));
        }
        public List<MenuLookupModel> GetAllMenuLookup()
        {
            List<MenuLookup> menuLookup = _menuRepository.GetAllMenuLookup();
            return _mapper.Map<List<MenuLookupModel>>(menuLookup);
        }
    }
}
