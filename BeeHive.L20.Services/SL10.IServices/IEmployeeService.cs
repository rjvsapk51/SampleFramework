﻿using BeeHive.L20.Services.SL20.Model;
using System.Collections.Generic;
namespace BeeHive.L20.Services.SL10.IServices
{
    public interface IEmployeeService
    {
        List<EmployeeModel> GetEmployee();
        EmployeeModel GetEmployee(int id);
    }
}