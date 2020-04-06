using System;
using XUnitLegacyCodeSproutClass.Services;

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

            Console.WriteLine("Here is the list of Employees with Salary");

            var employeeWithSalaryService = new EmployeeSalaryService();
            listEmployees = employeeWithSalaryService.GetEmployees();
            foreach (var employeeWithSalary in listEmployees)
            {
                Console.WriteLine($"Id = {employeeWithSalary.Id}, First Name = {employeeWithSalary.FirstName}, Last Name = {employeeWithSalary.LastName}, Salary = {employeeWithSalary.Salary}");
            }
            Console.WriteLine("End of all employees.");
            Console.ReadKey();
        }
    }
}
