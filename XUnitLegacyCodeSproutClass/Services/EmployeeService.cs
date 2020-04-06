using System.Collections.Generic;
using XUnitLegacyCodeSproutMethod.Models;

namespace XUnitLegacyCodeSproutMethod.Services
{
    public class EmployeeService
    {
        //This Service is for returning the employee information as it was for the Legacy.
        public List<Employee> GetEmployees()
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
