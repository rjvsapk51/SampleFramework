using AutoMapper;
using BeeHive.L20.Services.SL10.IServices.Common;
using BeeHive.L20.Services.SL20.Model.Common;
using BeeHive.L30.Domain.SL10.IRepository.Common;
using BeeHive.L30.Domain.SL20.Entities.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeeHive.L20.Services.SL11.Services.Common
{
    public class UserRolesServices: IUserRolesServices
    {
        private readonly IUserRolesRepository _userRolesRepository;
        private readonly IMapper _mapper;
        public UserRolesServices(IUserRolesRepository userRolesRepository, IMapper mapper)
        {
            _userRolesRepository = userRolesRepository;
            _mapper = mapper;
        }

        public UserRolesModel Create(UserRolesModel model)
        {

            return _mapper.Map<UserRolesModel>(_userRolesRepository.Create(_mapper.Map<UserRoles>(model)));
        }

        public void Delete(int id)
        {
            _userRolesRepository.Delete(id);
        }

        public List<UserRolesModel> GetAll()
        {
            List<UserRoles> entities = _userRolesRepository.All();
            return _mapper.Map<List<UserRolesModel>>(entities);
        }

        public UserRolesModel GetById(long id)
        {
            UserRoles entity = _userRolesRepository.GetById(id);
            return _mapper.Map<UserRolesModel>(entity);
        }

        public UserRolesModel Update(UserRolesModel model)
        {
            return _mapper.Map<UserRolesModel>(_userRolesRepository.Update(_mapper.Map<UserRoles>(model)));
        }

        public List<UserRolesModel> GetByUserId(long userId)
        {
            List<UserRoles> entities = _userRolesRepository.GetByUserId(userId);
            return _mapper.Map<List<UserRolesModel>>(entities);
        }

    }
}
