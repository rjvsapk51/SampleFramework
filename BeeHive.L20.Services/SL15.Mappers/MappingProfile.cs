using AutoMapper;
using BeeHive.L20.Services.SL20.Model;
using BeeHive.L20.Services.SL20.Model.Common;
using BeeHive.L20.Services.SL20.Model.Lookup;
using BeeHive.L30.Domain.SL05.DomainModel.Lookup;
using BeeHive.L30.Domain.SL20.Entities;
using BeeHive.L30.Domain.SL20.Entities.Common;

namespace BeeHive.L20.Services.SL15.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Employees, EmployeesModel>();
            CreateMap<EmployeesModel, Employees>();
            CreateMap<Menu, MenuModel>();
            CreateMap<MenuModel, Menu>();
            CreateMap<MenuLookup, MenuLookupModel>();
            CreateMap<RoleModel, Role>();
            CreateMap<Role, RoleModel > ();
            CreateMap<RoleMenu, RoleMenuModel>();
            CreateMap<Hopper, HopperModel>();
            CreateMap<HopperModel, Hopper>();
            CreateMap<RefreshTokenModel, RefreshTokens>();
            CreateMap<RefreshTokens, RefreshTokenModel>();
            CreateMap<UserRolesModel, UserRoles>();
            CreateMap<UserRoles, UserRolesModel>();
        }
    }
}
