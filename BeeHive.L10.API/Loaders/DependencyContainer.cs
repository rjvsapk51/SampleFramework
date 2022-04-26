using BeeHive.L10.API.Authentication;
using BeeHive.L20.Services.SL10.IServices;
using BeeHive.L20.Services.SL10.IServices.Common;
using BeeHive.L20.Services.SL11.Services;
using BeeHive.L20.Services.SL11.Services.Common;
using BeeHive.L30.Domain.SL10.IRepository.Common;
using BeeHive.L30.Domain.SL11.Repository.Common;
using Microsoft.Extensions.DependencyInjection;

namespace BeeHive.L10.API.Loaders
{
    /// <summary>
    /// 
    /// </summary>
    public class DependencyContainer
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        public static void Initialize(IServiceCollection services)
        {
            services.AddSingleton<ITokenGenerator,TokenGenerator>();
            services.AddSingleton<IEmployeeRepository, EmployeeRepository>();
            services.AddSingleton<IEmployeeService, EmployeeService>();
            services.AddSingleton<IMenuRepository, MenuRepository>();
            services.AddSingleton<IMenuService, MenuService>();
            services.AddSingleton<IRoleRepository, RoleRepository>();
            services.AddSingleton<IRoleServices, RoleServices>();
            services.AddSingleton<IRoleMenuRepository, RoleMenuRepository>();
            services.AddSingleton<IRoleMenuServices, RoleMenuServices>();
            services.AddSingleton<IUserRepository, UserRepository>();
            services.AddSingleton<IUserServices, UserServices>();
            services.AddSingleton<IRefreshTokenRepository, RefreshTokenRepository>();
            services.AddSingleton<IRefreshTokenService, RefreshTokenService>();

        }
    }
}
