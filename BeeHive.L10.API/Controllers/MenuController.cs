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
        IBeeHiveMenuService _menu;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="menu"></param>
        public MenuController(IBeeHiveMenuService menu)
        {
            _menu = menu;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<BeeHiveMenuModel> Create([FromBody]BeeHiveMenuModel model)
        {
            BeeHiveMenuModel menu = _menu.Create(model);
            return menu;
        }

    }
}