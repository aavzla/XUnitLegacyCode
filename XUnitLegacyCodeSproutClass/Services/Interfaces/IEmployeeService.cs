using System.Collections.Generic;
using XUnitLegacyCodeSproutClass.Models;

namespace XUnitLegacyCodeSproutClass.Services.Interfaces
{
    public interface IEmployeeService
    {
        IList<Employee> GetEmployees();
    }
}
