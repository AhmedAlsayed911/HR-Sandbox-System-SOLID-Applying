using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_HRSystem
{
    internal class SalariedEmployeeSalaryCalculator : SalaryCalculator   
    {
       public SalariedEmployeeSalaryCalculator(Employee employee) : base(employee)
       {
            // if there's base class is abstract and the constructor takes argument
            // => then childs must take the same argument at their constructors.
       }

        public override decimal Calculate()
        {
            var employee = Employee as SalariedEmployee;
            return employee.BasicSalary + employee.Housing + employee.Transportation;
        }
        
    }
}