using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeeHive.L20.Services.SL10.IServices.Common;
using BeeHive.L20.Services.SL20.Model.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BeeHive.L10.API.Controllers.Common
{
    /// <summary>
    /// User Create, Read, Update and Delete
    /// </summary>
   [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserServices _user;
        /// <summary>
        /// User Create, Read, Update & Delete
        /// </summary>
        /// <param name="user"></param>
        public UserController(IUserServices user)
        {
            _user = user;
        }
        /// <summary>
        /// Get all user
        /// </summary>
        /// <returns>Menu list</returns>
        [HttpGet]
        public ActionResult<IEnumerable<HopperModel>> Get()
        {
            try
            {
                List<HopperModel> record = _user.GetAll();
                return Ok(record);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        /// <summary>
        /// Get user by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ActionResult<HopperModel> GetById(int id)
        {
            try
            {
                HopperModel record = _user.GetById(id);
                return Ok(record);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        /// <summary>
        /// Create User
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<HopperModel> Create([FromBody]HopperModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    HopperModel menu = _user.Create(model);
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
        /// Update user
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        public ActionResult<HopperModel> Update([FromBody]HopperModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    HopperModel record = _user.Update(model);
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
        /// Delete a user
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                _user.Delete(id);
                return Ok("User deleted successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}