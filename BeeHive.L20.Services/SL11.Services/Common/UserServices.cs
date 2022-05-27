using AutoMapper;
using BeeHive.L20.Services.SL10.IServices.Common;
using BeeHive.L20.Services.SL20.Model;
using BeeHive.L20.Services.SL20.Model.Common;
using BeeHive.L30.Domain.SL10.IRepository.Common;
using BeeHive.L30.Domain.SL20.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

namespace BeeHive.L20.Services.SL11.Services.Common
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserRolesRepository _userRoleRepository;
        private readonly IMapper _mapper;
        public UserServices(IUserRepository userRepository, IMapper mapper, IUserRolesRepository userRoleRepository)
        {
            _userRoleRepository = userRoleRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public HopperModel Create(HopperModel model)
        {      
            using (TransactionScope scope = new TransactionScope())
            {
                HopperModel hopper = _mapper.Map<HopperModel>(_userRepository.Create(_mapper.Map<Hopper>(model)));
                foreach (long roleId in model.RoleIds)
                {
                    UserRoles userRoles = new UserRoles
                    {
                        RoleId = roleId,
                        UserId = hopper.Id,
                        CreatedBy = model.CreatedBy,
                        CreatedOn = DateTime.Now,
                        UpdatedBy = model.CreatedBy,
                        UpdatedOn = DateTime.Now
                    };
                    _userRoleRepository.Create(userRoles);
                }
                scope.Complete();
                return hopper;
            }    
        }

        public void Delete(int id)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                List<UserRoles> userRoles = _userRoleRepository.GetByUserId(id);
                foreach (UserRoles item in userRoles)
                {
                    _userRoleRepository.Delete(item.Id);
                }
                _userRepository.Delete(id);
            }   
        }

        public List<HopperModel> GetAll()
        {
            List<Hopper> entities = _userRepository.All();
            return _mapper.Map<List<HopperModel>>(entities);
        }

        public HopperModel GetById(long id)
        {
            Hopper entity = _userRepository.GetById(id);
            return _mapper.Map<HopperModel>(entity);
        }

        public HopperModel Update(HopperModel model)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                List<UserRoles> pastRoles = _userRoleRepository.GetByUserId(model.Id);
                foreach (UserRoles item in pastRoles)
                {
                    _userRoleRepository.Delete(item.Id);
                }
                foreach (long roleId in model.RoleIds)
                {
                    UserRoles userRoles = new UserRoles
                    {
                        RoleId = roleId,
                        UserId = model.Id,
                        CreatedBy = model.CreatedBy,
                        CreatedOn = DateTime.Now,
                        UpdatedBy = model.CreatedBy,
                        UpdatedOn = DateTime.Now
                    };
                    _userRoleRepository.Create(userRoles);
                }
               Hopper updatedUser =  _userRepository.Update(_mapper.Map<Hopper>(model));
                scope.Complete();
                return _mapper.Map<HopperModel>(updatedUser);
            }      
        }
        public HopperModel GetUserByUserNameAndPassword(LoginModel model)
        {
            return _mapper.Map<HopperModel>(_userRepository.GetUserByUserNameAndPassword(model.Username, model.Password));
        }
    }
}
