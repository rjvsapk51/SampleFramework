using BeeHive.L30.Domain.SL20.Entities;
using System.Collections.Generic;

namespace BeeHive.L30.Domain.SL10.IRepository
{
    public interface IEmployeeRepository
    {
        List<Employees> All();
        Employees GetById(int id);
        Employees Create(Employees domain);
        Employees Update(Employees domain);
        void Delete(int id);
    }
}
