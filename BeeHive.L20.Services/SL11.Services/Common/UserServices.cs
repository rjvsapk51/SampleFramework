using AutoMapper;
using BeeHive.L20.Services.SL10.IServices.Common;
using BeeHive.L20.Services.SL20.Model;
using BeeHive.L20.Services.SL20.Model.Common;
using BeeHive.L30.Domain.SL10.IRepository.Common;
using BeeHive.L30.Domain.SL20.Entities.Common;
using System.Collections.Generic;

namespace BeeHive.L20.Services.SL11.Services.Common
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserServices(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public HopperModel Create(HopperModel model)
        {
            return _mapper.Map<HopperModel>(_userRepository.Create(_mapper.Map<Hopper>(model)));
        }

        public void Delete(int id)
        {
            _userRepository.Delete(id);
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
            return _mapper.Map<HopperModel>(_userRepository.Update(_mapper.Map<Hopper>(model)));
        }
        public HopperModel GetUserByUserNameAndPassword(LoginModel model)
        {
            return _mapper.Map<HopperModel>(_userRepository.GetUserByUserNameAndPassword(model.Username,model.Password));
        }
    }
}
