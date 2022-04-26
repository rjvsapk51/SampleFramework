using BeeHive.L30.Domain.SL20.Entities.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeeHive.L30.Domain.SL10.IRepository.Common
{
    public interface IUserRepository
    {
        List<Hopper> All();
        Hopper GetById(long id);
        Hopper Create(Hopper domain);
        Hopper Update(Hopper domain);
        void Delete(long id);
        Hopper GetUserByUserNameAndPassword(string username,string password);
    }
}
