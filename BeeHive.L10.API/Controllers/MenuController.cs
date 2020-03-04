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
    /// Employee controller
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
            List<MenuModel> record = _menu.GetAll();
            return Ok(record);
        }
        /// <summary>
        /// Create Menu
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<MenuModel> Create([FromBody]MenuModel model)
        {
            
            if (ModelState.IsValid)
            {
                MenuModel menu = _menu.Create(model);
                return menu;
            }
            else
                return ValidationProblem();

          
        }

    }
}