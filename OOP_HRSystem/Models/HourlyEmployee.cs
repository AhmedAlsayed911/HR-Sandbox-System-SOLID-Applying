using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_HRSystem.Models
{
    internal class HourlyEmployee : DissmisableEmployee
    {
        public decimal HourRate {  get; set; }
        public decimal TotalWorkingHours { get; set; }

        public override IEnumerable<PayItem> GetPayItems()
        {
            return new[] { new PayItem("Total hours : ", GetSalary())};
        }

        public override decimal GetSalary()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            return HourRate * TotalWorkingHours;
        }
        
    }
}
