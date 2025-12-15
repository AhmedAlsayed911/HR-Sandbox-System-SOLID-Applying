using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOP_HRSystem.Models;

namespace OOP_HRSystem.Services
{
    internal class InternEmployeeSalaryCalculator : SalaryCalculator
    {
        public InternEmployeeSalaryCalculator(Employee employee) : base(employee)
        {
        }

        public override decimal Calculate()
        {
            return 2000;
        }
    }
}
