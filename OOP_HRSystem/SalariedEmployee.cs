using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_HRSystem
{
    internal class SalariedEmployee : DissmisableEmployee
    {
        public decimal BasicSalary { get; set; }
        public decimal Transportation { get; set; }
        public decimal Housing { get; set; }
        public override decimal GetSalary()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            return BasicSalary + Transportation + Housing;   
        }
        public decimal GetSalary(int taxPercentage)
        {
            return GetSalary() - (BasicSalary * taxPercentage / 100);
        }
        public decimal GetSalary(int taxPercentage , int bonus)
        {
            return GetSalary(taxPercentage) + bonus;
        }
        public override IEnumerable<PayItem> GetPayItems()
        {
            return new[]
            {
                new PayItem("Total hours : ", BasicSalary),
                new PayItem("Transportaion : ",Transportation),
                new PayItem("Housing : ",Housing)
            };
        }
    }
}
