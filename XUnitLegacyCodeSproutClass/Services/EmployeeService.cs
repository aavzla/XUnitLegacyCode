using System.Collections.Generic;
using XUnitLegacyCodeSproutClass.Services.Interfaces;
using XUnitLegacyCodeSproutClass.Models;

namespace XUnitLegacyCodeSproutClass.Services
{
    public class EmployeeService : IEmployeeService
    {
        //This Service is for returning the employee information as it was for the Legacy.
        public IList<Employee> GetEmployees()
        {
            var result = new List<Employee>();

            //Normally, we get the data from the database with a service as below.
            //var listFromDB = databaseService.GetEmployees();
            //mappingService.Map(listFromDB, out result);

            //Sample data of the database:
            result.Add(new Employee { Id = 1, FirstName = "Harry", LastName = "Potter" });

            return result;
        }
    }
}
