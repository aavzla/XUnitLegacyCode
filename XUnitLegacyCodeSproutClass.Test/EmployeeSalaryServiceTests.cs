using System.Linq;
using Xunit;
using XUnitLegacyCodeSproutClass.Services;

namespace XUnitLegacyCodeSproutClass.Test
{
    public class EmployeeSalaryServiceTests
    {
        [Fact]
        public void GetEmployees_ReturnsListEmployeesWithSalary()
        {
            var service = new EmployeeSalaryService();
            var list = service.GetEmployees();

            Assert.NotNull(list);
            Assert.True(list.Any());
            Assert.Contains(list, x => x.Salary > 0);
        }
    }
}
