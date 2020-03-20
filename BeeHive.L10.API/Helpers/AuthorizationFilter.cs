using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System;

namespace BeeHive.L10.API.Helpers
{
    /// <summary>
    ///  If This class is called as an attribute in an action or a controller.
    ///  The controller has to pass through the authoriation test
    /// </summary>
    public class AuthorizationFilter : Attribute, IActionFilter
    {
        private readonly IActionDescriptorCollectionProvider _actionDescriptorCollectionProvider;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="actionDescriptorCollectionProvider"></param>
        public AuthorizationFilter(IActionDescriptorCollectionProvider actionDescriptorCollectionProvider)
        {
            _actionDescriptorCollectionProvider = actionDescriptorCollectionProvider;
        }
        /// <summary>
        /// Prior to executing
        /// </summary>
        /// <param name="context"></param>
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var controllerName = ((ControllerBase)context.Controller).ControllerContext.ActionDescriptor.ControllerName;
            var actionName = ((ControllerBase)context.Controller).ControllerContext.ActionDescriptor.ActionName;

            context.Result = new ForbidResult();


        }
        /// <summary>
        /// Post executing.
        /// </summary>
        /// <param name="context"></param>
        public void OnActionExecuted(ActionExecutedContext context)
        {


        }
    }
}
