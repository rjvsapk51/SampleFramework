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
    public class RefreshTokenService : IRefreshTokenService
    {
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        private readonly IMapper _mapper;
        public RefreshTokenService(IRefreshTokenRepository refreshTokenRepository, IMapper mapper)
        {
            _refreshTokenRepository = refreshTokenRepository;
            _mapper = mapper;
        }
        public List<RefreshTokenModel> GetAll()
        {
            List<RefreshTokens> refreshToken = _refreshTokenRepository.All();
            return _mapper.Map<List<RefreshTokenModel>>(refreshToken);
        }
        public RefreshTokenModel GetById(int id)
        {
            RefreshTokens refreshToken = _refreshTokenRepository.GetById(id);
            return _mapper.Map<RefreshTokenModel>(refreshToken);
        }
        public RefreshTokenModel Create(RefreshTokenModel model)
        {
            return _mapper.Map<RefreshTokenModel>(_refreshTokenRepository.Create(_mapper.Map<RefreshTokens>(model)));
        }

        public RefreshTokenModel Update(RefreshTokenModel model)
        {
            return _mapper.Map<RefreshTokenModel>(_refreshTokenRepository.Update(_mapper.Map<RefreshTokens>(model)));
        }
        public void Delete(long id)
        {
            _refreshTokenRepository.Delete(id);
        }

        public RefreshTokenModel GetByRefreshToken(string token)
        {
            RefreshTokens refreshToken = _refreshTokenRepository.GetByRefreshToken(token);
            return _mapper.Map<RefreshTokenModel>(refreshToken);
        }
    }
}
