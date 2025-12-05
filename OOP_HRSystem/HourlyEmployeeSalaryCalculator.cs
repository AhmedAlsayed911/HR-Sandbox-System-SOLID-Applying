using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_HRSystem
{
    internal class HourlyEmployeeSalaryCalculator : SalaryCalculator
    {
        public HourlyEmployeeSalaryCalculator(Employee employee) : base(employee)
        {
        }

        public override decimal Calculate()
        {
            var employee = Employee as HourlyEmployee;
            return employee.HourRate * employee.TotalWorkingHours;
        }
    }
}
