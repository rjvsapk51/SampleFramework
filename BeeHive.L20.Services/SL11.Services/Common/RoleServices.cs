using AutoMapper;
using BeeHive.L20.Services.SL10.IServices;
using BeeHive.L20.Services.SL20.Model;
using BeeHive.L30.Domain.SL10.IRepository.Common;
using BeeHive.L30.Domain.SL20.Entities.Common;
using System.Collections.Generic;

namespace BeeHive.L20.Services.SL11.Services
{
    public class RoleServices : IRoleServices
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;
        public RoleServices(IRoleRepository roleRepository,IMapper mapper)
        {
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
            return _mapper.Map<RoleModel>(_roleRepository.Create(_mapper.Map<Role>(model)));
        }

        public RoleModel Update(RoleModel model)
        {
            return _mapper.Map<RoleModel>(_roleRepository.Update(_mapper.Map<Role>(model)));
        }
        public void Delete(int id)
        {
            _roleRepository.Delete(id);
        }
    }
}
