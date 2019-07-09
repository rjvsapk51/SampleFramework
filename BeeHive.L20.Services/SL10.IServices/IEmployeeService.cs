using BeeHive.L20.Services.SL20.Model;
using System.Collections.Generic;
namespace BeeHive.L20.Services.SL10.IServices
{
    public interface IEmployeeService
    {
        List<EmployeesModel> GetEmployee();
        EmployeesModel GetEmployee(int id);
        EmployeesModel Create(EmployeesModel model);
        EmployeesModel Update(EmployeesModel model);
        void Delete(int id);
    }
}
