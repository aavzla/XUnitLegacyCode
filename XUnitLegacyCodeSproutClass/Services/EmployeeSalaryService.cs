using System.Collections.Generic;
using XUnitLegacyCodeSproutClass.Services.Interfaces;
using XUnitLegacyCodeSproutClass.Models;

namespace XUnitLegacyCodeSproutClass.Services
{
    public class EmployeeSalaryService : IEmployeeService
    {
        /*
         * This Service is for returning the employee with their Salary information as it was added to the Legacy code.
         * This is done to avoid modify and break code for references in the project for the GetEmployees method in the EmployeeService.
         * All new code could implement this service instead the EmployeeService and we can test this service.
        */
        public IList<Employee> GetEmployees()
        {
            var result = new List<Employee>();

            //The databaseService has a new method in order to get the employees with their salary.
            //var listFromDB = databaseService.GetEmployeesWithSalary();
            //mappingService.Map(listFromDB, out result);

            //Sample data of the database:
            result.Add(new Employee { Id = 1, FirstName = "Harry", LastName = "Potter", Salary = 35.42m });

            return result;
        }
    }
}
