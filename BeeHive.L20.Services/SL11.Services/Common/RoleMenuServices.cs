using AutoMapper;
using BeeHive.L20.Services.SL10.IServices;
using BeeHive.L20.Services.SL20.Model;
using BeeHive.L30.Domain.SL10.IRepository.Common;
using BeeHive.L30.Domain.SL20.Entities.Common;
using System.Collections.Generic;

namespace BeeHive.L20.Services.SL11.Services
{
    public class RoleMenuServices:IRoleMenuServices
    {
        private readonly IRoleMenuRepository _roleMenuRepository;
        private readonly IMapper _mapper;
        public RoleMenuServices(IRoleMenuRepository roleMenuRepository, IMapper mapper)
        {
            _roleMenuRepository = roleMenuRepository;
            _mapper = mapper;
        }
        public List<RoleMenuModel> GetAll()
        {
            List<RoleMenu> entities = _roleMenuRepository.All();
            return _mapper.Map<List<RoleMenuModel>>(entities);
        }
        public RoleMenuModel GetById(int id)
        {
            RoleMenu entity = _roleMenuRepository.GetById(id);
            return _mapper.Map<RoleMenuModel>(entity);
        }
        public RoleMenuModel Create(RoleMenuModel model)
        {
            return _mapper.Map<RoleMenuModel>(_roleMenuRepository.Create(_mapper.Map<RoleMenu>(model)));
        }

        public RoleMenuModel Update(RoleMenuModel model)
        {
            return _mapper.Map<RoleMenuModel>(_roleMenuRepository.Update(_mapper.Map<RoleMenu>(model)));
        }
        public void Delete(int id)
        {
            _roleMenuRepository.Delete(id);
        }
        public List<RoleMenuModel> GetByRoleId(long roleId)
        {
            List<RoleMenu> entities = _roleMenuRepository.GetByRoleId(roleId);
            return _mapper.Map<List<RoleMenuModel>>(entities);
        }
    }
}
