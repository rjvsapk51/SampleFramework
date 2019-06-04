using AutoMapper;
using BeeHive.L20.Services.SL20.Model;
using BeeHive.L30.Domain.SL20.Entities;

namespace BeeHive.L20.Services.SL15.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee, EmployeeModel>();
            CreateMap<EmployeeModel, Employee>();
        }
    }
}
