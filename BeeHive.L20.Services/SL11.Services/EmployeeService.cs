using AutoMapper;
using BeeHive.L20.Services.SL10.IServices;
using BeeHive.L20.Services.SL20.Model;
using BeeHive.L30.Domain.SL10.IRepository;
using BeeHive.L30.Domain.SL20.Entities;
using System.Collections.Generic;

namespace BeeHive.L20.Services.SL11.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;
        public EmployeeService(IEmployeeRepository employeeRepository,IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }
        public List<EmployeeModel> GetEmployee()
        {
            List<Employee> employee = _employeeRepository.All();                       
            return _mapper.Map<List<EmployeeModel>>(employee);
        }
        public EmployeeModel GetEmployee(int id)
        {
            Employee employee = _employeeRepository.GetById(id);
            return _mapper.Map<EmployeeModel>(employee);            
        }
    }
}
