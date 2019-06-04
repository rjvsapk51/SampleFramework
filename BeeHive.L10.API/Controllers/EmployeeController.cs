using BeeHive.L20.Services.SL10.IServices;
using BeeHive.L20.Services.SL20.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BeeHive.L10.API.Controllers
{
    /// <summary>
    /// Employee controller
    /// </summary>
    [Route("[controller]")]
    [ApiController] 
    public class EmployeeController : ControllerBase
    {
        IEmployeeService _employee;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="employee"></param>
        public EmployeeController(IEmployeeService employee)
        {
            _employee = employee;
        }
        /// <summary>
        /// This is test
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult<IEnumerable<EmployeeModel>> Get()
        {           
            List<EmployeeModel> employee = _employee.GetEmployee();
            return employee;
        }
        /// <summary>
        /// This is second test
        /// </summary>
        /// <param name="id"> this is test variables.</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [Authorize(Roles = "User,Admin")]
        public ActionResult<EmployeeModel> GetById(int id)
        {
           
            EmployeeModel employee = _employee.GetEmployee(id);
            return employee;
        }
    }
}