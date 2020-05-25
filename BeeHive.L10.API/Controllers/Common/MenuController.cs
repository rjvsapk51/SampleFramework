using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeeHive.L20.Services.SL10.IServices;
using BeeHive.L20.Services.SL20.Model;
using BeeHive.L20.Services.SL20.Model.Lookup;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BeeHive.L10.API.Controllers
{
    /// <summary>
    /// Menu controller
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        IMenuService _menu;
        /// <summary>
        /// Menu CRUD
        /// </summary>
        /// <param name="menu"></param>
        public MenuController(IMenuService menu)
        {
            _menu = menu;
        }
        /// <summary>
        /// Get all menu
        /// </summary>
        /// <returns>Menu list</returns>
        [HttpGet]
        public ActionResult<IEnumerable<MenuModel>> Get()
        {
            try
            {
                List<MenuModel> record = _menu.GetAll();
                return Ok(record);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        /// <summary>
        /// Get a menu by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ActionResult<MenuModel> GetById(int id)
        {
            try
            {
                MenuModel record = _menu.GetById(id);
                return Ok(record);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        /// <summary>
        /// Create Menu
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<MenuModel> Create([FromBody]MenuModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    MenuModel menu = _menu.Create(model);
                    return menu;
                }
                else
                    return ValidationProblem();
            }catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            
        }
        /// <summary>
        /// Update a menu
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        public ActionResult<MenuModel> Update([FromBody]MenuModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    MenuModel record = _menu.Update(model);
                    return Ok(record);
                }
                else
                    return ValidationProblem();
            }catch (Exception ex)
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
                _menu.Delete(id);
                return Ok("Role deleted successfully.");
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        /// <summary>
        /// Fetch Id, Banner of all the menu
        /// </summary>
        /// <returns>Menu as lookup</returns>
        [HttpGet("GetAllMenuLookup")]
        public ActionResult<IEnumerable<MenuLookupModel>> GetAllMenuLookup()
        {
            try
            {
                List<MenuLookupModel> record = _menu.GetAllMenuLookup();
                return Ok(record);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}