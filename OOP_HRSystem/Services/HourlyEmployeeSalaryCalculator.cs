using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOP_HRSystem.Models;

namespace OOP_HRSystem.Services
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
