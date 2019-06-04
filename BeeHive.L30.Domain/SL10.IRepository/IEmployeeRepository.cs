using BeeHive.L30.Domain.SL20.Entities;
using System.Collections.Generic;

namespace BeeHive.L30.Domain.SL10.IRepository
{
    public interface IEmployeeRepository
    {
        List<Employee> All();
        Employee GetById(int id);
        Employee Create(Employee domain);
        Employee Update(Employee domain);
    }
}
