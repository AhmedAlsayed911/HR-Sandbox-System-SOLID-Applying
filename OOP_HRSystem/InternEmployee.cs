using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_HRSystem
{
    internal class InternEmployee : DissmisableEmployee
    {
        public override IEnumerable<PayItem> GetPayItems()
        {
            return new[] { new PayItem("Basic Salary : ", 2000) };
        }

        public override decimal GetSalary()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            return 2000;
        }
    }
}
