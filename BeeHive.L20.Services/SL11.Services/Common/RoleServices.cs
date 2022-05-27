using AutoMapper;
using BeeHive.L20.Services.SL10.IServices;
using BeeHive.L20.Services.SL20.Model;
using BeeHive.L30.Domain.SL10.IRepository.Common;
using BeeHive.L30.Domain.SL20.Entities.Common;
using System;
using System.Collections.Generic;
using System.Transactions;

namespace BeeHive.L20.Services.SL11.Services
{
    public class RoleServices : IRoleServices
    {
        private readonly IRoleMenuRepository _roleMenuRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;
        public RoleServices(IRoleRepository roleRepository, IMapper mapper, IRoleMenuRepository roleMenuRepository)
        {
            _roleMenuRepository = roleMenuRepository;
            _roleRepository = roleRepository;
            _mapper = mapper;
        }
        public List<RoleModel> GetAll()
        {
            List<Role> entities = _roleRepository.All();
            return _mapper.Map<List<RoleModel>>(entities);
        }
        public RoleModel GetById(int id)
        {
            Role entity = _roleRepository.GetById(id);
            return _mapper.Map<RoleModel>(entity);
        }
        public RoleModel Create(RoleModel model)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                RoleModel role = _mapper.Map<RoleModel>(_roleRepository.Create(_mapper.Map<Role>(model)));
                foreach (long menuId in model.Name)
                {
                    RoleMenu roleMenu = new RoleMenu
                    {
                        RoleId = role.Id,
                        MenuId = menuId,
                        CreatedBy = model.CreatedBy,
                        CreatedOn = DateTime.Now,
                        UpdatedBy = model.CreatedBy,
                        UpdatedOn = DateTime.Now
                    };
                    _roleMenuRepository.Create(roleMenu);
                }
                scope.Complete();
                return role;
            }
        }

        public RoleModel Update(RoleModel model)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                List<RoleMenu> pastMenus = _roleMenuRepository.GetByRoleId(model.Id);
                foreach (RoleMenu item in pastMenus)
                {
                    _roleMenuRepository.Delete(item.Id);
                }
                foreach (long menuId in model.MenuIds)
                {
                    RoleMenu userRoles = new RoleMenu
                    {
                        RoleId = model.Id,
                        MenuId = menuId,
                        CreatedBy = model.CreatedBy,
                        CreatedOn = DateTime.Now,
                        UpdatedBy = model.CreatedBy,
                        UpdatedOn = DateTime.Now
                    };
                    _roleMenuRepository.Create(userRoles);
                }
                Role updatedUser = _roleRepository.Update(_mapper.Map<Role>(model));
                scope.Complete();
                return _mapper.Map<RoleModel>(updatedUser);
            }
        }
        public void Delete(int id)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                List<RoleMenu> userRoles = _roleMenuRepository.GetByRoleId(id);
                foreach (RoleMenu item in userRoles)
                {
                    _roleMenuRepository.Delete(item.Id);
                }
                _roleRepository.Delete(id);
                scope.Complete();
            }
        }
    }
}
