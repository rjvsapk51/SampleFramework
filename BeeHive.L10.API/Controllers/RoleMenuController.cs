using BeeHive.L20.Services.SL10.IServices;
using BeeHive.L20.Services.SL20.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BeeHive.L10.API.Controllers
{
    /// <summary>
    /// RoleMenu actions
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class RoleMenuController : ControllerBase
    {
        private readonly IRoleMenuServices _roleMenu;
        /// <summary>
        /// Role Menu Constructor
        /// </summary>
        /// <param name="roleMenu"></param>
        public RoleMenuController(IRoleMenuServices roleMenu)
        {
            _roleMenu = roleMenu;
        }
        /// <summary>
        /// Get all role menus
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<IEnumerable<RoleMenuModel>> Get()
        {
            List<RoleMenuModel> record = _roleMenu.GetAll();
            return Ok(record);
        }
        /// <summary>
        /// Get a role menu by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ActionResult<RoleMenuModel> GetById(int id)
        {
            RoleMenuModel record = _roleMenu.GetById(id);
            return Ok(record);
        }
        /// <summary>
        /// Create a new role menu
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<RoleMenuModel> Create([FromBody]RoleMenuModel model)
        {
            if (ModelState.IsValid)
            {
                RoleMenuModel record = _roleMenu.Create(model);
                return Created("Test uri", record);
            }
            else
            {
                return ValidationProblem();
            }
        }
        /// <summary>
        /// Update a role menu
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        public ActionResult<RoleMenuModel> Update([FromBody]RoleMenuModel model)
        {
            if (ModelState.IsValid)
            {
                RoleMenuModel record = _roleMenu.Update(model);
                return Ok(record);
            }
            else
            {
                return ValidationProblem();
            }
        }
        /// <summary>
        /// Delete a role menu
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _roleMenu.Delete(id);
            return Ok("Role deleted successfully.");
        }
    }
}