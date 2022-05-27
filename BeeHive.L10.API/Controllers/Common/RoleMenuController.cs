using BeeHive.L20.Services.SL10.IServices;
using BeeHive.L20.Services.SL20.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

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
            try
            {
                List<RoleMenuModel> record = _roleMenu.GetAll();
                return Ok(record);
            }catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
          
        }
        /// <summary>
        /// Get a role menu by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ActionResult<RoleMenuModel> GetById(int id)
        {
            try
            {
                RoleMenuModel record = _roleMenu.GetById(id);
                return Ok(record);
            }catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            
        }
        /// <summary>
        /// Create a role menu
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<RoleMenuModel> Create([FromBody]RoleMenuModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    RoleMenuModel record = _roleMenu.Create(model);
                    return Created("Test uri", record);
                }
                else
                    return ValidationProblem();
            }
            catch(Exception ex)
            {
                return StatusCode(500,ex.Message);
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
            try
            {
                if (ModelState.IsValid)
                {
                    RoleMenuModel record = _roleMenu.Update(model);
                    return Ok(record);
                }
                else
                    return ValidationProblem();
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
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
            try
            {
                _roleMenu.Delete(id);
                return Ok("Role deleted successfully.");
            }catch(Exception ex)
            {
                return StatusCode(500,ex.Message);
            }
          
        }

        [HttpGet("GetByRoleId")]
        public ActionResult<IEnumerable<long>> GetByUserId(int roleId)
        {
            try
            {
                List<RoleMenuModel> record = _roleMenu.GetByRoleId(roleId);
                List<int> selectedIDs = record.Select(x => x.MenuId).ToList();
                return Ok(selectedIDs);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}