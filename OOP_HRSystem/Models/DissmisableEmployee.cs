using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_HRSystem.Models
{
    internal class DissmisableEmployee : Employee
    {
       
        public override IEnumerable<PayItem> GetPayItems()
        {
            throw new NotImplementedException();
        }

        public override decimal GetSalary()
        {
            throw new NotImplementedException();
        }
        public bool Dismiss { get; private set; }
        public void setDismissed()
        {           
            Dismiss = true;
        }
    }
}
