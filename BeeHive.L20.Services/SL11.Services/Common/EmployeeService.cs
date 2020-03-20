using AutoMapper;
using BeeHive.L20.Services.SL10.IServices;
using BeeHive.L20.Services.SL20.Model;
using BeeHive.L30.Domain.SL10.IRepository.Common;
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
        public List<EmployeesModel> GetAll()
        {
            List<Employees> employee = _employeeRepository.All();                       
            return _mapper.Map<List<EmployeesModel>>(employee);
        }
        public EmployeesModel GetById(int id)
        {
            Employees employee = _employeeRepository.GetById(id);
            return _mapper.Map<EmployeesModel>(employee);            
        }
        public EmployeesModel Create(EmployeesModel model)
        {
            return _mapper.Map<EmployeesModel>(_employeeRepository.Create(_mapper.Map<Employees>(model)));
        }

        public EmployeesModel Update(EmployeesModel model)
        {
            return _mapper.Map<EmployeesModel>(_employeeRepository.Update(_mapper.Map<Employees>(model)));
        }
        public  void Delete(int id)
        {
            _employeeRepository.Delete(id);
        }
        
    }
}
