using BeeHive.L20.Services.SL10.IServices;
using BeeHive.L20.Services.SL11.Services;
using BeeHive.L30.Domain.SL10.IRepository;
using BeeHive.L30.Domain.SL11.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeeHive.L10.API.Loaders
{
    public class DependencyContainer
    {
        public static void Initialize(IServiceCollection services)
        {
            services.AddSingleton<IEmployeeRepository, EmployeeRepository>();
            services.AddSingleton<IEmployeeService, EmployeeService>();
            services.AddSingleton<IMenuRepository, MenuRepository>();
            services.AddSingleton<IMenuService, MenuService>();
        }
    }
}
