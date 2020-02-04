using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeeHive.L20.Services.SL10.IServices;
using BeeHive.L20.Services.SL20.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BeeHive.L10.API.Controllers
{
    /// <summary>
    /// CRUD Roles
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleServices _role;
       /// <summary>
       /// 
       /// </summary>
       /// <param name="role"></param>
        public RoleController(IRoleServices role)
        {
            _role = role;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<IEnumerable<RoleModel>> Get()
        {
            List<RoleModel> record = _role.GetAll();
            return record;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ActionResult<RoleModel> GetById(int id)
        {

            RoleModel record = _role.GetById(id);
            return record;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<RoleModel> Create([FromBody]RoleModel model)
        {
            if (ModelState.IsValid)
            {
                RoleModel record = _role.Create(model);
                return record;
            }
            else
            {
                return ValidationProblem();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        public ActionResult<RoleModel> Update([FromBody]RoleModel model)
        {
            if (ModelState.IsValid)
            {
                RoleModel record = _role.Update(model);
                return record;
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
            _role.Delete(id);
            return Ok("Role deleted successfully.");
        }


    }
}