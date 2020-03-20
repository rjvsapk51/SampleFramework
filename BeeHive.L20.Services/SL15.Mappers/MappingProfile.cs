using AutoMapper;
using BeeHive.L20.Services.SL20.Model;
using BeeHive.L20.Services.SL20.Model.Common;
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
            CreateMap<RoleModel, Role>();
            CreateMap<Role, RoleModel > ();
            CreateMap<RoleMenu, RoleMenuModel>();
            CreateMap<Hopper, HopperModel>();
            CreateMap<HopperModel, Hopper>();
        }
    }
}
