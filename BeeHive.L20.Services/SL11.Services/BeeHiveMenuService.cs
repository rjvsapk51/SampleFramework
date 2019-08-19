using System.Collections.Generic;
using AutoMapper;
using BeeHive.L20.Services.SL10.IServices;
using BeeHive.L20.Services.SL20.Model;
using BeeHive.L30.Domain.SL10.IRepository;
using BeeHive.L30.Domain.SL20.Entities;

namespace BeeHive.L20.Services.SL11.Services
{
    public class BeeHiveMenuService : IBeeHiveMenuService
    {
        private readonly IBeeHiveMenuRepository _beeHiveMenuRepository;
        private readonly IMapper _mapper;
        public BeeHiveMenuService(IBeeHiveMenuRepository beeHiveMenuRepository, IMapper mapper)
        {
            _beeHiveMenuRepository = beeHiveMenuRepository;
            _mapper = mapper;
        }

        public BeeHiveMenuModel Create(BeeHiveMenuModel model)
        {
            return _mapper.Map<BeeHiveMenuModel>(_beeHiveMenuRepository.Create(_mapper.Map<BeeHiveMenu>(model)));
        }

        public void Delete(int id)
        {
            _beeHiveMenuRepository.Delete(id);
        }

        public List<BeeHiveMenuModel> GetAll()
        {
            List<BeeHiveMenu> entities = _beeHiveMenuRepository.All();
            return _mapper.Map<List<BeeHiveMenuModel>>(entities);
        }

        public BeeHiveMenuModel GetById(int id)
        {
            BeeHiveMenu entity = _beeHiveMenuRepository.GetById(id);
            return _mapper.Map<BeeHiveMenuModel>(entity);
        }

        public BeeHiveMenuModel Update(BeeHiveMenuModel model)
        {
            return _mapper.Map<BeeHiveMenuModel>(_beeHiveMenuRepository.Update(_mapper.Map<BeeHiveMenu>(model)));
        }
    }
}
