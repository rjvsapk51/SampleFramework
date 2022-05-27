using BeeHive.L20.Services.SL10.IServices.Common;
using BeeHive.L20.Services.SL20.Model.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BeeHive.L10.API.Controllers.Common
{
    /// <summary>
    /// Configure User - Roles Map
    /// </summary>
    //[Authorize]
    [Route("[controller]")]
    [ApiController]
    public class UserRolesController : ControllerBase
    {
        IUserRolesServices _userRoles;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userRoles"></param>
        public UserRolesController(IUserRolesServices userRoles)
        {
            _userRoles = userRoles;
        }
        /// <summary>
        /// Get All
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<IEnumerable<UserRolesModel>> Get()
        {
            try
            {
                List<UserRolesModel> record = _userRoles.GetAll();
                return Ok(record);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        /// <summary>
        /// Get By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ActionResult<UserRolesModel> GetById(int id)
        {
            try
            {
                UserRolesModel record = _userRoles.GetById(id);
                return Ok(record);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        /// <summary>
        /// Create User Roles Map
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<UserRolesModel> Create([FromBody] UserRolesModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var claimsIdentity = User.Identity as ClaimsIdentity;
                    long Id = Convert.ToInt64(claimsIdentity.FindFirst("Id").Value);
                    model.CreatedBy = Id;
                    model.CreatedOn = DateTime.Now;
                    UserRolesModel menu = _userRoles.Create(model);
                    return menu;
                }
                else
                    return ValidationProblem();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        /// <summary>
        /// Update User Roles Map
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        public ActionResult<UserRolesModel> Update([FromBody] UserRolesModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var claimsIdentity = User.Identity as ClaimsIdentity;
                    long Id = Convert.ToInt64(claimsIdentity.FindFirst("Id").Value);
                    model.UpdatedBy = Id;
                    model.UpdatedOn = DateTime.Now;
                    UserRolesModel record = _userRoles.Update(model);
                    return Ok(record);
                }
                else
                    return ValidationProblem();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        /// <summary>
        /// Delete User Roles map
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                _userRoles.Delete(id);
                return Ok("User deleted successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        /// <summary>
        /// Get All roles of user by user id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet("GetByUserId")]
        public ActionResult<IEnumerable<long>> GetByUserId( long userId)
        {
            try
            {
                List<UserRolesModel> record = _userRoles.GetByUserId(userId);
                List<long> selectedIDs = record.Select(x => x.RoleId).ToList();
                return Ok(selectedIDs);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
