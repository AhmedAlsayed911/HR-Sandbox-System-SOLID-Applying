using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_HRSystem
{
    internal abstract class Employee : Person
    {
        public string Email { get; internal set; }

        // private Decimal _basicSalary;
        // public Decimal BasicSalary
        // {
        //     get
        //     {
        //         return _basicSalary;
        //     }
        //     set
        //     {
        //         if (value < 2500)
        //             throw new ArgumentException("Invalid Salary!");
        //         _basicSalary = value;
        //     }
        // }
        // public int TaxPercentage {  get; set; }      
        //public abstract decimal Calculate(Employee employee);
        public abstract decimal GetSalary();
        public abstract IEnumerable<PayItem> GetPayItems();     
        
    }
}
