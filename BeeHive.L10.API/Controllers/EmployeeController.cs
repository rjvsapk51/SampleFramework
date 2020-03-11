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
        public ActionResult<IEnumerable<EmployeesModel>> Get()
        {           
            List<EmployeesModel> employee = _employee.GetAll();
            return employee;
        }
        /// <summary>
        /// This is second test
        /// </summary>
        /// <param name="id"> this is test variables.</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [Authorize(Roles = "User")]
        public ActionResult<EmployeesModel> GetById(int id)
        {
           
            EmployeesModel employee = _employee.GetById(id);
            return employee;
        }
        /// <summary>
        /// create
        /// </summary>
        /// <param name="model">dd</param>
        /// <returns>ssss</returns>
        [HttpPost]
        public ActionResult<EmployeesModel> Create([FromBody]EmployeesModel model)
        {
            if (ModelState.IsValid)
            {
                EmployeesModel employee = _employee.Create(model);
                return employee;
            }
            else
            {
                return ValidationProblem();
            }           
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        public ActionResult<EmployeesModel> Update([FromBody]EmployeesModel model)
        {
            if (ModelState.IsValid)
            {
                EmployeesModel employee = _employee.Update(model);
                return employee;
            }
            else
            {
                return ValidationProblem();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _employee.Delete(id);
            return Ok("Employee deleted successfully.");
        }

    }
}