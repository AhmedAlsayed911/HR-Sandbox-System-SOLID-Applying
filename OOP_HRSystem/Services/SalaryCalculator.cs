using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOP_HRSystem.Models;

namespace OOP_HRSystem.Services
{
    internal abstract class SalaryCalculator
    {
       public SalaryCalculator(Employee employee)
       {
           Employee = employee;
       }
       public Employee Employee {get;}
       public abstract decimal Calculate(); 
    }
}