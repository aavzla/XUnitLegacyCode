using System;
using XUnitLegacyCodeSproutMethod.Services;

namespace XUnitLegacyCodeSproutClass
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Here a list of the Employees:");

            var employeeService = new EmployeeService();
            var listEmployees = employeeService.GetEmployees();
            foreach (var employee in listEmployees)
            {
                Console.WriteLine($"Id = {employee.Id}, First Name = {employee.FirstName}, Last Name = {employee.LastName}");
            }

            Console.WriteLine("End of all employees.");
            Console.ReadKey();
        }
    }
}
